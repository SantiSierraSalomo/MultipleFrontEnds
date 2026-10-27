using PropEditorApi.Dto;
using PropEditorApi.Mapping;
using PropEditorApi.Repository;

namespace PropEditorApi.Services;

public class WarehouseService(IWarehouseRepository repository) : IWarehouseService
{
    public async Task<List<WarehouseDto>> GetAllAsync() =>
        (await repository.GetAllAsync()).Select(x => x.ToDto()).ToList();

    public async Task<WarehouseDto?> GetByIdAsync(string warehouseId) =>
        (await repository.GetByIdAsync(warehouseId))?.ToDto();

    public async Task<WarehouseDto> CreateAsync(WarehouseCreateDto dto)
    {
        var created = await repository.AddAsync(dto.ToEntity());
        return created.ToDto();
    }

    public async Task<WarehouseDto?> UpdateAsync(string warehouseId, WarehouseUpdateDto dto)
    {
        var current = await repository.GetByIdAsync(warehouseId);
        if (current is null)
        {
            return null;
        }

        current.ApplyUpdate(dto);
        await repository.UpdateAsync(current);
        return current.ToDto();
    }

    public async Task<bool> DeleteAsync(string warehouseId)
    {
        var current = await repository.GetByIdAsync(warehouseId);
        if (current is null)
        {
            return false;
        }

        await repository.DeleteAsync(current);
        return true;
    }
}
