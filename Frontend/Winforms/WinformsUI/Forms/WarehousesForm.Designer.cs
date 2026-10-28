namespace WinformsUI.Forms;

partial class WarehousesForm
{
    private System.ComponentModel.IContainer components = null;

    private Panel topPanel;
    private Button btnRefresh;
    private Label lblStatus;
    private DataGridView dataGridViewWarehouses;

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
        topPanel = new Panel();
        btnRefresh = new Button();
        lblStatus = new Label();
        dataGridViewWarehouses = new DataGridView();

        // 
        // topPanel
        // 
        topPanel.Dock = DockStyle.Top;
        topPanel.Height = 50;
        topPanel.Controls.Add(btnRefresh);
        topPanel.Controls.Add(lblStatus);

        // 
        // btnRefresh
        // 
        btnRefresh.Location = new Point(12, 12);
        btnRefresh.Name = "btnRefresh";
        btnRefresh.Size = new Size(100, 28);
        btnRefresh.TabIndex = 0;
        btnRefresh.Text = "&Refresh";
        btnRefresh.UseVisualStyleBackColor = true;
        btnRefresh.Click += OnRefreshClick;

        // 
        // lblStatus
        // 
        lblStatus.AutoSize = true;
        lblStatus.Location = new Point(125, 19);
        lblStatus.Name = "lblStatus";
        lblStatus.Size = new Size(42, 15);
        lblStatus.TabIndex = 1;
        lblStatus.Text = "Ready";

        // 
        // dataGridViewWarehouses
        // 
        dataGridViewWarehouses.AllowUserToAddRows = false;
        dataGridViewWarehouses.AllowUserToDeleteRows = false;
        dataGridViewWarehouses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridViewWarehouses.Dock = DockStyle.Fill;
        dataGridViewWarehouses.Location = new Point(0, 50);
        dataGridViewWarehouses.Name = "dataGridViewWarehouses";
        dataGridViewWarehouses.ReadOnly = true;
        dataGridViewWarehouses.Size = new Size(784, 411);
        dataGridViewWarehouses.TabIndex = 1;

        // 
        // WarehousesForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(784, 461);
        Controls.Add(dataGridViewWarehouses);
        Controls.Add(topPanel);
        Name = "WarehousesForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Masterdata - Warehouses";
        Load += WarehousesForm_Load;

        topPanel.ResumeLayout(false);
        topPanel.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dataGridViewWarehouses).EndInit();
        ResumeLayout(false);
    }
}
