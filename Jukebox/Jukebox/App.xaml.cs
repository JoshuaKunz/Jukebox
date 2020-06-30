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
            var kernel = new StandardKernel();

            kernel?.Load(Assembly.GetExecutingAssembly());

            var startup = kernel.Get<IStartup>();// <--- has all of the dependencies

            startup.Start();
        }
    }
}
