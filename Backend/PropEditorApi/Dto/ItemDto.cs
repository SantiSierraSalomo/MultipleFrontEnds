namespace PropEditorApi.Dto;

public record ItemDto(
    string ItemId,
    string? Description,
    string? FamilyId,
    string? SupplierId,
    decimal? UnitCost,
    decimal? UnitVol,
    decimal? ListPrice);

public record ItemCreateDto(
    string ItemId,
    string? Description,
    string? FamilyId,
    string? SupplierId,
    decimal? UnitCost,
    decimal? UnitVol,
    decimal? ListPrice);

public record ItemUpdateDto(
    string? Description,
    string? FamilyId,
    string? SupplierId,
    decimal? UnitCost,
    decimal? UnitVol,
    decimal? ListPrice);
