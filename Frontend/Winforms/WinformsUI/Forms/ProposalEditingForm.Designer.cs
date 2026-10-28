namespace WinformsUI.Forms;

partial class ProposalEditingForm
{
    private System.ComponentModel.IContainer components = null;

    private GroupBox grpFilters;
    private Label lblItem;
    private ComboBox comboItem;
    private Label lblWarehouse;
    private ComboBox comboWarehouse;
    private Label lblProposalIndex;
    private ComboBox comboProposalIndex;
    private Button btnShowData;
    private Label lblStatus;
    private DataGridView dataGridViewProposals;

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
        grpFilters = new GroupBox();
        lblItem = new Label();
        comboItem = new ComboBox();
        lblWarehouse = new Label();
        comboWarehouse = new ComboBox();
        lblProposalIndex = new Label();
        comboProposalIndex = new ComboBox();
        btnShowData = new Button();
        lblStatus = new Label();
        dataGridViewProposals = new DataGridView();

        // 
        // grpFilters
        // 
        grpFilters.Dock = DockStyle.Top;
        grpFilters.Height = 110;
        grpFilters.Text = "Filter Proposals";
        grpFilters.Controls.Add(lblItem);
        grpFilters.Controls.Add(comboItem);
        grpFilters.Controls.Add(lblWarehouse);
        grpFilters.Controls.Add(comboWarehouse);
        grpFilters.Controls.Add(lblProposalIndex);
        grpFilters.Controls.Add(comboProposalIndex);
        grpFilters.Controls.Add(btnShowData);
        grpFilters.Controls.Add(lblStatus);

        // lblItem
        lblItem.AutoSize = true;
        lblItem.Location = new Point(16, 28);
        lblItem.Name = "lblItem";
        lblItem.Text = "Item:";

        // comboItem
        comboItem.DropDownStyle = ComboBoxStyle.DropDownList;
        comboItem.FormattingEnabled = true;
        comboItem.Location = new Point(55, 25);
        comboItem.Name = "comboItem";
        comboItem.Size = new Size(220, 23);
        comboItem.TabIndex = 0;

        // lblWarehouse
        lblWarehouse.AutoSize = true;
        lblWarehouse.Location = new Point(295, 28);
        lblWarehouse.Name = "lblWarehouse";
        lblWarehouse.Text = "Warehouse:";

        // comboWarehouse
        comboWarehouse.DropDownStyle = ComboBoxStyle.DropDownList;
        comboWarehouse.FormattingEnabled = true;
        comboWarehouse.Location = new Point(370, 25);
        comboWarehouse.Name = "comboWarehouse";
        comboWarehouse.Size = new Size(200, 23);
        comboWarehouse.TabIndex = 1;

        // lblProposalIndex
        lblProposalIndex.AutoSize = true;
        lblProposalIndex.Location = new Point(590, 28);
        lblProposalIndex.Name = "lblProposalIndex";
        lblProposalIndex.Text = "Proposal Index:";

        // comboProposalIndex
        comboProposalIndex.DropDownStyle = ComboBoxStyle.DropDownList;
        comboProposalIndex.FormattingEnabled = true;
        comboProposalIndex.Location = new Point(685, 25);
        comboProposalIndex.Name = "comboProposalIndex";
        comboProposalIndex.Size = new Size(130, 23);
        comboProposalIndex.TabIndex = 2;

        // btnShowData
        btnShowData.Location = new Point(16, 65);
        btnShowData.Name = "btnShowData";
        btnShowData.Size = new Size(120, 30);
        btnShowData.TabIndex = 3;
        btnShowData.Text = "&Show Data";
        btnShowData.UseVisualStyleBackColor = true;
        btnShowData.Click += OnShowDataClick;

        // lblStatus
        lblStatus.AutoSize = true;
        lblStatus.Location = new Point(150, 73);
        lblStatus.Name = "lblStatus";
        lblStatus.Text = "Ready";

        // 
        // dataGridViewProposals
        // 
        dataGridViewProposals.AllowUserToAddRows = false;
        dataGridViewProposals.AllowUserToDeleteRows = false;
        dataGridViewProposals.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridViewProposals.Dock = DockStyle.Fill;
        dataGridViewProposals.Location = new Point(0, 110);
        dataGridViewProposals.Name = "dataGridViewProposals";
        dataGridViewProposals.ReadOnly = true;
        dataGridViewProposals.Size = new Size(884, 451);
        dataGridViewProposals.TabIndex = 4;

        // 
        // ProposalEditingForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(884, 561);
        Controls.Add(dataGridViewProposals);
        Controls.Add(grpFilters);
        Name = "ProposalEditingForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Proposal Editing";
        Load += ProposalEditingForm_Load;

        grpFilters.ResumeLayout(false);
        grpFilters.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dataGridViewProposals).EndInit();
        ResumeLayout(false);
    }
}
