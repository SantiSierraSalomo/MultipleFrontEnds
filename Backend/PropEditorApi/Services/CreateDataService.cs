using PropEditorApi.Dto;
using PropEditorApi.Exceptions;
using PropEditorApi.Model;
using PropEditorApi.Repository;

namespace PropEditorApi.Services;

public class CreateDataService(ICreateDataRepository repository, ILogger<CreateDataService> logger) : ICreateDataService
{
    private static readonly string[] FamilyNames =
    [
        "CocaCola",
        "Fanta",
        "FuzeTea",
        "Aquarius",
        "Sprite",
        "Schweppes",
        "Powerade",
        "MinuteMaid",
        "Burn",
        "Kinley"
    ];

    private static readonly string[] WarehouseNames = ["North", "South", "Center", "East"];

    public async Task<CreateMasterdataResultDto> CreateMasterdataAsync()
    {
        await repository.ClearMasterdataAsync();

        var families = FamilyNames
            .Select(name => new Family
            {
                FamilyId = name,
                Description = name
            })
            .ToList();

        var suppliers = Enumerable.Range(1, 5)
            .Select(index => new Supplier
            {
                SupplierId = $"Line{index}",
                Description = $"Production line {index}"
            })
            .ToList();

        var supplierIds = suppliers.Select(x => x.SupplierId).ToArray();
        var items = CreateItems(families.Select(x => x.FamilyId).ToArray(), supplierIds);

        var warehouses = WarehouseNames
            .Select(name => new Warehouse
            {
                WarehouseId = name,
                Description = name
            })
            .ToList();

        await repository.AddFamiliesAsync(families);
        await repository.AddSuppliersAsync(suppliers);
        await repository.AddItemsAsync(items);
        await repository.AddWarehousesAsync(warehouses);

        logger.LogInformation(
            "Created masterdata. Families: {Families}, Suppliers: {Suppliers}, Items: {Items}, Warehouses: {Warehouses}",
            families.Count,
            suppliers.Count,
            items.Count,
            warehouses.Count);

        return new CreateMasterdataResultDto(
            families.Count,
            suppliers.Count,
            items.Count,
            warehouses.Count,
            "Masterdata recreated successfully.");
    }

    public async Task<CreateProposalsResultDto> CreateProposalsAsync()
    {
        var counts = await repository.GetMasterdataCountsAsync();
        if (counts.Families == 0 || counts.Suppliers == 0 || counts.Items == 0 || counts.Warehouses == 0)
        {
            throw new DomainValidationException("Masterdata is required. Create masterdata before creating proposals.");
        }

        var items = await repository.GetItemsAsync();
        var warehouses = await repository.GetWarehousesAsync();

        if (items.Count == 0 || warehouses.Count == 0)
        {
            throw new DomainValidationException("Masterdata is required. Create masterdata before creating proposals.");
        }

        if (!items.Any(x => x.FamilyId == "CocaCola"))
        {
            throw new DomainValidationException("CocaCola family items are required. Recreate masterdata first.");
        }

        var combinationsPerDay = items.Count * warehouses.Count;
        if (combinationsPerDay < 50)
        {
            throw new DomainConflictException(
                $"Not enough item/warehouse combinations to create 50 proposals per day. Available combinations: {combinationsPerDay}.");
        }

        await repository.ClearProposalsAsync();

        var random = new Random();
        var startDate = DateOnly.FromDateTime(DateTime.Today);
        var proposals = new List<Proposal>(500);

        for (var dayIndex = 0; dayIndex < 10; dayIndex++)
        {
            var usedCombinations = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            var releaseDate = startDate.AddDays(dayIndex);
            var dueDate = releaseDate.AddDays(7);

            while (usedCombinations.Count < 50)
            {
                var item = items[random.Next(items.Count)];
                var warehouse = warehouses[random.Next(warehouses.Count)];
                var key = $"{item.ItemId}|{warehouse.WarehouseId}";
                if (!usedCombinations.Add(key))
                {
                    continue;
                }

                var isCocaCola = string.Equals(item.FamilyId, "CocaCola", StringComparison.OrdinalIgnoreCase);
                var quantity = isCocaCola
                    ? random.Next(120, 301)
                    : random.Next(20, 121);

                proposals.Add(new Proposal
                {
                    ItemId = item.ItemId,
                    WarehouseId = warehouse.WarehouseId,
                    ProposalIndex = dayIndex,
                    Quantity = quantity,
                    ReleaseDate = releaseDate,
                    DueDate = dueDate
                });
            }
        }

        await repository.AddProposalsAsync(proposals);

        logger.LogInformation("Created proposals. Days: {Days}, Proposals: {Proposals}", 10, proposals.Count);

        return new CreateProposalsResultDto(10, proposals.Count, "Proposals created successfully.");
    }

    private static List<Item> CreateItems(IReadOnlyList<string> familyIds, IReadOnlyList<string> supplierIds)
    {
        var items = new List<Item>(familyIds.Count * 10);

        foreach (var familyId in familyIds)
        {
            for (var itemNumber = 1; itemNumber <= 10; itemNumber++)
            {
                var supplierId = ResolveSupplierId(familyId, itemNumber, supplierIds);
                var unitCost = familyId == "CocaCola"
                    ? 0.85m + (itemNumber * 0.05m)
                    : 0.70m + (itemNumber * 0.04m);

                var listPrice = Math.Round(unitCost * 1.35m, 2, MidpointRounding.AwayFromZero);

                items.Add(new Item
                {
                    ItemId = $"{familyId}-{itemNumber:00}",
                    Description = $"{familyId} Item {itemNumber:00}",
                    FamilyId = familyId,
                    SupplierId = supplierId,
                    UnitCost = Math.Round(unitCost, 2, MidpointRounding.AwayFromZero),
                    UnitVol = familyId == "CocaCola" ? 1.50m : 1.00m,
                    ListPrice = listPrice
                });
            }
        }

        return items;
    }

    private static string ResolveSupplierId(string familyId, int itemNumber, IReadOnlyList<string> supplierIds)
    {
        if (familyId == "CocaCola")
        {
            return itemNumber % 2 == 0 ? supplierIds[0] : supplierIds[1];
        }

        var sharedIndex = 2 + ((itemNumber - 1) % 3);
        return supplierIds[sharedIndex];
    }
}
