namespace WinformsUI.Forms;

partial class SettingsForm
{
    private System.ComponentModel.IContainer components = null;

    private Label lblApiBaseUrl;
    private TextBox txtApiBaseUrl;
    private Label lblTheme;
    private ComboBox comboTheme;
    private CheckBox chkAutoRefresh;
    private Label lblRefreshInterval;
    private NumericUpDown numRefreshInterval;
    private Label lblPageSize;
    private NumericUpDown numPageSize;
    private Label lblLogLevel;
    private ComboBox comboLogLevel;
    private Button btnSave;
    private Button btnCancel;

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
        lblApiBaseUrl = new Label();
        txtApiBaseUrl = new TextBox();
        lblTheme = new Label();
        comboTheme = new ComboBox();
        chkAutoRefresh = new CheckBox();
        lblRefreshInterval = new Label();
        numRefreshInterval = new NumericUpDown();
        lblPageSize = new Label();
        numPageSize = new NumericUpDown();
        lblLogLevel = new Label();
        comboLogLevel = new ComboBox();
        btnSave = new Button();
        btnCancel = new Button();

        ((System.ComponentModel.ISupportInitialize)numRefreshInterval).BeginInit();
        ((System.ComponentModel.ISupportInitialize)numPageSize).BeginInit();
        SuspendLayout();

        // lblApiBaseUrl
        lblApiBaseUrl.AutoSize = true;
        lblApiBaseUrl.Location = new Point(20, 25);
        lblApiBaseUrl.Name = "lblApiBaseUrl";
        lblApiBaseUrl.Text = "API Base URL:";

        // txtApiBaseUrl
        txtApiBaseUrl.Location = new Point(160, 22);
        txtApiBaseUrl.Name = "txtApiBaseUrl";
        txtApiBaseUrl.ReadOnly = true;
        txtApiBaseUrl.Size = new Size(260, 23);
        txtApiBaseUrl.TabIndex = 0;

        // lblTheme
        lblTheme.AutoSize = true;
        lblTheme.Location = new Point(20, 65);
        lblTheme.Name = "lblTheme";
        lblTheme.Text = "Application Theme:";

        // comboTheme
        comboTheme.DropDownStyle = ComboBoxStyle.DropDownList;
        comboTheme.Items.AddRange(new object[] { "Light (Default)", "Dark", "System Accent" });
        comboTheme.Location = new Point(160, 62);
        comboTheme.Name = "comboTheme";
        comboTheme.Size = new Size(260, 23);
        comboTheme.TabIndex = 1;

        // chkAutoRefresh
        chkAutoRefresh.AutoSize = true;
        chkAutoRefresh.Location = new Point(20, 105);
        chkAutoRefresh.Name = "chkAutoRefresh";
        chkAutoRefresh.Size = new Size(169, 19);
        chkAutoRefresh.TabIndex = 2;
        chkAutoRefresh.Text = "Enable Auto-Refresh on Load";
        chkAutoRefresh.UseVisualStyleBackColor = true;

        // lblRefreshInterval
        lblRefreshInterval.AutoSize = true;
        lblRefreshInterval.Location = new Point(20, 145);
        lblRefreshInterval.Name = "lblRefreshInterval";
        lblRefreshInterval.Text = "Polling Interval (sec):";

        // numRefreshInterval
        numRefreshInterval.Location = new Point(160, 143);
        numRefreshInterval.Maximum = new decimal(new int[] { 300, 0, 0, 0 });
        numRefreshInterval.Minimum = new decimal(new int[] { 5, 0, 0, 0 });
        numRefreshInterval.Name = "numRefreshInterval";
        numRefreshInterval.Size = new Size(120, 23);
        numRefreshInterval.TabIndex = 3;
        numRefreshInterval.Value = new decimal(new int[] { 30, 0, 0, 0 });

        // lblPageSize
        lblPageSize.AutoSize = true;
        lblPageSize.Location = new Point(20, 185);
        lblPageSize.Name = "lblPageSize";
        lblPageSize.Text = "Default Page Size:";

        // numPageSize
        numPageSize.Location = new Point(160, 183);
        numPageSize.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
        numPageSize.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
        numPageSize.Name = "numPageSize";
        numPageSize.Size = new Size(120, 23);
        numPageSize.TabIndex = 4;
        numPageSize.Value = new decimal(new int[] { 50, 0, 0, 0 });

        // lblLogLevel
        lblLogLevel.AutoSize = true;
        lblLogLevel.Location = new Point(20, 225);
        lblLogLevel.Name = "lblLogLevel";
        lblLogLevel.Text = "Logging Level:";

        // comboLogLevel
        comboLogLevel.DropDownStyle = ComboBoxStyle.DropDownList;
        comboLogLevel.Items.AddRange(new object[] { "Debug", "Information", "Warning", "Error" });
        comboLogLevel.Location = new Point(160, 222);
        comboLogLevel.Name = "comboLogLevel";
        comboLogLevel.Size = new Size(260, 23);
        comboLogLevel.TabIndex = 5;

        // btnSave
        btnSave.Location = new Point(240, 280);
        btnSave.Name = "btnSave";
        btnSave.Size = new Size(85, 30);
        btnSave.TabIndex = 6;
        btnSave.Text = "&Save";
        btnSave.UseVisualStyleBackColor = true;
        btnSave.Click += OnSaveClick;

        // btnCancel
        btnCancel.Location = new Point(335, 280);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(85, 30);
        btnCancel.TabIndex = 7;
        btnCancel.Text = "&Cancel";
        btnCancel.UseVisualStyleBackColor = true;
        btnCancel.Click += OnCancelClick;

        // 
        // SettingsForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(450, 330);
        Controls.Add(btnCancel);
        Controls.Add(btnSave);
        Controls.Add(comboLogLevel);
        Controls.Add(lblLogLevel);
        Controls.Add(numPageSize);
        Controls.Add(lblPageSize);
        Controls.Add(numRefreshInterval);
        Controls.Add(lblRefreshInterval);
        Controls.Add(chkAutoRefresh);
        Controls.Add(comboTheme);
        Controls.Add(lblTheme);
        Controls.Add(txtApiBaseUrl);
        Controls.Add(lblApiBaseUrl);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "SettingsForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Application Settings";

        ((System.ComponentModel.ISupportInitialize)numRefreshInterval).EndInit();
        ((System.ComponentModel.ISupportInitialize)numPageSize).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }
}
