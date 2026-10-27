using PropEditorApi.Dto;
using PropEditorApi.Mapping;
using PropEditorApi.Repository;

namespace PropEditorApi.Services;

public class FamilyService(IFamilyRepository repository) : IFamilyService
{
    public async Task<List<FamilyDto>> GetAllAsync() =>
        (await repository.GetAllAsync()).Select(x => x.ToDto()).ToList();

    public async Task<FamilyDto?> GetByIdAsync(string familyId) =>
        (await repository.GetByIdAsync(familyId))?.ToDto();

    public async Task<FamilyDto> CreateAsync(FamilyCreateDto dto)
    {
        var created = await repository.AddAsync(dto.ToEntity());
        return created.ToDto();
    }

    public async Task<FamilyDto?> UpdateAsync(string familyId, FamilyUpdateDto dto)
    {
        var current = await repository.GetByIdAsync(familyId);
        if (current is null)
        {
            return null;
        }

        current.ApplyUpdate(dto);
        await repository.UpdateAsync(current);
        return current.ToDto();
    }

    public async Task<bool> DeleteAsync(string familyId)
    {
        var current = await repository.GetByIdAsync(familyId);
        if (current is null)
        {
            return false;
        }

        await repository.DeleteAsync(current);
        return true;
    }
}
