using Microsoft.Extensions.DependencyInjection;

namespace WinformsUI.Services;

public interface IMdiChildManager
{
    T ShowChildForm<T>(Form mdiParent) where T : Form;
}

public class MdiChildManager : IMdiChildManager
{
    private readonly IServiceProvider _serviceProvider;

    public MdiChildManager(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public T ShowChildForm<T>(Form mdiParent) where T : Form
    {
        ArgumentNullException.ThrowIfNull(mdiParent);

        // Check if an instance of this form type is already open in the MDI container
        foreach (Form child in mdiParent.MdiChildren)
        {
            if (child is T typedChild && !typedChild.IsDisposed)
            {
                if (typedChild.WindowState == FormWindowState.Minimized)
                {
                    typedChild.WindowState = FormWindowState.Normal;
                }
                typedChild.Activate();
                typedChild.BringToFront();
                return typedChild;
            }
        }

        // Create a new instance resolved from DI
        var form = _serviceProvider.GetRequiredService<T>();
        form.MdiParent = mdiParent;
        form.Show();
        form.BringToFront();
        return form;
    }
}
