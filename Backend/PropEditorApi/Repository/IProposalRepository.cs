using PropEditorApi.Model;

namespace PropEditorApi.Repository;

public interface IProposalRepository
{
    Task<List<Proposal>> GetAllAsync();
    Task<Proposal?> GetByIdAsync(string itemId, string warehouseId, int proposalIndex);
    Task<Proposal> AddAsync(Proposal proposal);
    Task UpdateAsync(Proposal proposal);
    Task DeleteAsync(Proposal proposal);
}
