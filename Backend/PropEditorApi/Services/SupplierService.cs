using PropEditorApi.Dto;
using PropEditorApi.Mapping;
using PropEditorApi.Repository;

namespace PropEditorApi.Services;

public class SupplierService(ISupplierRepository repository, ILogger<SupplierService> logger) : ISupplierService
{
    public async Task<List<SupplierDto>> GetAllAsync() =>
        (await repository.GetAllAsync()).Select(x => x.ToDto()).ToList();

    public async Task<SupplierDto?> GetByIdAsync(string supplierId) =>
        (await repository.GetByIdAsync(supplierId))?.ToDto();

    public async Task<SupplierDto> CreateAsync(SupplierCreateDto dto)
    {
        var created = await repository.AddAsync(dto.ToEntity());
        logger.LogInformation("Service created supplier {SupplierId}", created.SupplierId);
        return created.ToDto();
    }

    public async Task<SupplierDto?> UpdateAsync(string supplierId, SupplierUpdateDto dto)
    {
        var current = await repository.GetByIdAsync(supplierId);
        if (current is null)
        {
            logger.LogWarning("Service could not find supplier {SupplierId} for update", supplierId);
            return null;
        }

        current.ApplyUpdate(dto);
        await repository.UpdateAsync(current);
        logger.LogInformation("Service updated supplier {SupplierId}", supplierId);
        return current.ToDto();
    }

    public async Task<bool> DeleteAsync(string supplierId)
    {
        var current = await repository.GetByIdAsync(supplierId);
        if (current is null)
        {
            logger.LogWarning("Service could not find supplier {SupplierId} for delete", supplierId);
            return false;
        }

        await repository.DeleteAsync(current);
        logger.LogInformation("Service deleted supplier {SupplierId}", supplierId);
        return true;
    }
}
