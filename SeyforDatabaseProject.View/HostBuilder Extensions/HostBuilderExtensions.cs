using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SeyforDatabaseProject.Model;
using SeyforDatabaseProject.Model.Departments;
using SeyforDatabaseProject.Model.Services;
using SeyforDatabaseProject.ViewModel.Equipment;
using SeyforDatabaseProject.ViewModel.Navigation;

namespace SeyforDatabaseProject.Views.HostBuilder
{
    /// <summary>
    /// Contains methods for building the host in <see cref="App"/>.
    /// </summary>
    public static class HostBuilderExtensions
    {
        public static IHostBuilder BuildDepartments(this IHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureServices((hostContext, services) =>
            {
                services.AddSingleton<IServiceDataCreator, DatabaseDataCreator>();
                services.AddSingleton<IServiceDataProvider, DatabaseDataProvider>();
                services.AddSingleton<IServiceDataValidator, DatabaseValidator>();
                services.AddTransient<EquipmentDepartment>();
            });
            
            return hostBuilder;
        }
        
        public static IHostBuilder BuildVMs(this IHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureServices((hostContext, services) =>
            {
                services.AddTransient<EquipmentListingVM>();
                services.AddSingleton<Func<EquipmentEditVM>>(s => s.GetRequiredService<EquipmentEditVM>);
                services.AddSingleton<NavigationService<EquipmentListingVM>>();
                    
                services.AddTransient<EquipmentEditVM>();
                services.AddSingleton<Func<EquipmentListingVM>>(s => s.GetRequiredService<EquipmentListingVM>);
                services.AddSingleton<NavigationService<EquipmentEditVM>>();
            });
            
            return hostBuilder;
        }
    }
}