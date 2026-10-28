using WinformsUI.Models;
using WinformsUI.Services;

namespace WinformsUI.Forms;

public partial class ProposalEditingForm : Form
{
    private readonly IProposalsApiClient _proposalsApiClient;
    private readonly IItemsApiClient _itemsApiClient;
    private readonly IWarehousesApiClient _warehousesApiClient;
    private readonly BindingSource _bindingSource = new();

    private List<ProposalModel> _allProposals = [];

    public ProposalEditingForm(
        IProposalsApiClient proposalsApiClient,
        IItemsApiClient itemsApiClient,
        IWarehousesApiClient warehousesApiClient)
    {
        _proposalsApiClient = proposalsApiClient;
        _itemsApiClient = itemsApiClient;
        _warehousesApiClient = warehousesApiClient;

        InitializeComponent();
        SetupGrid();
    }

    private void SetupGrid()
    {
        dataGridViewProposals.AutoGenerateColumns = true;
        dataGridViewProposals.DataSource = _bindingSource;
    }

    private async void ProposalEditingForm_Load(object? sender, EventArgs e)
    {
        await LoadLookupDataAsync();
    }

    private async Task LoadLookupDataAsync()
    {
        lblStatus.Text = "Loading filter lookup options...";
        try
        {
            var itemsTask = _itemsApiClient.GetAllAsync();
            var warehousesTask = _warehousesApiClient.GetAllAsync();

            await Task.WhenAll(itemsTask, warehousesTask);

            var items = await itemsTask;
            var warehouses = await warehousesTask;

            // Populate Items ComboBox (with All option)
            comboItem.Items.Clear();
            comboItem.Items.Add("(All Items)");
            foreach (var item in items)
            {
                var label = string.IsNullOrWhiteSpace(item.Description)
                    ? item.ItemId
                    : $"{item.ItemId} - {item.Description}";
                comboItem.Items.Add(label);
            }
            comboItem.SelectedIndex = 0;

            // Populate Warehouses ComboBox (with All option)
            comboWarehouse.Items.Clear();
            comboWarehouse.Items.Add("(All Warehouses)");
            foreach (var wh in warehouses)
            {
                var label = string.IsNullOrWhiteSpace(wh.Description)
                    ? wh.WarehouseId
                    : $"{wh.WarehouseId} - {wh.Description}";
                comboWarehouse.Items.Add(label);
            }
            comboWarehouse.SelectedIndex = 0;

            // Populate ProposalIndex ComboBox
            comboProposalIndex.Items.Clear();
            comboProposalIndex.Items.Add("(All Indices)");
            for (int i = 1; i <= 20; i++)
            {
                comboProposalIndex.Items.Add(i.ToString());
            }
            comboProposalIndex.SelectedIndex = 0;

            lblStatus.Text = "Lookup options loaded. Ready to query proposals.";
        }
        catch (Exception ex)
        {
            lblStatus.Text = "Failed loading filter lookups.";
            MessageBox.Show(
                $"Error loading lookup data:{Environment.NewLine}{ex.Message}",
                "API Warning",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }
    }

    private async void OnShowDataClick(object? sender, EventArgs e)
    {
        btnShowData.Enabled = false;
        lblStatus.Text = "Calling /api/Proposals...";
        try
        {
            _allProposals = await _proposalsApiClient.GetAllAsync();

            // Extract selected filter values
            string? selectedItemPrefix = null;
            if (comboItem.SelectedIndex > 0)
            {
                var text = comboItem.SelectedItem?.ToString() ?? string.Empty;
                selectedItemPrefix = text.Split(" - ")[0].Trim();
            }

            string? selectedWarehousePrefix = null;
            if (comboWarehouse.SelectedIndex > 0)
            {
                var text = comboWarehouse.SelectedItem?.ToString() ?? string.Empty;
                selectedWarehousePrefix = text.Split(" - ")[0].Trim();
            }

            int? selectedIndex = null;
            if (comboProposalIndex.SelectedIndex > 0 && int.TryParse(comboProposalIndex.SelectedItem?.ToString(), out var idx))
            {
                selectedIndex = idx;
            }

            // Filter data
            var filtered = _allProposals.AsEnumerable();

            if (!string.IsNullOrEmpty(selectedItemPrefix))
            {
                filtered = filtered.Where(p => string.Equals(p.ItemId, selectedItemPrefix, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrEmpty(selectedWarehousePrefix))
            {
                filtered = filtered.Where(p => string.Equals(p.WarehouseId, selectedWarehousePrefix, StringComparison.OrdinalIgnoreCase));
            }

            if (selectedIndex.HasValue)
            {
                filtered = filtered.Where(p => p.ProposalIndex == selectedIndex.Value);
            }

            var resultList = filtered.ToList();
            _bindingSource.DataSource = resultList;

            lblStatus.Text = $"Showing {resultList.Count} proposal(s) (Total fetched from /api/Proposals: {_allProposals.Count}).";
        }
        catch (Exception ex)
        {
            lblStatus.Text = "Error loading proposals.";
            MessageBox.Show(
                $"Failed to load proposals from WebAPI:{Environment.NewLine}{ex.Message}",
                "API Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
        finally
        {
            btnShowData.Enabled = true;
        }
    }
}
