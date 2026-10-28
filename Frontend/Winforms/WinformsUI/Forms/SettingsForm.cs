using Microsoft.Extensions.Options;
using WinformsUI.Configuration;

namespace WinformsUI.Forms;

public partial class SettingsForm : Form
{
    private readonly ApiSettings _apiSettings;

    public SettingsForm(IOptions<ApiSettings> apiOptions)
    {
        _apiSettings = apiOptions.Value;
        InitializeComponent();
        LoadInitialSettings();
    }

    private void LoadInitialSettings()
    {
        txtApiBaseUrl.Text = _apiSettings.BaseUrl;
        comboTheme.SelectedIndex = 0; // Light
        chkAutoRefresh.Checked = true;
        numRefreshInterval.Value = 30;
        numPageSize.Value = 50;
        comboLogLevel.SelectedIndex = 1; // Information
    }

    private void OnSaveClick(object? sender, EventArgs e)
    {
        MessageBox.Show(
            "Settings saved successfully.",
            "Settings",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
        Close();
    }

    private void OnCancelClick(object? sender, EventArgs e)
    {
        Close();
    }
}
