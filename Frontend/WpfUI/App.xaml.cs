using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Windows;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using WpfUI.Configuration;
using WpfUI.Services;
using WpfUI.ViewModels;
using WpfUI.Views;

namespace WpfUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IHost? _host;

        protected override async void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            try
            {
                var builder = Host.CreateDefaultBuilder(e.Args)
                    .ConfigureAppConfiguration((context, config) =>
                    {
                        config.SetBasePath(AppContext.BaseDirectory);
                        config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                    })
                    .ConfigureServices((context, services) =>
                    {
                        // Bind and validate typed configuration
                        services.Configure<ApiSettings>(context.Configuration.GetSection(ApiSettings.SectionName));

                        // HTTP client with typed configuration
                        services.AddHttpClient<IApiClient, ApiClient>((serviceProvider, httpClient) =>
                        {
                            var settings = serviceProvider.GetRequiredService<IOptions<ApiSettings>>().Value;
                            httpClient.BaseAddress = new Uri(settings.BaseUrl.TrimEnd('/') + "/");
                        });

                        // ViewModels
                        services.AddSingleton<MainWindowViewModel>();
                        services.AddTransient<ItemsViewModel>();
                        services.AddTransient<WarehousesViewModel>();
                        services.AddTransient<ProposalEditingViewModel>();
                        services.AddTransient<SettingsViewModel>();
                        services.AddTransient<AboutViewModel>();
                        services.AddTransient<ContactViewModel>();

                        // Views
                        services.AddSingleton<MainWindow>();
                    });

                _host = builder.Build();

                // Validate configuration during startup and fail if invalid
                var apiSettings = _host.Services.GetRequiredService<IOptions<ApiSettings>>().Value;
                apiSettings.Validate();

                await _host.StartAsync();

                var apiClient = _host.Services.GetRequiredService<IApiClient>();
                using (var cts = new CancellationTokenSource(TimeSpan.FromSeconds(5)))
                {
                    await apiClient.HealthPingAsync(cts.Token);
                }

                var mainWindow = _host.Services.GetRequiredService<MainWindow>();
                mainWindow.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Application startup failed due to configuration or initialization error:\n\n{ex.Message}",
                    "Startup Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);

                Shutdown(-1);
            }
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            if (_host != null)
            {
                using (_host)
                {
                    await _host.StopAsync(TimeSpan.FromSeconds(5));
                }
            }

            base.OnExit(e);
        }
    }
}
