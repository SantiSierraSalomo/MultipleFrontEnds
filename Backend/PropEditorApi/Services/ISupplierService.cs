using PropEditorApi.Dto;

namespace PropEditorApi.Services;

public interface ISupplierService
{
    Task<List<SupplierDto>> GetAllAsync();
    Task<SupplierDto?> GetByIdAsync(string supplierId);
    Task<SupplierDto> CreateAsync(SupplierCreateDto dto);
    Task<SupplierDto?> UpdateAsync(string supplierId, SupplierUpdateDto dto);
    Task<bool> DeleteAsync(string supplierId);
}
