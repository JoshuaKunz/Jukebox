using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using Jukebox.Factory.Interface;
using Jukebox.Services.Interfaces;
using Jukebox.UI;
using System;
using System.Windows.Controls;

namespace Jukebox.ViewModel
{
    public class SongsViewModel : ViewModelBase
    {
        private readonly IJukeboxFactory _factory;
        private readonly IJukeboxService _service;
        private readonly IMessenger _messenger;

        public Grid SongsGrid
        {
            get => _songsGrid;
            set => Set(ref _songsGrid, value);
        }
        private Grid _songsGrid;

        public bool IsLoading
        {
            get => _isLoading;
            set => Set(ref _isLoading, value);
        }
        private bool _isLoading;

        public SongsViewModel(IJukeboxService service,
                                IJukeboxFactory factory,
                                IMessenger messenger)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));
            _messenger = messenger ?? throw new ArgumentNullException(nameof(messenger));

            Setup();
        }

        private async void Setup()
        {
            IsLoading = true;

            SongsGrid = new SongsGrid(await _service.GetAllSongs());

            IsLoading = false;
        }

        public void Refresh()
        {
            Setup();
        }
    }
}
