using PropEditorApi.Dto;
using PropEditorApi.Mapping;
using PropEditorApi.Repository;

namespace PropEditorApi.Services;

public class WarehouseService(IWarehouseRepository repository, ILogger<WarehouseService> logger) : IWarehouseService
{
    public async Task<List<WarehouseDto>> GetAllAsync() =>
        (await repository.GetAllAsync()).Select(x => x.ToDto()).ToList();

    public async Task<WarehouseDto?> GetByIdAsync(string warehouseId) =>
        (await repository.GetByIdAsync(warehouseId))?.ToDto();

    public async Task<WarehouseDto> CreateAsync(WarehouseCreateDto dto)
    {
        var created = await repository.AddAsync(dto.ToEntity());
        logger.LogInformation("Service created warehouse {WarehouseId}", created.WarehouseId);
        return created.ToDto();
    }

    public async Task<WarehouseDto?> UpdateAsync(string warehouseId, WarehouseUpdateDto dto)
    {
        var current = await repository.GetByIdAsync(warehouseId);
        if (current is null)
        {
            logger.LogWarning("Service could not find warehouse {WarehouseId} for update", warehouseId);
            return null;
        }

        current.ApplyUpdate(dto);
        await repository.UpdateAsync(current);
        logger.LogInformation("Service updated warehouse {WarehouseId}", warehouseId);
        return current.ToDto();
    }

    public async Task<bool> DeleteAsync(string warehouseId)
    {
        var current = await repository.GetByIdAsync(warehouseId);
        if (current is null)
        {
            logger.LogWarning("Service could not find warehouse {WarehouseId} for delete", warehouseId);
            return false;
        }

        await repository.DeleteAsync(current);
        logger.LogInformation("Service deleted warehouse {WarehouseId}", warehouseId);
        return true;
    }
}
