using Jukebox.Ninject;
using Jukebox.Songs.ViewModels;
using Jukebox.ViewModels;
using Jukebox.Views;
using Ninject;
using System;
using System.Windows;

namespace Jukebox
{
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var kernel = new StandardKernel(new JukeboxNinjectModule());

            var window = new JukeboxView
            {
                DataContext = kernel?.Get<JukeboxViewModel>()
            };

            window.Show();
        }
    }
}
