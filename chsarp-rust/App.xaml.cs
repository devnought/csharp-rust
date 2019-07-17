using System.Windows;

namespace chsarp_rust
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var test = RustLib.GetString();
            var viewModel = new ViewModel(test);

            MainWindow = new MainWindow
            {
                DataContext = viewModel,
            };

            MainWindow.Show();
        }
    }
}
