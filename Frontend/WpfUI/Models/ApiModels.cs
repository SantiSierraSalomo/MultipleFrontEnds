using System;

namespace WpfUI.Models;

public record ItemDto(
    string ItemId,
    string? Description,
    string? FamilyId,
    string? SupplierId,
    decimal? UnitCost,
    decimal? UnitVol,
    decimal? ListPrice);

public record WarehouseDto(
    string WarehouseId,
    string? Description);

public record ProposalDto(
    string ItemId,
    string WarehouseId,
    int ProposalIndex,
    decimal? Quantity,
    DateOnly? ReleaseDate,
    DateOnly? DueDate);

public record ContactMessage(
    string Name,
    string Email,
    string Subject,
    string Message);
