using PropEditorApi.Dto;
using PropEditorApi.Model;

namespace PropEditorApi.Mapping;

public static class SupplierMappingExtensions
{
    public static SupplierDto ToDto(this Supplier entity) => new(entity.SupplierId, entity.Description);

    public static Supplier ToEntity(this SupplierCreateDto dto) => new()
    {
        SupplierId = dto.SupplierId,
        Description = dto.Description
    };

    public static void ApplyUpdate(this Supplier entity, SupplierUpdateDto dto)
    {
        entity.Description = dto.Description;
    }
}
