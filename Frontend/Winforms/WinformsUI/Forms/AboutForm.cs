using Microsoft.Extensions.Options;
using WinformsUI.Configuration;

namespace WinformsUI.Forms;

public partial class AboutForm : Form
{
    public AboutForm(IOptions<ApiSettings> apiOptions)
    {
        InitializeComponent();
        lblApiUrlValue.Text = apiOptions.Value.BaseUrl;
    }

    private void OnCloseClick(object? sender, EventArgs e)
    {
        Close();
    }
}
