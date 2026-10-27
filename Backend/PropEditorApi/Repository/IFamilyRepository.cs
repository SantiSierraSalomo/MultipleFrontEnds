using PropEditorApi.Model;

namespace PropEditorApi.Repository;

public interface IFamilyRepository
{
    Task<List<Family>> GetAllAsync();
    Task<Family?> GetByIdAsync(string familyId);
    Task<Family> AddAsync(Family family);
    Task UpdateAsync(Family family);
    Task DeleteAsync(Family family);
}
