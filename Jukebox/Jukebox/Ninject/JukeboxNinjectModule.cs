using GalaSoft.MvvmLight.Messaging;
using Jukebox.Factory;
using Jukebox.Factory.Interface;
using Jukebox.Services;
using Jukebox.Services.Interfaces;
using Ninject.Modules;

namespace Jukebox.Ninject
{
    public class JukeboxNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Kernel?.Bind<IJukeboxService>().To<JukeboxService>().InSingletonScope();
            Kernel?.Bind<IJukeboxFactory>().To<JukeboxFactory>().InSingletonScope();
            Kernel?.Bind<IStartup>().To<Startup>().InSingletonScope();
            Kernel?.Bind<IMessenger>().To<Messenger>().InSingletonScope();
        }
    }
}
