using PropEditorApi.Dto;
using PropEditorApi.Mapping;
using PropEditorApi.Repository;

namespace PropEditorApi.Services;

public class ProposalService(IProposalRepository repository, ILogger<ProposalService> logger) : IProposalService
{
    public async Task<List<ProposalDto>> GetAllAsync() =>
        (await repository.GetAllAsync()).Select(x => x.ToDto()).ToList();

    public async Task<ProposalDto?> GetByIdAsync(string itemId, string warehouseId, int proposalIndex) =>
        (await repository.GetByIdAsync(itemId, warehouseId, proposalIndex))?.ToDto();

    public async Task<ProposalDto> CreateAsync(ProposalCreateDto dto)
    {
        var created = await repository.AddAsync(dto.ToEntity());
        logger.LogInformation("Service created proposal {ItemId}/{WarehouseId}/{ProposalIndex}", created.ItemId, created.WarehouseId, created.ProposalIndex);
        return created.ToDto();
    }

    public async Task<ProposalDto?> UpdateAsync(string itemId, string warehouseId, int proposalIndex, ProposalUpdateDto dto)
    {
        var current = await repository.GetByIdAsync(itemId, warehouseId, proposalIndex);
        if (current is null)
        {
            logger.LogWarning("Service could not find proposal {ItemId}/{WarehouseId}/{ProposalIndex} for update", itemId, warehouseId, proposalIndex);
            return null;
        }

        current.ApplyUpdate(dto);
        await repository.UpdateAsync(current);
        logger.LogInformation("Service updated proposal {ItemId}/{WarehouseId}/{ProposalIndex}", itemId, warehouseId, proposalIndex);
        return current.ToDto();
    }

    public async Task<bool> DeleteAsync(string itemId, string warehouseId, int proposalIndex)
    {
        var current = await repository.GetByIdAsync(itemId, warehouseId, proposalIndex);
        if (current is null)
        {
            logger.LogWarning("Service could not find proposal {ItemId}/{WarehouseId}/{ProposalIndex} for delete", itemId, warehouseId, proposalIndex);
            return false;
        }

        await repository.DeleteAsync(current);
        logger.LogInformation("Service deleted proposal {ItemId}/{WarehouseId}/{ProposalIndex}", itemId, warehouseId, proposalIndex);
        return true;
    }
}
