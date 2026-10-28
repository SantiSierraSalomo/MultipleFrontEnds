namespace WinformsUI.Forms;

partial class MainForm
{
    private System.ComponentModel.IContainer components = null;

    private MenuStrip menuStrip;
    private ToolStripMenuItem fileMenuItem;
    private ToolStripMenuItem exitMenuItem;
    private ToolStripMenuItem masterdataMenuItem;
    private ToolStripMenuItem itemsMenuItem;
    private ToolStripMenuItem warehousesMenuItem;
    private ToolStripMenuItem proposalsMenuItem;
    private ToolStripMenuItem proposalEditingMenuItem;
    private ToolStripMenuItem toolsMenuItem;
    private ToolStripMenuItem settingsMenuItem;
    private ToolStripMenuItem windowMenuItem;
    private ToolStripMenuItem cascadeMenuItem;
    private ToolStripMenuItem tileHorizontalMenuItem;
    private ToolStripMenuItem tileVerticalMenuItem;
    private ToolStripSeparator windowSeparatorMenuItem;
    private ToolStripMenuItem closeAllMenuItem;
    private ToolStripMenuItem helpMenuItem;
    private ToolStripMenuItem aboutMenuItem;
    private ToolStripMenuItem contactMenuItem;
    private StatusStrip statusStrip;
    private ToolStripStatusLabel statusLabel;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();

        menuStrip = new MenuStrip();
        fileMenuItem = new ToolStripMenuItem();
        exitMenuItem = new ToolStripMenuItem();
        masterdataMenuItem = new ToolStripMenuItem();
        itemsMenuItem = new ToolStripMenuItem();
        warehousesMenuItem = new ToolStripMenuItem();
        proposalsMenuItem = new ToolStripMenuItem();
        proposalEditingMenuItem = new ToolStripMenuItem();
        toolsMenuItem = new ToolStripMenuItem();
        settingsMenuItem = new ToolStripMenuItem();
        windowMenuItem = new ToolStripMenuItem();
        cascadeMenuItem = new ToolStripMenuItem();
        tileHorizontalMenuItem = new ToolStripMenuItem();
        tileVerticalMenuItem = new ToolStripMenuItem();
        windowSeparatorMenuItem = new ToolStripSeparator();
        closeAllMenuItem = new ToolStripMenuItem();
        helpMenuItem = new ToolStripMenuItem();
        aboutMenuItem = new ToolStripMenuItem();
        contactMenuItem = new ToolStripMenuItem();

        statusStrip = new StatusStrip();
        statusLabel = new ToolStripStatusLabel();

        // 
        // menuStrip
        // 
        menuStrip.Items.AddRange(new ToolStripItem[]
        {
            fileMenuItem,
            masterdataMenuItem,
            proposalsMenuItem,
            toolsMenuItem,
            windowMenuItem,
            helpMenuItem
        });
        menuStrip.Location = new Point(0, 0);
        menuStrip.Name = "menuStrip";
        menuStrip.Size = new Size(1008, 24);
        menuStrip.TabIndex = 0;
        menuStrip.Text = "Main Menu";

        // File Menu
        fileMenuItem.DropDownItems.AddRange(new ToolStripItem[] { exitMenuItem });
        fileMenuItem.Name = "fileMenuItem";
        fileMenuItem.Text = "&File";

        exitMenuItem.Name = "exitMenuItem";
        exitMenuItem.ShortcutKeys = Keys.Alt | Keys.F4;
        exitMenuItem.Text = "E&xit";
        exitMenuItem.Click += OnExitMenuItemClick;

        // Masterdata Menu
        masterdataMenuItem.DropDownItems.AddRange(new ToolStripItem[]
        {
            itemsMenuItem,
            warehousesMenuItem
        });
        masterdataMenuItem.Name = "masterdataMenuItem";
        masterdataMenuItem.Text = "&Masterdata";

