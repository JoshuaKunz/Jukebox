using GalaSoft.MvvmLight.Messaging;
using Jukebox.Factory;
using Jukebox.Factory.Interface;
using Jukebox.Services;
using Jukebox.Services.Interface;
using Ninject.Modules;

namespace Jukebox.Ninject
{
    public class JukeboxNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Kernel?.Bind<IJukeboxFactory>().To<JukeboxFactory>().InSingletonScope();
            Kernel?.Bind<IJukeboxService>().To<JukeboxService>().InSingletonScope();
            Kernel?.Bind<IMessenger>().To<Messenger>().InSingletonScope();
        }
    }
}
