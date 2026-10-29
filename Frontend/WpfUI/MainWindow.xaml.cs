using System.Windows;
using WpfUI.ViewModels;

namespace WpfUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(MainWindowViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
            Loaded += async (s, e) => await viewModel.InitializeDefaultWorkspaceAsync();
        }

        private void OnMenuExitClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}