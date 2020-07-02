using Jukebox.Factory.Interface;
using Jukebox.Services.Interfaces;
using Jukebox.View;
using Jukebox.ViewModel;
using System;
using System.IO;

namespace Jukebox
{
    public class Startup : IStartup
    {
        private IJukeboxFactory _factory;
        private IJukeboxService _service;

        public static string AppDataPath = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + @"\AppData";

        public Startup(IJukeboxService service, IJukeboxFactory factory)
        {
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public void Start()
        {
            if (!Directory.Exists(AppDataPath))
            {
                Directory.CreateDirectory(AppDataPath);
            }

            var jukeboxVM = new JukeboxMainViewModel(_service, _factory);
            var jukeboxWindow = new JukeboxMainView(jukeboxVM);

            jukeboxWindow.Show();

            (jukeboxWindow.DataContext as JukeboxMainViewModel).Load();
        }
    }
}
