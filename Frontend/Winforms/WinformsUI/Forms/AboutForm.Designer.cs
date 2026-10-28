namespace WinformsUI.Forms;

partial class AboutForm
{
    private System.ComponentModel.IContainer components = null;

    private Label lblTitle;
    private Label lblVersion;
    private Label lblDescription;
    private Label lblTargetRuntime;
    private Label lblApiUrlTitle;
    private Label lblApiUrlValue;
    private Button btnClose;

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
        lblTitle = new Label();
        lblVersion = new Label();
        lblDescription = new Label();
        lblTargetRuntime = new Label();
        lblApiUrlTitle = new Label();
        lblApiUrlValue = new Label();
        btnClose = new Button();
        SuspendLayout();

        // lblTitle
        lblTitle.AutoSize = true;
        lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
        lblTitle.Location = new Point(20, 20);
        lblTitle.Name = "lblTitle";
        lblTitle.Text = "Proposal Editor WinForms MDI";

        // lblVersion
        lblVersion.AutoSize = true;
        lblVersion.Location = new Point(20, 55);
        lblVersion.Name = "lblVersion";
        lblVersion.Text = "Version: 1.0.0 (.NET 10.0 Windows Forms)";

        // lblDescription
        lblDescription.AutoSize = true;
        lblDescription.Location = new Point(20, 85);
        lblDescription.MaximumSize = new Size(380, 0);
        lblDescription.Name = "lblDescription";
        lblDescription.Text = "An MDI enterprise client application built with modern Dependency Injection, typed REST API integration, and modular child windows.";

        // lblTargetRuntime
        lblTargetRuntime.AutoSize = true;
        lblTargetRuntime.Location = new Point(20, 135);
        lblTargetRuntime.Name = "lblTargetRuntime";
        lblTargetRuntime.Text = "Runtime: Microsoft .NET 10.0";

        // lblApiUrlTitle
        lblApiUrlTitle.AutoSize = true;
        lblApiUrlTitle.Location = new Point(20, 165);
        lblApiUrlTitle.Name = "lblApiUrlTitle";
        lblApiUrlTitle.Text = "Connected WebAPI:";

        // lblApiUrlValue
        lblApiUrlValue.AutoSize = true;
        lblApiUrlValue.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
        lblApiUrlValue.ForeColor = Color.Blue;
        lblApiUrlValue.Location = new Point(140, 165);
        lblApiUrlValue.Name = "lblApiUrlValue";
        lblApiUrlValue.Text = "https://localhost:7283";

        // btnClose
        btnClose.Location = new Point(310, 215);
        btnClose.Name = "btnClose";
        btnClose.Size = new Size(85, 30);
        btnClose.TabIndex = 0;
        btnClose.Text = "&Close";
        btnClose.UseVisualStyleBackColor = true;
        btnClose.Click += OnCloseClick;

        // AboutForm
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(420, 265);
        Controls.Add(btnClose);
        Controls.Add(lblApiUrlValue);
        Controls.Add(lblApiUrlTitle);
        Controls.Add(lblTargetRuntime);
        Controls.Add(lblDescription);
        Controls.Add(lblVersion);
        Controls.Add(lblTitle);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "AboutForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "About Proposal Editor";
        ResumeLayout(false);
        PerformLayout();
    }
}
