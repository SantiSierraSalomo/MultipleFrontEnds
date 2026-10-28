using System.Net.Http.Json;
using WinformsUI.Models;

namespace WinformsUI.Services;

public interface IProposalsApiClient
{
    Task<List<ProposalModel>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<ProposalModel?> GetByIdAsync(string itemId, string warehouseId, int proposalIndex, CancellationToken cancellationToken = default);
}

public class ProposalsApiClient : IProposalsApiClient
{
    private readonly HttpClient _httpClient;

    public ProposalsApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<ProposalModel>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var result = await _httpClient.GetFromJsonAsync<List<ProposalModel>>("api/Proposals", cancellationToken);
        return result ?? [];
    }

    public async Task<ProposalModel?> GetByIdAsync(string itemId, string warehouseId, int proposalIndex, CancellationToken cancellationToken = default)
    {
        var escapedItem = Uri.EscapeDataString(itemId);
        var escapedWh = Uri.EscapeDataString(warehouseId);
        return await _httpClient.GetFromJsonAsync<ProposalModel>($"api/Proposals/{escapedItem}/{escapedWh}/{proposalIndex}", cancellationToken);
    }
}
