using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using WpfUI.Models;

namespace WpfUI.Services;

public class ApiClient : IApiClient
{
    private readonly HttpClient _httpClient;

    public ApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task HealthPingAsync(CancellationToken cancellationToken = default)
    {
        using var response = await _httpClient.GetAsync("/api/items", HttpCompletionOption.ResponseHeadersRead, cancellationToken);
        response.EnsureSuccessStatusCode();
    }

    public async Task<IReadOnlyList<ItemDto>> GetItemsAsync(CancellationToken cancellationToken = default)
    {
        var result = await _httpClient.GetFromJsonAsync<List<ItemDto>>("/api/items", cancellationToken);
        return result ?? (IReadOnlyList<ItemDto>)Array.Empty<ItemDto>();
    }

    public async Task<IReadOnlyList<WarehouseDto>> GetWarehousesAsync(CancellationToken cancellationToken = default)
    {
        var result = await _httpClient.GetFromJsonAsync<List<WarehouseDto>>("/api/Warehouses", cancellationToken);
        return result ?? (IReadOnlyList<WarehouseDto>)Array.Empty<WarehouseDto>();
    }

    public async Task<IReadOnlyList<ProposalDto>> GetProposalsAsync(CancellationToken cancellationToken = default)
    {
        var result = await _httpClient.GetFromJsonAsync<List<ProposalDto>>("/api/Proposals", cancellationToken);
        return result ?? (IReadOnlyList<ProposalDto>)Array.Empty<ProposalDto>();
    }

    public async Task SendContactMessageAsync(ContactMessage message, CancellationToken cancellationToken = default)
    {
        // Placeholder simulation until an endpoint is created
        await Task.Delay(600, cancellationToken);
    }
}
