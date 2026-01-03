using System.Windows;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SeyforDatabaseProject.Model;
using SeyforDatabaseProject.Model.DatabaseConnection;
using SeyforDatabaseProject.ViewModel;
using SeyforDatabaseProject.ViewModel.Navigation;
using SeyforDatabaseProject.ViewModel.Reservations;
using SeyforDatabaseProject.Views.HostBuilder;

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

                    services.AddSingleton<Hotel>();
                    services.AddSingleton<HotelStore>();
                    services.AddSingleton<NavigationStore>();

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
                .BuildDepartments()
                .BuildVMs()
                .Build();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();
            _host.Services.GetRequiredService<NavigationService<ScreenReservationOperationsVM>>().Navigate();
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