using Microsoft.EntityFrameworkCore;
using PropEditorApi.Data;
using PropEditorApi.Model;

namespace PropEditorApi.Repository;

public class FamilyRepository(PropEditorDbContext dbContext) : IFamilyRepository
{
    public Task<List<Family>> GetAllAsync() => dbContext.Families.AsNoTracking().ToListAsync();

    public Task<Family?> GetByIdAsync(string familyId) => dbContext.Families.FirstOrDefaultAsync(x => x.FamilyId == familyId);

    public async Task<Family> AddAsync(Family family)
    {
        dbContext.Families.Add(family);
        await dbContext.SaveChangesAsync();
        return family;
    }

    public async Task UpdateAsync(Family family)
    {
        dbContext.Families.Update(family);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Family family)
    {
        dbContext.Families.Remove(family);
        await dbContext.SaveChangesAsync();
    }
}
