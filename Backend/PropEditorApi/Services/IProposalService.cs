using PropEditorApi.Dto;

namespace PropEditorApi.Services;

public interface IProposalService
{
    Task<List<ProposalDto>> GetAllAsync();
    Task<ProposalDto?> GetByIdAsync(string itemId, string warehouseId, int proposalIndex);
    Task<ProposalDto> CreateAsync(ProposalCreateDto dto);
    Task<ProposalDto?> UpdateAsync(string itemId, string warehouseId, int proposalIndex, ProposalUpdateDto dto);
    Task<bool> DeleteAsync(string itemId, string warehouseId, int proposalIndex);
}
