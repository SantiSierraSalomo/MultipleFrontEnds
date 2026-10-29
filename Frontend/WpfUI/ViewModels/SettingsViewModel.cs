using CommunityToolkit.Mvvm.Input;

namespace WpfUI.ViewModels;

public class SettingsViewModel : WorkspaceViewModelBase
{
    private string _selectedTheme = "Light";
    private int _autoRefreshIntervalSeconds = 30;
    private int _pageSize = 50;
    private bool _enableNotifications = true;
    private bool _cacheApiResponses;
    private string? _statusMessage;

    public string[] AvailableThemes { get; } = ["Light", "Dark", "System Accent"];
    public int[] AvailablePageSizes { get; } = [10, 25, 50, 100];
    public IRelayCommand SaveSettingsCommand { get; }

    public string SelectedTheme
    {
        get => _selectedTheme;
        set => SetProperty(ref _selectedTheme, value);
    }

    public int AutoRefreshIntervalSeconds
    {
        get => _autoRefreshIntervalSeconds;
        set => SetProperty(ref _autoRefreshIntervalSeconds, value);
    }

    public int PageSize
    {
        get => _pageSize;
        set => SetProperty(ref _pageSize, value);
    }

    public bool EnableNotifications
    {
        get => _enableNotifications;
        set => SetProperty(ref _enableNotifications, value);
    }

    public bool CacheApiResponses
    {
        get => _cacheApiResponses;
        set => SetProperty(ref _cacheApiResponses, value);
    }

    public string? StatusMessage
    {
        get => _statusMessage;
        set => SetProperty(ref _statusMessage, value);
    }

    public SettingsViewModel()
    {
        Title = "Settings";
        SaveSettingsCommand = new RelayCommand(SaveSettings);
    }

    public void SaveSettings()
    {
        StatusMessage = "Settings saved successfully.";
    }
}
