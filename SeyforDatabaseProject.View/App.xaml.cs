using System.Configuration;
using System.Data;
using System.Windows;
using SeyforDatabaseProject.ViewModel;

namespace SeyforDatabaseProject;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        MainWindow m = new();
        m.DataContext = new MainVM();
        m.Show();
        
        base.OnStartup(e);
    }
}