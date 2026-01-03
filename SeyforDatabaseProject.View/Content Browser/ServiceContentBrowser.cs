using System.Windows;
using SeyforDatabaseProject.ViewModel.ContentBrowser;
using SeyforDatabaseProject.ViewModel.Core;
using SeyforDatabaseProject.Views.Content_Browser;

namespace SeyforDatabaseProject.Windows
{
    /// <summary>
    /// A service for opening new windows.
    /// </summary>
    public class ServiceContentBrowser : IServiceContentBrowser
    {
        public void Open(ViewModelBase vm)
        {
            ContentBrowserWindow win = new();
            win.DataContext = vm;
            win.Show();
        }
    }
}