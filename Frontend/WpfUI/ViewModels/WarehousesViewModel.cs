using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using WpfUI.Models;
using WpfUI.Services;

namespace WpfUI.ViewModels;

public class WarehousesViewModel : WorkspaceViewModelBase
{
    private readonly IApiClient _apiClient;

    public ObservableCollection<WarehouseDto> Warehouses { get; } = new();
    public IAsyncRelayCommand RefreshCommand { get; }

    public WarehousesViewModel(IApiClient apiClient)
    {
        _apiClient = apiClient;
        Title = "Masterdata - Warehouses";
        RefreshCommand = new AsyncRelayCommand(RefreshAsync);
    }

    public async Task RefreshAsync()
    {
        if (IsBusy)
        {
            return;
        }

        try
        {
            IsBusy = true;
            ErrorMessage = null;
            var data = await _apiClient.GetWarehousesAsync();
            Warehouses.Clear();
            foreach (var warehouse in data)
            {
                Warehouses.Add(warehouse);
            }
        }
        catch (Exception ex)
        {
            ErrorMessage = $"Failed to load warehouses: {ex.Message}";
        }
        finally
        {
            IsBusy = false;
        }
    }
}
