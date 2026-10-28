namespace WinformsUI.Models;

public record ProposalModel(
    string ItemId,
    string WarehouseId,
    int ProposalIndex,
    decimal? Quantity,
    DateOnly? ReleaseDate,
    DateOnly? DueDate);
