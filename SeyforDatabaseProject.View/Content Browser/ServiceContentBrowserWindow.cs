using SeyforDatabaseProject.ViewModel.ContentBrowser;
using SeyforDatabaseProject.ViewModel.Core;
using SeyforDatabaseProject.Views.Content_Browser;

namespace SeyforDatabaseProject.Windows
{
    /// <summary>
    /// A service for opening new windows.
    /// </summary>
    public class ServiceContentBrowserWindow : IServiceContentBrowser
    {
        private ContentBrowserWindow? _window;

        public void Open(ViewModelBase vm)
        {
            _window = new();
            _window.DataContext = vm;
            _window.Show();
        }

        public void Close()
        {
            if (_window == null || !_window.IsVisible) return;
            _window.Close();
        }
    }
}