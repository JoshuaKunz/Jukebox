using GalaSoft.MvvmLight.Messaging;
using Jukebox.Shared.Factory;
using Jukebox.Shared.Factory.Interface;
using Jukebox.Shared.Services;
using Jukebox.Shared.Services.Interface;
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
