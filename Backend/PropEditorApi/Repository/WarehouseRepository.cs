using Microsoft.EntityFrameworkCore;
using PropEditorApi.Data;
using PropEditorApi.Model;

namespace PropEditorApi.Repository;

public class WarehouseRepository(PropEditorDbContext dbContext) : IWarehouseRepository
{
    public Task<List<Warehouse>> GetAllAsync() => dbContext.Warehouses.AsNoTracking().ToListAsync();

    public Task<Warehouse?> GetByIdAsync(string warehouseId) => dbContext.Warehouses.FirstOrDefaultAsync(x => x.WarehouseId == warehouseId);

    public async Task<Warehouse> AddAsync(Warehouse warehouse)
    {
        dbContext.Warehouses.Add(warehouse);
        await dbContext.SaveChangesAsync();
        return warehouse;
    }

    public async Task UpdateAsync(Warehouse warehouse)
    {
        dbContext.Warehouses.Update(warehouse);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Warehouse warehouse)
    {
        dbContext.Warehouses.Remove(warehouse);
        await dbContext.SaveChangesAsync();
    }
}
