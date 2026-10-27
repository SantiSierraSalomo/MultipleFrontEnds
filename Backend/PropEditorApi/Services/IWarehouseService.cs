using PropEditorApi.Dto;

namespace PropEditorApi.Services;

public interface IWarehouseService
{
    Task<List<WarehouseDto>> GetAllAsync();
    Task<WarehouseDto?> GetByIdAsync(string warehouseId);
    Task<WarehouseDto> CreateAsync(WarehouseCreateDto dto);
    Task<WarehouseDto?> UpdateAsync(string warehouseId, WarehouseUpdateDto dto);
    Task<bool> DeleteAsync(string warehouseId);
}
