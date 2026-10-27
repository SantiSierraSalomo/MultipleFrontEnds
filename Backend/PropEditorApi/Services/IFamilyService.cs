using PropEditorApi.Dto;

namespace PropEditorApi.Services;

public interface IFamilyService
{
    Task<List<FamilyDto>> GetAllAsync();
    Task<FamilyDto?> GetByIdAsync(string familyId);
    Task<FamilyDto> CreateAsync(FamilyCreateDto dto);
    Task<FamilyDto?> UpdateAsync(string familyId, FamilyUpdateDto dto);
    Task<bool> DeleteAsync(string familyId);
}