        itemsMenuItem.Name = "itemsMenuItem";
        itemsMenuItem.Text = "&Items";
        itemsMenuItem.Click += OnItemsMenuItemClick;

        warehousesMenuItem.Name = "warehousesMenuItem";
        warehousesMenuItem.Text = "&Warehouses";
        warehousesMenuItem.Click += OnWarehousesMenuItemClick;

        // Proposals Menu
        proposalsMenuItem.DropDownItems.AddRange(new ToolStripItem[]
        {
            proposalEditingMenuItem
        });
        proposalsMenuItem.Name = "proposalsMenuItem";
        proposalsMenuItem.Text = "&Proposals";

        proposalEditingMenuItem.Name = "proposalEditingMenuItem";
        proposalEditingMenuItem.Text = "Proposal &Editing";
        proposalEditingMenuItem.Click += OnProposalEditingMenuItemClick;

        // Tools Menu
        toolsMenuItem.DropDownItems.AddRange(new ToolStripItem[]
        {
            settingsMenuItem
        });
        toolsMenuItem.Name = "toolsMenuItem";
        toolsMenuItem.Text = "&Tools";

        settingsMenuItem.Name = "settingsMenuItem";
        settingsMenuItem.Text = "&Settings";
        settingsMenuItem.Click += OnSettingsMenuItemClick;

        // Window Menu
        windowMenuItem.DropDownItems.AddRange(new ToolStripItem[]
        {
            cascadeMenuItem,
            tileHorizontalMenuItem,
            tileVerticalMenuItem,
            windowSeparatorMenuItem,
            closeAllMenuItem
        });
        windowMenuItem.Name = "windowMenuItem";
        windowMenuItem.Text = "&Window";

        cascadeMenuItem.Name = "cascadeMenuItem";
        cascadeMenuItem.Text = "&Cascade";
        cascadeMenuItem.Click += OnCascadeWindowsClick;

        tileHorizontalMenuItem.Name = "tileHorizontalMenuItem";
        tileHorizontalMenuItem.Text = "Tile &Horizontal";
        tileHorizontalMenuItem.Click += OnTileHorizontalClick;

        tileVerticalMenuItem.Name = "tileVerticalMenuItem";
        tileVerticalMenuItem.Text = "Tile &Vertical";
        tileVerticalMenuItem.Click += OnTileVerticalClick;

        closeAllMenuItem.Name = "closeAllMenuItem";
        closeAllMenuItem.Text = "C&lose All Windows";
        closeAllMenuItem.Click += OnCloseAllWindowsClick;

        // Help Menu
        helpMenuItem.DropDownItems.AddRange(new ToolStripItem[]
        {
            aboutMenuItem,
            contactMenuItem
        });
        helpMenuItem.Name = "helpMenuItem";
        helpMenuItem.Text = "&Help";

        aboutMenuItem.Name = "aboutMenuItem";
        aboutMenuItem.Text = "&About";
        aboutMenuItem.Click += OnAboutMenuItemClick;

        contactMenuItem.Name = "contactMenuItem";
        contactMenuItem.Text = "&Contact";
        contactMenuItem.Click += OnContactMenuItemClick;

        // 
        // statusStrip
        // 
        statusStrip.Items.AddRange(new ToolStripItem[] { statusLabel });
        statusStrip.Location = new Point(0, 699);
        statusStrip.Name = "statusStrip";
        statusStrip.Size = new Size(1008, 22);
        statusStrip.TabIndex = 1;

        statusLabel.Name = "statusLabel";
        statusLabel.Size = new Size(39, 17);
        statusLabel.Text = "Ready";

        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1008, 721);
        Controls.Add(statusStrip);
        Controls.Add(menuStrip);
        IsMdiContainer = true;
        MainMenuStrip = menuStrip;
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Proposal Editor - MDI Application";

        menuStrip.ResumeLayout(false);
        menuStrip.PerformLayout();
        statusStrip.ResumeLayout(false);
        statusStrip.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }
}
