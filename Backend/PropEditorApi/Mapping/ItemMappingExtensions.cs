using PropEditorApi.Dto;
using PropEditorApi.Model;

namespace PropEditorApi.Mapping;

public static class ItemMappingExtensions
{
    public static ItemDto ToDto(this Item entity) => new(
        entity.ItemId,
        entity.Description,
        entity.FamilyId,
        entity.SupplierId,
        entity.UnitCost,
        entity.UnitVol,
        entity.ListPrice);

    public static Item ToEntity(this ItemCreateDto dto) => new()
    {
        ItemId = dto.ItemId,
        Description = dto.Description,
        FamilyId = dto.FamilyId,
        SupplierId = dto.SupplierId,
        UnitCost = dto.UnitCost,
        UnitVol = dto.UnitVol,
        ListPrice = dto.ListPrice
    };

    public static void ApplyUpdate(this Item entity, ItemUpdateDto dto)
    {
        entity.Description = dto.Description;
        entity.FamilyId = dto.FamilyId;
        entity.SupplierId = dto.SupplierId;
        entity.UnitCost = dto.UnitCost;
        entity.UnitVol = dto.UnitVol;
        entity.ListPrice = dto.ListPrice;
    }
}
