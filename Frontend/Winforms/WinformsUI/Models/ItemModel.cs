namespace WinformsUI.Models;

public record ItemModel(
    string ItemId,
    string? Description,
    string? FamilyId,
    string? SupplierId,
    decimal? UnitCost,
    decimal? UnitVol,
    decimal? ListPrice);
