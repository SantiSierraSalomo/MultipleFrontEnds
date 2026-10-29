using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using WpfUI.Models;
using WpfUI.Services;

namespace WpfUI.ViewModels;

public class ItemsViewModel : WorkspaceViewModelBase
{
    private readonly IApiClient _apiClient;

    public ObservableCollection<ItemDto> Items { get; } = new();
    public IAsyncRelayCommand RefreshCommand { get; }

    public ItemsViewModel(IApiClient apiClient)
    {
        _apiClient = apiClient;
        Title = "Masterdata - Items";
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
            var data = await _apiClient.GetItemsAsync();
            Items.Clear();
            foreach (var item in data)
            {
                Items.Add(item);
            }
        }
        catch (Exception ex)
        {
            ErrorMessage = $"Failed to load items: {ex.Message}";
        }
        finally
        {
            IsBusy = false;
        }
    }
}
