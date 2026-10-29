using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace WpfUI.ViewModels;

public abstract class WorkspaceViewModelBase : ObservableObject
{
    private string _title = string.Empty;
    private bool _isBusy;
    private string? _errorMessage;

    protected WorkspaceViewModelBase()
    {
        CloseCommand = new RelayCommand(Close);
    }

    public string Title
    {
        get => _title;
        set => SetProperty(ref _title, value);
    }

    public bool IsBusy
    {
        get => _isBusy;
        set => SetProperty(ref _isBusy, value);
    }

    public string? ErrorMessage
    {
        get => _errorMessage;
        set => SetProperty(ref _errorMessage, value);
    }

    public IRelayCommand CloseCommand { get; }

    public event EventHandler? RequestClose;

    public void Close()
    {
        RequestClose?.Invoke(this, EventArgs.Empty);
    }
}
