using GalaSoft.MvvmLight;
using Jukebox.Factory.Interface;
using Jukebox.Services.Interfaces;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace Jukebox.ViewModel
{
    public class SplashViewModel : ViewModelBase
    {
        private IJukeboxService _service;
        private IJukeboxFactory _factory;

        public SplashViewModel(IJukeboxFactory factory, IJukeboxService service)
        {
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _appVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            _title = "Jukebox V" + AppVersion;
        }

        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }
        private string _title;

        public string AppVersion
        {
            get => _appVersion;
            set => Set(ref _appVersion, value);
        }
        private string _appVersion;

        public string Log
        {
            get => _log ?? "";
            set => Set(ref _log, value);
        }
        private string _log;

        public async void Load()
        {
            await Task.Run(() =>
            {
                for (var i = 0; i < 200; i++)
                {
                    System.Threading.Thread.Sleep(100);
                    Log = i.ToString();
                }
            });
        }
    }
}
