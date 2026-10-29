using System.Windows;
using System.Windows.Controls;
using WpfUI.ViewModels;

namespace WpfUI.Views;

public partial class ProposalEditingView : UserControl
{
    public ProposalEditingView()
    {
        InitializeComponent();
        Loaded += OnLoaded;
    }

    private async void OnLoaded(object sender, RoutedEventArgs e)
    {
        if (DataContext is ProposalEditingViewModel vm && vm.ItemFilterOptions.Count == 0)
        {
            await vm.InitializeFiltersAsync();
        }
    }
}
