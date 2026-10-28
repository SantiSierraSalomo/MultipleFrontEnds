using WinformsUI.Models;
using WinformsUI.Services;

namespace WinformsUI.Forms;

public partial class WarehousesForm : Form
{
    private readonly IWarehousesApiClient _warehousesApiClient;
    private readonly BindingSource _bindingSource = new();

    public WarehousesForm(IWarehousesApiClient warehousesApiClient)
    {
        _warehousesApiClient = warehousesApiClient;
        InitializeComponent();
        SetupGrid();
    }

    private void SetupGrid()
    {
        dataGridViewWarehouses.AutoGenerateColumns = true;
        dataGridViewWarehouses.DataSource = _bindingSource;
    }

    private async void WarehousesForm_Load(object? sender, EventArgs e)
    {
        await LoadWarehousesAsync();
    }

    private async void OnRefreshClick(object? sender, EventArgs e)
    {
        await LoadWarehousesAsync();
    }

    private async Task LoadWarehousesAsync()
    {
        btnRefresh.Enabled = false;
        lblStatus.Text = "Loading warehouses from /api/Warehouses...";
        try
        {
            var warehouses = await _warehousesApiClient.GetAllAsync();
            _bindingSource.DataSource = warehouses;
            lblStatus.Text = $"Loaded {warehouses.Count} warehouse(s) successfully.";
        }
        catch (Exception ex)
        {
            lblStatus.Text = "Error loading warehouses.";
            MessageBox.Show(
                $"Failed to load warehouses from WebAPI:{Environment.NewLine}{ex.Message}",
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
