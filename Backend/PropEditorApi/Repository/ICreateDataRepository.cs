using PropEditorApi.Model;

namespace PropEditorApi.Repository;

public interface ICreateDataRepository
{
    Task ClearMasterdataAsync();
    Task ClearProposalsAsync();
    Task AddFamiliesAsync(List<Family> families);
    Task AddSuppliersAsync(List<Supplier> suppliers);
    Task AddItemsAsync(List<Item> items);
    Task AddWarehousesAsync(List<Warehouse> warehouses);
    Task AddProposalsAsync(List<Proposal> proposals);
    Task<(int Families, int Suppliers, int Items, int Warehouses)> GetMasterdataCountsAsync();
    Task<List<Item>> GetItemsAsync();
    Task<List<Warehouse>> GetWarehousesAsync();
}
