using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using WinformsUI.Configuration;
using WinformsUI.Forms;
using WinformsUI.Services;

namespace WinformsUI;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        // 1. Build configuration
        var configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();

        // 2. Validate configuration at startup
        var apiSettings = new ApiSettings();
        configuration.GetSection(ApiSettings.SectionName).Bind(apiSettings);

        var validationContext = new ValidationContext(apiSettings);
        var validationResults = new List<ValidationResult>();
        bool isValid = Validator.TryValidateObject(apiSettings, validationContext, validationResults, validateAllProperties: true);

        if (!isValid || string.IsNullOrWhiteSpace(apiSettings.BaseUrl) || !Uri.TryCreate(apiSettings.BaseUrl, UriKind.Absolute, out var validatedUri))
        {
            var errors = string.Join(Environment.NewLine, validationResults.Select(r => $"• {r.ErrorMessage}"));
            if (!Uri.TryCreate(apiSettings.BaseUrl, UriKind.Absolute, out _))
            {
                errors += $"{Environment.NewLine}• ApiSettings:BaseUrl '{apiSettings.BaseUrl}' is not a valid absolute URI.";
            }

            MessageBox.Show(
                $"Configuration validation failed on startup:{Environment.NewLine}{Environment.NewLine}{errors}{Environment.NewLine}{Environment.NewLine}The application will now terminate.",
                "Startup Configuration Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            return;
        }

        // 3. Build ServiceCollection and register DI services
        var services = new ServiceCollection();

        services.AddSingleton<IConfiguration>(configuration);
        services.Configure<ApiSettings>(configuration.GetSection(ApiSettings.SectionName));

        // Register typed HttpClients with BaseAddress
        services.AddHttpClient<IItemsApiClient, ItemsApiClient>(client =>
        {
            client.BaseAddress = validatedUri;
        });

        services.AddHttpClient<IWarehousesApiClient, WarehousesApiClient>(client =>
        {
            client.BaseAddress = validatedUri;
        });

        services.AddHttpClient<IProposalsApiClient, ProposalsApiClient>(client =>
        {
            client.BaseAddress = validatedUri;
        });

        // Register MDI Child Manager
        services.AddSingleton<IMdiChildManager, MdiChildManager>();

        // Register Forms
        services.AddSingleton<MainForm>();
        services.AddTransient<ItemsForm>();
        services.AddTransient<WarehousesForm>();
        services.AddTransient<ProposalEditingForm>();
        services.AddTransient<SettingsForm>();
        services.AddTransient<AboutForm>();
        services.AddTransient<ContactForm>();

        var serviceProvider = services.BuildServiceProvider();

        // 4. Run MainForm
        var mainForm = serviceProvider.GetRequiredService<MainForm>();
        Application.Run(mainForm);
    }
}