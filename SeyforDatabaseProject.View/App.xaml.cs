using System.Windows;
using SeyforDatabaseProject.Model;
using SeyforDatabaseProject.Model.Departments;
using SeyforDatabaseProject.Model.Services;
using SeyforDatabaseProject.ViewModel;
using SeyforDatabaseProject.ViewModel.Equipment;
using SeyforDatabaseProject.ViewModel.Navigation;

namespace SeyforDatabaseProject
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const string ConnectionString = "Data Source=SeyforDatabaseDB.db";

        private readonly NavigationStore _navigationStore;
        private readonly HotelStore _hotelStore;

        public App()
        {
            _navigationStore = new NavigationStore();
            DatabaseContextFactory contextFactory = new(ConnectionString);
            EquipmentDepartment equipmentDepartment = new(new DatabaseDataProvider(contextFactory), new DatabaseDataCreator(contextFactory), new DatabaseValidator(contextFactory));
            Hotel hotel = new(equipmentDepartment);
            _hotelStore = new(hotel);
        }
        
        protected override void OnStartup(StartupEventArgs e)
        {
            //TODO: Refactor into Dependency Injection
            _navigationStore.CurrentVM = CreateEquipmentTableVM();
            
            MainWindow m = new();
            m.DataContext = new MainVM(_navigationStore);
            m.Show();
        
            base.OnStartup(e);
        }
        
        private EquipmentListingVM CreateEquipmentTableVM()
        {
            return new EquipmentListingVM(_hotelStore, new NavigationService<EquipmentEditVM>(_navigationStore, CreateEquipmentEditVM));
        }
        
        private EquipmentEditVM CreateEquipmentEditVM()
        {
            return new EquipmentEditVM(_hotelStore, new NavigationService<EquipmentListingVM>(_navigationStore, CreateEquipmentTableVM));
        }
    }
}