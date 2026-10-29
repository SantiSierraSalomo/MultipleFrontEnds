using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using WpfUI.Models;
using WpfUI.Services;

namespace WpfUI.ViewModels;

public class ProposalEditingViewModel : WorkspaceViewModelBase
{
    private readonly IApiClient _apiClient;
    private string _selectedItem = "All";
    private string _selectedWarehouse = "All";
    private string _selectedProposalIndex = "All";

    public ObservableCollection<string> ItemFilterOptions { get; } = new();
    public ObservableCollection<string> WarehouseFilterOptions { get; } = new();
    public ObservableCollection<string> ProposalIndexFilterOptions { get; } = new();

    public ObservableCollection<ProposalDto> Proposals { get; } = new();
    public IAsyncRelayCommand InitializeFiltersCommand { get; }
    public IAsyncRelayCommand ShowDataCommand { get; }

    public string SelectedItem
    {
        get => _selectedItem;
        set
        {
            if (SetProperty(ref _selectedItem, value) && _allProposalsCache.Count > 0)
            {
                ApplyFilter();
            }
        }
    }

    public string SelectedWarehouse
    {
        get => _selectedWarehouse;
        set
        {
            if (SetProperty(ref _selectedWarehouse, value) && _allProposalsCache.Count > 0)
            {
                ApplyFilter();
            }
        }
    }

    public string SelectedProposalIndex
    {
        get => _selectedProposalIndex;
        set
        {
            if (SetProperty(ref _selectedProposalIndex, value) && _allProposalsCache.Count > 0)
            {
                ApplyFilter();
            }
        }
    }

    private List<ProposalDto> _allProposalsCache = new();

    public ProposalEditingViewModel(IApiClient apiClient)
    {
        _apiClient = apiClient;
        Title = "Proposal Editing";
        InitializeFiltersCommand = new AsyncRelayCommand(InitializeFiltersAsync);
        ShowDataCommand = new AsyncRelayCommand(ShowDataAsync);
    }

    public async Task InitializeFiltersAsync()
    {
        try
        {
            var itemsTask = _apiClient.GetItemsAsync();
            var warehousesTask = _apiClient.GetWarehousesAsync();

            await Task.WhenAll(itemsTask, warehousesTask);

            ItemFilterOptions.Clear();
            ItemFilterOptions.Add("All");
            foreach (var item in await itemsTask)
            {
                ItemFilterOptions.Add(item.ItemId);
            }
            SelectedItem = "All";

            WarehouseFilterOptions.Clear();
            WarehouseFilterOptions.Add("All");
            foreach (var wh in await warehousesTask)
            {
                WarehouseFilterOptions.Add(wh.WarehouseId);
            }
            SelectedWarehouse = "All";

            ProposalIndexFilterOptions.Clear();
            ProposalIndexFilterOptions.Add("All");
            for (int i = 0; i <= 20; i++)
            {
                ProposalIndexFilterOptions.Add(i.ToString());
            }
            SelectedProposalIndex = "All";
        }
        catch (Exception ex)
        {
            ErrorMessage = $"Failed to load filter options: {ex.Message}";
        }
    }

    public async Task ShowDataAsync()
    {
        if (IsBusy)
        {
            return;
        }

        try
        {
            IsBusy = true;
            ErrorMessage = null;

            var rawProposals = await _apiClient.GetProposalsAsync();
            _allProposalsCache = rawProposals.ToList();

            ApplyFilter();
        }
        catch (Exception ex)
        {
            ErrorMessage = $"Failed to load proposals: {ex.Message}";
        }
        finally
        {
            IsBusy = false;
        }
    }

    private void ApplyFilter()
    {
        var filtered = _allProposalsCache.AsEnumerable();

        if (!string.IsNullOrWhiteSpace(SelectedItem) && SelectedItem != "All")
        {
            filtered = filtered.Where(p => string.Equals(p.ItemId, SelectedItem, StringComparison.OrdinalIgnoreCase));
        }

        if (!string.IsNullOrWhiteSpace(SelectedWarehouse) && SelectedWarehouse != "All")
        {
            filtered = filtered.Where(p => string.Equals(p.WarehouseId, SelectedWarehouse, StringComparison.OrdinalIgnoreCase));
        }

        if (!string.IsNullOrWhiteSpace(SelectedProposalIndex) && SelectedProposalIndex != "All" && int.TryParse(SelectedProposalIndex, out var idx))
        {
            filtered = filtered.Where(p => p.ProposalIndex == idx);
        }

        Proposals.Clear();
        foreach (var p in filtered)
        {
            Proposals.Add(p);
        }
    }

}
