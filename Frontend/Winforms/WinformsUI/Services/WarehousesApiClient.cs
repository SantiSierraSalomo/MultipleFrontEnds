using System.Net.Http.Json;
using WinformsUI.Models;

namespace WinformsUI.Services;

public interface IWarehousesApiClient
{
    Task<List<WarehouseModel>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<WarehouseModel?> GetByIdAsync(string warehouseId, CancellationToken cancellationToken = default);
}

public class WarehousesApiClient : IWarehousesApiClient
{
    private readonly HttpClient _httpClient;

    public WarehousesApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<WarehouseModel>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var result = await _httpClient.GetFromJsonAsync<List<WarehouseModel>>("api/Warehouses", cancellationToken);
        return result ?? [];
    }

    public async Task<WarehouseModel?> GetByIdAsync(string warehouseId, CancellationToken cancellationToken = default)
    {
        return await _httpClient.GetFromJsonAsync<WarehouseModel>($"api/Warehouses/{Uri.EscapeDataString(warehouseId)}", cancellationToken);
    }
}
