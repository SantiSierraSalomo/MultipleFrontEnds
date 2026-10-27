namespace PropEditorApi.Dto;

public record WarehouseDto(string WarehouseId, string? Description);
public record WarehouseCreateDto(string WarehouseId, string? Description);
public record WarehouseUpdateDto(string? Description);
