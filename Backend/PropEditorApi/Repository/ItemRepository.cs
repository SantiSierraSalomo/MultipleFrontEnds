using Microsoft.EntityFrameworkCore;
using PropEditorApi.Data;
using PropEditorApi.Model;

namespace PropEditorApi.Repository;

public class ItemRepository(PropEditorDbContext dbContext) : IItemRepository
{
    public Task<List<Item>> GetAllAsync() => dbContext.Items.AsNoTracking().ToListAsync();

    public Task<Item?> GetByIdAsync(string itemId) => dbContext.Items.FirstOrDefaultAsync(x => x.ItemId == itemId);

    public async Task<Item> AddAsync(Item item)
    {
        dbContext.Items.Add(item);
        await dbContext.SaveChangesAsync();
        return item;
    }

    public async Task UpdateAsync(Item item)
    {
        dbContext.Items.Update(item);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Item item)
    {
        dbContext.Items.Remove(item);
        await dbContext.SaveChangesAsync();
    }
}
