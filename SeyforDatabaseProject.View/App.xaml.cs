using System.Windows;
using SeyforDatabaseProject.Model;
using SeyforDatabaseProject.Model.Departments;
using SeyforDatabaseProject.Model.Services;
using SeyforDatabaseProject.ViewModel;

namespace SeyforDatabaseProject
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const string ConnectionString = "Data Source=SeyforDatabaseDB.db";
        
        protected override void OnStartup(StartupEventArgs e)
        {
            //TODO: Refactor into Dependency Injection
            DatabaseContextFactory contextFactory = new(ConnectionString);
            EquipmentDepartment equipmentDepartment = new(new DatabaseDataProvider(contextFactory), new DatabaseDataCreator(contextFactory), new DatabaseValidator(contextFactory));
            Hotel hotel = new(equipmentDepartment);
            
            MainWindow m = new();
            m.DataContext = new MainVM(hotel);
            m.Show();
        
            base.OnStartup(e);
        }
    }
}