namespace PropEditorApi.Dto;

public record ProposalDto(
    string ItemId,
    string WarehouseId,
    int ProposalIndex,
    decimal? Quantity,
    DateOnly? ReleaseDate,
    DateOnly? DueDate);

public record ProposalCreateDto(
    string ItemId,
    string WarehouseId,
    int ProposalIndex,
    decimal? Quantity,
    DateOnly? ReleaseDate,
    DateOnly? DueDate);

public record ProposalUpdateDto(
    decimal? Quantity,
    DateOnly? ReleaseDate,
    DateOnly? DueDate);
