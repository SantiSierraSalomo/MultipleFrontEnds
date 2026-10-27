using PropEditorApi.Dto;
using PropEditorApi.Model;

namespace PropEditorApi.Mapping;

public static class WarehouseMappingExtensions
{
    public static WarehouseDto ToDto(this Warehouse entity) => new(entity.WarehouseId, entity.Description);

    public static Warehouse ToEntity(this WarehouseCreateDto dto) => new()
    {
        WarehouseId = dto.WarehouseId,
        Description = dto.Description
    };

    public static void ApplyUpdate(this Warehouse entity, WarehouseUpdateDto dto)
    {
        entity.Description = dto.Description;
    }
}
