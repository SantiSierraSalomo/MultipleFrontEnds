namespace WinformsUI.Forms;

partial class ContactForm
{
    private System.ComponentModel.IContainer components = null;

    private Label lblName;
    private TextBox txtName;
    private Label lblEmail;
    private TextBox txtEmail;
    private Label lblSubject;
    private TextBox txtSubject;
    private Label lblMessage;
    private TextBox txtMessage;
    private Button btnSend;
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
        lblName = new Label();
        txtName = new TextBox();
        lblEmail = new Label();
        txtEmail = new TextBox();
        lblSubject = new Label();
        txtSubject = new TextBox();
        lblMessage = new Label();
        txtMessage = new TextBox();
        btnSend = new Button();
        btnCancel = new Button();
        SuspendLayout();

        // lblName
        lblName.AutoSize = true;
        lblName.Location = new Point(20, 20);
        lblName.Name = "lblName";
        lblName.Text = "Your Name:";

        // txtName
        txtName.Location = new Point(110, 17);
        txtName.Name = "txtName";
        txtName.Size = new Size(330, 23);
        txtName.TabIndex = 0;

        // lblEmail
        lblEmail.AutoSize = true;
        lblEmail.Location = new Point(20, 55);
        lblEmail.Name = "lblEmail";
        lblEmail.Text = "Email Address:";

        // txtEmail
        txtEmail.Location = new Point(110, 52);
        txtEmail.Name = "txtEmail";
        txtEmail.Size = new Size(330, 23);
        txtEmail.TabIndex = 1;

        // lblSubject
        lblSubject.AutoSize = true;
        lblSubject.Location = new Point(20, 90);
        lblSubject.Name = "lblSubject";
        lblSubject.Text = "Subject:";

        // txtSubject
        txtSubject.Location = new Point(110, 87);
        txtSubject.Name = "txtSubject";
        txtSubject.Size = new Size(330, 23);
        txtSubject.TabIndex = 2;

        // lblMessage
        lblMessage.AutoSize = true;
        lblMessage.Location = new Point(20, 125);
        lblMessage.Name = "lblMessage";
        lblMessage.Text = "Message:";

        // txtMessage
        txtMessage.Location = new Point(110, 122);
        txtMessage.Multiline = true;
        txtMessage.Name = "txtMessage";
        txtMessage.ScrollBars = ScrollBars.Vertical;
        txtMessage.Size = new Size(330, 120);
        txtMessage.TabIndex = 3;

        // btnSend
        btnSend.Location = new Point(255, 260);
        btnSend.Name = "btnSend";
        btnSend.Size = new Size(95, 30);
        btnSend.TabIndex = 4;
        btnSend.Text = "&Send Email";
        btnSend.UseVisualStyleBackColor = true;
        btnSend.Click += OnSendClick;

        // btnCancel
        btnCancel.Location = new Point(360, 260);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(80, 30);
        btnCancel.TabIndex = 5;
        btnCancel.Text = "&Cancel";
        btnCancel.UseVisualStyleBackColor = true;
        btnCancel.Click += OnCancelClick;

        // ContactForm
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(465, 310);
        Controls.Add(btnCancel);
        Controls.Add(btnSend);
        Controls.Add(txtMessage);
        Controls.Add(lblMessage);
        Controls.Add(txtSubject);
        Controls.Add(lblSubject);
        Controls.Add(txtEmail);
        Controls.Add(lblEmail);
        Controls.Add(txtName);
        Controls.Add(lblName);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "ContactForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Contact Support";
        ResumeLayout(false);
        PerformLayout();
    }
}
