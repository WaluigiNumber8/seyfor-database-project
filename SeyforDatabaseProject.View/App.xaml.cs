using System.Windows;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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
        private readonly IHost _host;

        public App()
        {
            _host = Host.CreateDefaultBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton(new DatabaseContextFactory(hostContext.Configuration.GetConnectionString("Default")!));
                    services.AddSingleton<IServiceDataCreator, DatabaseDataCreator>();
                    services.AddSingleton<IServiceDataProvider, DatabaseDataProvider>();
                    services.AddSingleton<IServiceDataValidator, DatabaseValidator>();
                    services.AddTransient<EquipmentDepartment>();

                    services.AddSingleton<Hotel>();
                    services.AddSingleton<HotelStore>();
                    services.AddSingleton<NavigationStore>();

                    services.AddTransient<EquipmentListingVM>();
                    services.AddSingleton<Func<EquipmentEditVM>>(s => s.GetRequiredService<EquipmentEditVM>);
                    services.AddSingleton<NavigationService<EquipmentListingVM>>();
                    
                    services.AddTransient<EquipmentEditVM>();
                    services.AddSingleton<Func<EquipmentListingVM>>(s => s.GetRequiredService<EquipmentListingVM>);
                    services.AddSingleton<NavigationService<EquipmentEditVM>>();
                    
                    services.AddSingleton<MainVM>();
                    services.AddSingleton(s =>
                    {
                        MainWindow mainWindow = new()
                        {
                            DataContext = s.GetRequiredService<MainVM>()
                        };
                        return mainWindow;
                    });
                })
                .Build();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Services.GetRequiredService<NavigationService<EquipmentListingVM>>().Navigate();
            _host.Services.GetRequiredService<MainWindow>().Show();

            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _host.Dispose();
            base.OnExit(e);
        }
    }
}