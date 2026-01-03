using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SeyforDatabaseProject.Model.Departments;
using SeyforDatabaseProject.Model.Services;
using SeyforDatabaseProject.ViewModel;
using SeyforDatabaseProject.ViewModel.ContentBrowser;
using SeyforDatabaseProject.ViewModel.Equipment;
using SeyforDatabaseProject.ViewModel.Guests;
using SeyforDatabaseProject.ViewModel.Navigation;
using SeyforDatabaseProject.ViewModel.Reservations;
using SeyforDatabaseProject.ViewModel.Rooms;
using SeyforDatabaseProject.Windows;

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
                services.AddSingleton<IServiceContentBrowser, ServiceContentBrowser>();
                services.AddTransient<HotelBook>();
            });
            
            return hostBuilder;
        }
        
        public static IHostBuilder BuildVMs(this IHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureServices(services =>
            {
                PrepareEquipment(services);
                PrepareRooms(services);
                PrepareGuests(services);
                PrepareReservations(services);
            });
            
            return hostBuilder;
        }

        private static void PrepareEquipment(IServiceCollection services)
        {
            services.AddSingleton<ScreenEquipmentOperationsVM>(s =>
            {
                ScreenEquipmentOperationsVM vm = new(s.GetRequiredService<HotelStore>());
                vm.Construct();
                return vm;
            });
            services.AddSingleton<Func<ScreenEquipmentOperationsVM>>(s =>
            {
                return () =>
                {
                    ScreenEquipmentOperationsVM operations = s.GetRequiredService<ScreenEquipmentOperationsVM>();
                    operations.NavigateToListing();
                    return operations;
                };
            });
            services.AddSingleton<NavigationService<ScreenEquipmentOperationsVM>>();
        }
        
        private static void PrepareRooms(IServiceCollection services)
        {
            services.AddSingleton<ScreenRoomOperationsVM>(s =>
            {
                ScreenRoomOperationsVM vm = new(s.GetRequiredService<HotelStore>());
                vm.Construct();
                return vm;
            });
            services.AddSingleton<Func<ScreenRoomOperationsVM>>(s =>
            {
                return () =>
                {
                    ScreenRoomOperationsVM operations = s.GetRequiredService<ScreenRoomOperationsVM>();
                    operations.NavigateToListing();
                    return operations;
                };
            });
            services.AddSingleton<NavigationService<ScreenRoomOperationsVM>>();
        }
        
        private static void PrepareGuests(IServiceCollection services)
        {
            services.AddSingleton<ScreenGuestOperationsVM>(s =>
            {
                ScreenGuestOperationsVM vm = new(s.GetRequiredService<HotelStore>());
                vm.Construct();
                return vm;
            });
            services.AddSingleton<Func<ScreenGuestOperationsVM>>(s =>
            {
                return () =>
                {
                    ScreenGuestOperationsVM operations = s.GetRequiredService<ScreenGuestOperationsVM>();
                    operations.NavigateToListing();
                    return operations;
                };
            });
            services.AddSingleton<NavigationService<ScreenGuestOperationsVM>>();
        }
        
        private static void PrepareReservations(IServiceCollection services)
        {
            services.AddSingleton<ScreenReservationOperationsVM>(s =>
            {
                ScreenReservationOperationsVM vm = new(s.GetRequiredService<HotelStore>(), s.GetRequiredService<IServiceContentBrowser>());
                vm.Construct();
                return vm;
            });
            services.AddSingleton<Func<ScreenReservationOperationsVM>>(s =>
            {
                return () =>
                {
                    ScreenReservationOperationsVM operations = s.GetRequiredService<ScreenReservationOperationsVM>();
                    operations.NavigateToListing();
                    return operations;
                };
            });
            services.AddSingleton<NavigationService<ScreenReservationOperationsVM>>();
        }
    }
}