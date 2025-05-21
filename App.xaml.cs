using System.Windows;
using KraiLauncher.Services;
using KraiLauncher.View;
using KraiLauncher.ViewModel;
using Microsoft.Extensions.DependencyInjection;

namespace KraiLauncher
{
    public partial class App : Application
    {
        private readonly IServiceProvider _serviceProvider;

        public App()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<MainWindow>(provider => new MainWindow
            {
                DataContext = provider.GetRequiredService<MainViewModel>()
            });

            services.AddSingleton<MainViewModel>();
            services.AddTransient<GameViewModel>();
            services.AddSingleton<ProfileViewModel>();
            services.AddSingleton<INavigationService, NavigationService>();

            services.AddSingleton<Func<Type, Core.ViewModel>>(serviceProvider => viewModelType => (Core.ViewModel)serviceProvider.GetRequiredService(viewModelType));

            _serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
            base.OnStartup(e);
        }
    }

}
