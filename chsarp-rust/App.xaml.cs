using System.Windows;

namespace chsarp_rust
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var rustString = RustLib.GetString();
            var rustStruct = RustLib.GetStruct();

            var viewModel = new ViewModel(rustString, rustStruct.IntVal);

            MainWindow = new MainWindow
            {
                DataContext = viewModel,
            };

            MainWindow.Show();
        }
    }
}
