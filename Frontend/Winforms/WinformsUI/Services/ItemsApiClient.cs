using System.Net.Http.Json;
using WinformsUI.Models;

namespace WinformsUI.Services;

public interface IItemsApiClient
{
    Task<List<ItemModel>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<ItemModel?> GetByIdAsync(string itemId, CancellationToken cancellationToken = default);
}

public class ItemsApiClient : IItemsApiClient
{
    private readonly HttpClient _httpClient;

    public ItemsApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<ItemModel>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var result = await _httpClient.GetFromJsonAsync<List<ItemModel>>("api/items", cancellationToken);
        return result ?? [];
    }

    public async Task<ItemModel?> GetByIdAsync(string itemId, CancellationToken cancellationToken = default)
    {
        return await _httpClient.GetFromJsonAsync<ItemModel>($"api/items/{Uri.EscapeDataString(itemId)}", cancellationToken);
    }
}
