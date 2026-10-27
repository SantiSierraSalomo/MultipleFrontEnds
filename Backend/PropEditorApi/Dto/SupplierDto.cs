namespace PropEditorApi.Dto;

public record SupplierDto(string SupplierId, string? Description);
public record SupplierCreateDto(string SupplierId, string? Description);
public record SupplierUpdateDto(string? Description);
