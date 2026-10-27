using Microsoft.EntityFrameworkCore;
using PropEditorApi.Data;
using PropEditorApi.Model;

namespace PropEditorApi.Repository;

public class SupplierRepository(PropEditorDbContext dbContext) : ISupplierRepository
{
    public Task<List<Supplier>> GetAllAsync() => dbContext.Suppliers.AsNoTracking().ToListAsync();

    public Task<Supplier?> GetByIdAsync(string supplierId) => dbContext.Suppliers.FirstOrDefaultAsync(x => x.SupplierId == supplierId);

    public async Task<Supplier> AddAsync(Supplier supplier)
    {
        dbContext.Suppliers.Add(supplier);
        await dbContext.SaveChangesAsync();
        return supplier;
    }

    public async Task UpdateAsync(Supplier supplier)
    {
        dbContext.Suppliers.Update(supplier);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Supplier supplier)
    {
        dbContext.Suppliers.Remove(supplier);
        await dbContext.SaveChangesAsync();
    }
}
