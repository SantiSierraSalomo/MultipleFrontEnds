using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using WpfUI.Models;
using WpfUI.Services;

namespace WpfUI.ViewModels;

public class ContactViewModel : WorkspaceViewModelBase
{
    private readonly IApiClient _apiClient;
    private string _name = string.Empty;
    private string _email = string.Empty;
    private string _subject = string.Empty;
    private string _message = string.Empty;
    private string? _statusSuccessMessage;

    public string Name
    {
        get => _name;
        set => SetProperty(ref _name, value);
    }

    public string Email
    {
        get => _email;
        set => SetProperty(ref _email, value);
    }

    public string Subject
    {
        get => _subject;
        set => SetProperty(ref _subject, value);
    }

    public string Message
    {
        get => _message;
        set => SetProperty(ref _message, value);
    }

    public string? StatusSuccessMessage
    {
        get => _statusSuccessMessage;
        set => SetProperty(ref _statusSuccessMessage, value);
    }

    public IAsyncRelayCommand SendCommand { get; }

    public ContactViewModel(IApiClient apiClient)
    {
        _apiClient = apiClient;
        Title = "Contact";
        SendCommand = new AsyncRelayCommand(SendAsync);
    }

    public async Task SendAsync()
    {
        if (IsBusy)
        {
            return;
        }

        ErrorMessage = null;
        StatusSuccessMessage = null;

        if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Message))
        {
            ErrorMessage = "Please fill in all required fields (Name, Email, and Message).";
            return;
        }

        try
        {
            IsBusy = true;
            await _apiClient.SendContactMessageAsync(new ContactMessage(Name, Email, Subject, Message));
            StatusSuccessMessage = "Thank you! Your message has been sent successfully.";
            Name = string.Empty;
            Email = string.Empty;
            Subject = string.Empty;
            Message = string.Empty;
        }
        catch (Exception ex)
        {
            ErrorMessage = $"Failed to send message: {ex.Message}";
        }
        finally
        {
            IsBusy = false;
        }
    }
}
