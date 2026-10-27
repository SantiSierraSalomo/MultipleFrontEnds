using PropEditorApi.Dto;
using PropEditorApi.Model;

namespace PropEditorApi.Mapping;

public static class FamilyMappingExtensions
{
    public static FamilyDto ToDto(this Family entity) => new(entity.FamilyId, entity.Description);

    public static Family ToEntity(this FamilyCreateDto dto) => new()
    {
        FamilyId = dto.FamilyId,
        Description = dto.Description
    };

    public static void ApplyUpdate(this Family entity, FamilyUpdateDto dto)
    {
        entity.Description = dto.Description;
    }
}
