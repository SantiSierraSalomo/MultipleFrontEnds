using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace WpfUI.ViewModels;

public class AboutViewModel : WorkspaceViewModelBase
{
    public string ApplicationName { get; } = "Proposal Editor & Masterdata Shell";
    public string Version { get; }
    public string DotNetVersion { get; } = RuntimeInformation.FrameworkDescription;
    public string Architecture { get; } = RuntimeInformation.OSArchitecture.ToString();
    public string OperatingSystem { get; } = RuntimeInformation.OSDescription;
    public string Description { get; } = "Multi-window MDI desktop client simulation integrating REST endpoints for Items, Warehouses, and Proposals.";

    public AboutViewModel()
    {
        Title = "About";
        var assembly = Assembly.GetEntryAssembly() ?? Assembly.GetExecutingAssembly();
        Version = assembly.GetName().Version?.ToString() ?? "1.0.0";
    }
}
