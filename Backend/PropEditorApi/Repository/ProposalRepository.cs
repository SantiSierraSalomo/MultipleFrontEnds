using Microsoft.EntityFrameworkCore;
using PropEditorApi.Data;
using PropEditorApi.Model;

namespace PropEditorApi.Repository;

public class ProposalRepository(PropEditorDbContext dbContext) : IProposalRepository
{
    public Task<List<Proposal>> GetAllAsync() => dbContext.Proposals.AsNoTracking().ToListAsync();

    public Task<Proposal?> GetByIdAsync(string itemId, string warehouseId, int proposalIndex) =>
        dbContext.Proposals.FirstOrDefaultAsync(x =>
            x.ItemId == itemId &&
            x.WarehouseId == warehouseId &&
            x.ProposalIndex == proposalIndex);

    public async Task<Proposal> AddAsync(Proposal proposal)
    {
        dbContext.Proposals.Add(proposal);
        await dbContext.SaveChangesAsync();
        return proposal;
    }

    public async Task UpdateAsync(Proposal proposal)
    {
        dbContext.Proposals.Update(proposal);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Proposal proposal)
    {
        dbContext.Proposals.Remove(proposal);
        await dbContext.SaveChangesAsync();
    }
}
