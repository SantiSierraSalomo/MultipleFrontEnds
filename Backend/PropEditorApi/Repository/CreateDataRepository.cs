using Microsoft.EntityFrameworkCore;
using PropEditorApi.Data;
using PropEditorApi.Model;

namespace PropEditorApi.Repository;

public class CreateDataRepository(PropEditorDbContext dbContext) : ICreateDataRepository
{
    public async Task ClearMasterdataAsync()
    {
        await dbContext.Proposals.ExecuteDeleteAsync();
        await dbContext.Items.ExecuteDeleteAsync();
        await dbContext.Warehouses.ExecuteDeleteAsync();
        await dbContext.Suppliers.ExecuteDeleteAsync();
        await dbContext.Families.ExecuteDeleteAsync();
    }

    public Task ClearProposalsAsync() => dbContext.Proposals.ExecuteDeleteAsync();

    public async Task AddFamiliesAsync(List<Family> families)
    {
        await dbContext.Families.AddRangeAsync(families);
        await dbContext.SaveChangesAsync();
    }

    public async Task AddSuppliersAsync(List<Supplier> suppliers)
    {
        await dbContext.Suppliers.AddRangeAsync(suppliers);
        await dbContext.SaveChangesAsync();
    }

    public async Task AddItemsAsync(List<Item> items)
    {
        await dbContext.Items.AddRangeAsync(items);
        await dbContext.SaveChangesAsync();
    }

    public async Task AddWarehousesAsync(List<Warehouse> warehouses)
    {
        await dbContext.Warehouses.AddRangeAsync(warehouses);
        await dbContext.SaveChangesAsync();
    }

    public async Task AddProposalsAsync(List<Proposal> proposals)
    {
        await dbContext.Proposals.AddRangeAsync(proposals);
        await dbContext.SaveChangesAsync();
    }

    public async Task<(int Families, int Suppliers, int Items, int Warehouses)> GetMasterdataCountsAsync()
    {
        var families = await dbContext.Families.CountAsync();
        var suppliers = await dbContext.Suppliers.CountAsync();
        var items = await dbContext.Items.CountAsync();
        var warehouses = await dbContext.Warehouses.CountAsync();
        return (families, suppliers, items, warehouses);
    }

    public Task<List<Item>> GetItemsAsync() => dbContext.Items.AsNoTracking().ToListAsync();

    public Task<List<Warehouse>> GetWarehousesAsync() => dbContext.Warehouses.AsNoTracking().ToListAsync();
}
