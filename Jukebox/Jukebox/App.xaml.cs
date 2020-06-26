using Jukebox.Factory.Interface;
using Jukebox.Services.Interfaces;
using Jukebox.View;
using Jukebox.ViewModel;
using Ninject;
using System.Reflection;
using System.Windows;

namespace Jukebox
{
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            //create ninject module
            var kernel = new StandardKernel();

            kernel?.Load(Assembly.GetExecutingAssembly());

            var splashVM = new SplashViewModel(kernel.Get<IJukeboxFactory>(),
                                                kernel.Get<IJukeboxService>());

            var splash = new SplashView(splashVM);

            splash.Show();

            (splash.DataContext as SplashViewModel).Load();
        }
    }
}
