using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;

namespace WpfUI.ViewModels;

public class MainWindowViewModel : ObservableObject
{
    private readonly IServiceProvider _serviceProvider;
    private WorkspaceViewModelBase? _activeWorkspace;

    public ObservableCollection<WorkspaceViewModelBase> Workspaces { get; } = new();
    public IAsyncRelayCommand OpenItemsCommand { get; }
    public IAsyncRelayCommand OpenWarehousesCommand { get; }
    public IAsyncRelayCommand OpenProposalEditingCommand { get; }
    public IAsyncRelayCommand OpenSettingsCommand { get; }
    public IAsyncRelayCommand OpenAboutCommand { get; }
    public IAsyncRelayCommand OpenContactCommand { get; }
    public IRelayCommand<WorkspaceViewModelBase?> CloseWorkspaceCommand { get; }
    public IRelayCommand CloseAllWorkspacesCommand { get; }

    public WorkspaceViewModelBase? ActiveWorkspace
    {
        get => _activeWorkspace;
        set => SetProperty(ref _activeWorkspace, value);
    }

    public MainWindowViewModel(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        OpenItemsCommand = new AsyncRelayCommand(OpenItemsAsync);
        OpenWarehousesCommand = new AsyncRelayCommand(OpenWarehousesAsync);
        OpenProposalEditingCommand = new AsyncRelayCommand(OpenProposalEditingAsync);
        OpenSettingsCommand = new AsyncRelayCommand(OpenSettingsAsync);
        OpenAboutCommand = new AsyncRelayCommand(OpenAboutAsync);
        OpenContactCommand = new AsyncRelayCommand(OpenContactAsync);
        CloseWorkspaceCommand = new RelayCommand<WorkspaceViewModelBase?>(CloseWorkspace);
        CloseAllWorkspacesCommand = new RelayCommand(CloseAllWorkspaces);
    }

    public async Task InitializeDefaultWorkspaceAsync()
    {
        // Open ProposalEditing as the default main form
        await OpenWorkspaceAsync<ProposalEditingViewModel>();
    }

    public async Task OpenItemsAsync()
    {
        var vm = await OpenWorkspaceAsync<ItemsViewModel>();
        if (vm.Items.Count == 0)
        {
            await vm.RefreshAsync();
        }
    }

    public async Task OpenWarehousesAsync()
    {
        var vm = await OpenWorkspaceAsync<WarehousesViewModel>();
        if (vm.Warehouses.Count == 0)
        {
            await vm.RefreshAsync();
        }
    }

    public async Task OpenProposalEditingAsync()
    {
        await OpenWorkspaceAsync<ProposalEditingViewModel>();
    }

    public async Task OpenSettingsAsync()
    {
        await OpenWorkspaceAsync<SettingsViewModel>();
    }

    public async Task OpenAboutAsync()
    {
        await OpenWorkspaceAsync<AboutViewModel>();
    }

    public async Task OpenContactAsync()
    {
        await OpenWorkspaceAsync<ContactViewModel>();
    }

    public void CloseWorkspace(WorkspaceViewModelBase? workspace)
    {
        if (workspace == null)
        {
            return;
        }

        workspace.RequestClose -= OnWorkspaceRequestClose;
        Workspaces.Remove(workspace);

        if (ActiveWorkspace == workspace)
        {
            ActiveWorkspace = Workspaces.LastOrDefault();
        }
    }

    public void CloseAllWorkspaces()
    {
        foreach (var ws in Workspaces.ToList())
        {
            CloseWorkspace(ws);
        }
    }

    private Task<T> OpenWorkspaceAsync<T>() where T : WorkspaceViewModelBase
    {
        var existing = Workspaces.OfType<T>().FirstOrDefault();
        if (existing != null)
        {
            ActiveWorkspace = existing;
            return Task.FromResult(existing);
        }

        var workspace = _serviceProvider.GetRequiredService<T>();
        workspace.RequestClose += OnWorkspaceRequestClose;
        Workspaces.Add(workspace);
        ActiveWorkspace = workspace;
        return Task.FromResult(workspace);
    }

    private void OnWorkspaceRequestClose(object? sender, EventArgs e)
    {
        if (sender is WorkspaceViewModelBase workspace)
        {
            CloseWorkspace(workspace);
        }
    }
}
