using PropEditorApi.Dto;
using PropEditorApi.Model;

namespace PropEditorApi.Mapping;

public static class ProposalMappingExtensions
{
    public static ProposalDto ToDto(this Proposal entity) => new(
        entity.ItemId,
        entity.WarehouseId,
        entity.ProposalIndex,
        entity.Quantity,
        entity.ReleaseDate,
        entity.DueDate);

    public static Proposal ToEntity(this ProposalCreateDto dto) => new()
    {
        ItemId = dto.ItemId,
        WarehouseId = dto.WarehouseId,
        ProposalIndex = dto.ProposalIndex,
        Quantity = dto.Quantity,
        ReleaseDate = dto.ReleaseDate,
        DueDate = dto.DueDate
    };

    public static void ApplyUpdate(this Proposal entity, ProposalUpdateDto dto)
    {
        entity.Quantity = dto.Quantity;
        entity.ReleaseDate = dto.ReleaseDate;
        entity.DueDate = dto.DueDate;
    }
}
