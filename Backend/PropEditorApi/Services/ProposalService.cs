using PropEditorApi.Dto;
using PropEditorApi.Mapping;
using PropEditorApi.Repository;

namespace PropEditorApi.Services;

public class ProposalService(IProposalRepository repository) : IProposalService
{
    public async Task<List<ProposalDto>> GetAllAsync() =>
        (await repository.GetAllAsync()).Select(x => x.ToDto()).ToList();

    public async Task<ProposalDto?> GetByIdAsync(string itemId, string warehouseId, int proposalIndex) =>
        (await repository.GetByIdAsync(itemId, warehouseId, proposalIndex))?.ToDto();

    public async Task<ProposalDto> CreateAsync(ProposalCreateDto dto)
    {
        var created = await repository.AddAsync(dto.ToEntity());
        return created.ToDto();
    }

    public async Task<ProposalDto?> UpdateAsync(string itemId, string warehouseId, int proposalIndex, ProposalUpdateDto dto)
    {
        var current = await repository.GetByIdAsync(itemId, warehouseId, proposalIndex);
        if (current is null)
        {
            return null;
        }

        current.ApplyUpdate(dto);
        await repository.UpdateAsync(current);
        return current.ToDto();
    }

    public async Task<bool> DeleteAsync(string itemId, string warehouseId, int proposalIndex)
    {
        var current = await repository.GetByIdAsync(itemId, warehouseId, proposalIndex);
        if (current is null)
        {
            return false;
        }

        await repository.DeleteAsync(current);
        return true;
    }
}
