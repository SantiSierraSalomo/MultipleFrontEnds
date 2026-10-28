using WinformsUI.Models;
using WinformsUI.Services;

namespace WinformsUI.Forms;

public partial class ItemsForm : Form
{
    private readonly IItemsApiClient _itemsApiClient;
    private readonly BindingSource _bindingSource = new();

    public ItemsForm(IItemsApiClient itemsApiClient)
    {
        _itemsApiClient = itemsApiClient;
        InitializeComponent();
        SetupGrid();
    }

    private void SetupGrid()
    {
        dataGridViewItems.AutoGenerateColumns = true;
        dataGridViewItems.DataSource = _bindingSource;
    }

    private async void ItemsForm_Load(object? sender, EventArgs e)
    {
        await LoadItemsAsync();
    }

    private async void OnRefreshClick(object? sender, EventArgs e)
    {
        await LoadItemsAsync();
    }

    private async Task LoadItemsAsync()
    {
        btnRefresh.Enabled = false;
        lblStatus.Text = "Loading items from /api/items...";
        try
        {
            var items = await _itemsApiClient.GetAllAsync();
            _bindingSource.DataSource = items;
            lblStatus.Text = $"Loaded {items.Count} item(s) successfully.";
        }
        catch (Exception ex)
        {
            lblStatus.Text = "Error loading items.";
            MessageBox.Show(
                $"Failed to load items from WebAPI:{Environment.NewLine}{ex.Message}",
                "API Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
        finally
        {
            btnRefresh.Enabled = true;
        }
    }
}
