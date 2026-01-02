using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SeyforDatabaseProject.Model.Departments;
using SeyforDatabaseProject.Model.Services;
using SeyforDatabaseProject.ViewModel.Equipment;
using SeyforDatabaseProject.ViewModel.Navigation;
using SeyforDatabaseProject.ViewModel.Rooms;

namespace SeyforDatabaseProject.Views.HostBuilder
{
    /// <summary>
    /// Contains methods for building the host in <see cref="App"/>.
    /// </summary>
    public static class HostBuilderExtensions
    {
        public static IHostBuilder BuildDepartments(this IHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureServices(services =>
            {
                services.AddSingleton<IServiceDataProvider, DatabaseDataProvider>();
                services.AddSingleton<IServiceDataCreator, DatabaseDataCreator>();
                services.AddSingleton<IServiceDataUpdater, DatabaseDataUpdater>();
                services.AddSingleton<IServiceDataRemover, DatabaseDataRemover>();
                services.AddSingleton<IServiceDataValidator, DatabaseValidator>();
                services.AddTransient<HotelBook>();
            });
            
            return hostBuilder;
        }
        
        public static IHostBuilder BuildVMs(this IHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureServices(services =>
            {
                services.AddSingleton<ScreenEquipmentOperationsVM>();
                services.AddSingleton<Func<ScreenEquipmentOperationsVM>>(s => s.GetRequiredService<ScreenEquipmentOperationsVM>);
                services.AddSingleton<NavigationService<ScreenEquipmentOperationsVM>>();
                
                services.AddSingleton<ScreenRoomOperationsVM>();
                services.AddSingleton<Func<ScreenRoomOperationsVM>>(s => s.GetRequiredService<ScreenRoomOperationsVM>);
                services.AddSingleton<NavigationService<ScreenRoomOperationsVM>>();

            });
            
            return hostBuilder;
        }
    }
}