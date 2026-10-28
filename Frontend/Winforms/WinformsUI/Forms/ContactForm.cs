using System.ComponentModel.DataAnnotations;

namespace WinformsUI.Forms;

public partial class ContactForm : Form
{
    public ContactForm()
    {
        InitializeComponent();
    }

    private void OnSendClick(object? sender, EventArgs e)
    {
        var name = txtName.Text.Trim();
        var email = txtEmail.Text.Trim();
        var subject = txtSubject.Text.Trim();
        var message = txtMessage.Text.Trim();

        if (string.IsNullOrWhiteSpace(name))
        {
            MessageBox.Show("Please enter your name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtName.Focus();
            return;
        }

        if (string.IsNullOrWhiteSpace(email) || !new EmailAddressAttribute().IsValid(email))
        {
            MessageBox.Show("Please enter a valid email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtEmail.Focus();
            return;
        }

        if (string.IsNullOrWhiteSpace(subject))
        {
            MessageBox.Show("Please enter a subject.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtSubject.Focus();
            return;
        }

        if (string.IsNullOrWhiteSpace(message))
        {
            MessageBox.Show("Please enter a message.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtMessage.Focus();
            return;
        }

        // Simulate sending email (backend endpoint not yet implemented)
        MessageBox.Show(
            $"Email successfully simulated!{Environment.NewLine}{Environment.NewLine}" +
            $"To: Support Team{Environment.NewLine}" +
            $"From: {name} <{email}>{Environment.NewLine}" +
            $"Subject: {subject}{Environment.NewLine}{Environment.NewLine}" +
            "Note: An actual backend sending endpoint will be connected once available.",
            "Email Sent",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);

        txtName.Clear();
        txtEmail.Clear();
        txtSubject.Clear();
        txtMessage.Clear();
    }

    private void OnCancelClick(object? sender, EventArgs e)
    {
        Close();
    }
}
