using WinformsUI.Services;

namespace WinformsUI.Forms;

public partial class MainForm : Form
{
    private readonly IMdiChildManager _mdiChildManager;

    public MainForm(IMdiChildManager mdiChildManager)
    {
        _mdiChildManager = mdiChildManager;
        InitializeComponent();
    }

    private void OnItemsMenuItemClick(object? sender, EventArgs e)
    {
        _mdiChildManager.ShowChildForm<ItemsForm>(this);
    }

    private void OnWarehousesMenuItemClick(object? sender, EventArgs e)
    {
        _mdiChildManager.ShowChildForm<WarehousesForm>(this);
    }

    private void OnProposalEditingMenuItemClick(object? sender, EventArgs e)
    {
        _mdiChildManager.ShowChildForm<ProposalEditingForm>(this);
    }

    private void OnSettingsMenuItemClick(object? sender, EventArgs e)
    {
        _mdiChildManager.ShowChildForm<SettingsForm>(this);
    }

    private void OnAboutMenuItemClick(object? sender, EventArgs e)
    {
        _mdiChildManager.ShowChildForm<AboutForm>(this);
    }

    private void OnContactMenuItemClick(object? sender, EventArgs e)
    {
        _mdiChildManager.ShowChildForm<ContactForm>(this);
    }

    private void OnExitMenuItemClick(object? sender, EventArgs e)
    {
        Close();
    }

    private void OnCascadeWindowsClick(object? sender, EventArgs e)
    {
        LayoutMdi(MdiLayout.Cascade);
    }

    private void OnTileHorizontalClick(object? sender, EventArgs e)
    {
        LayoutMdi(MdiLayout.TileHorizontal);
    }

    private void OnTileVerticalClick(object? sender, EventArgs e)
    {
        LayoutMdi(MdiLayout.TileVertical);
    }

    private void OnCloseAllWindowsClick(object? sender, EventArgs e)
    {
        foreach (var child in MdiChildren)
        {
            child.Close();
        }
    }
}
