using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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
                services.AddSingleton<EquipmentListingVM>();
                services.AddSingleton<Func<EquipmentEditVM>>(s => s.GetRequiredService<EquipmentEditVM>);
                services.AddSingleton<NavigationService<EquipmentListingVM>>();
                    
                services.AddSingleton<EquipmentEditVM>();
                services.AddSingleton(NavigateToEquipmentListingScreen);
                services.AddSingleton<NavigationService<EquipmentEditVM>>();
            });
            
            return hostBuilder;
        }

        /// <summary>
        /// Runs navigation to equipment listing screen.
        /// </summary>
        private static Func<EquipmentListingVM> NavigateToEquipmentListingScreen(IServiceProvider s)
        {
            return () =>
            {
                EquipmentListingVM vm = s.GetRequiredService<EquipmentListingVM>();
                vm.RefreshEntriesCommand.Execute(null);
                return vm;
            };
        }
    }
}