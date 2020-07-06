using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Jukebox.Factory.Interface;
using Jukebox.Model.Players;
using Jukebox.Services.Interfaces;
using System;
using System.Windows.Input;

namespace Jukebox.ViewModel
{
    public class JukeboxMainViewModel : ViewModelBase
    {
        private readonly IJukeboxFactory _factory;
        private readonly IJukeboxService _service;
        private readonly IMessenger _messenger;

        private readonly RecordPlayer _player;

        public JukeboxMainViewModel(IJukeboxService service,
                                    IJukeboxFactory factory,
                                    IMessenger messenger)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));
            _messenger = messenger ?? throw new ArgumentNullException(nameof(messenger));
            _player = new RecordPlayer(_messenger);

            SongsClickCommand = new RelayCommand(SongsClickCommandMethod);
            AlbumsClickCommand = new RelayCommand(AlbumsClickCommandMethod);
            EditClickCommand = new RelayCommand(EditClickCommandMethod);
        }

        public void Load()
        {
            IsLoading = true;
            SongsViewModel = new SongsViewModel(_service, _factory, _messenger);
            IsLoading = false;
        }

        #region Properties
        public int TabSelectedIndex
        {
            get => _tabSelectedIndex;
            set => Set(ref _tabSelectedIndex, value);
        }
        private int _tabSelectedIndex;

        public bool IsLoading
        {
            get => _isLoading;
            set => Set(ref _isLoading, value);
        }
        private bool _isLoading;
        #endregion

        #region Commands
        public ICommand SongsClickCommand { get; set; }
        public ICommand AlbumsClickCommand { get; set; }
        public ICommand EditClickCommand { get; set; }
        #endregion

        #region command methods
        public void SongsClickCommandMethod()
        {
            TabSelectedIndex = 0;
        }

        public void AlbumsClickCommandMethod()
        {
            TabSelectedIndex = 1;
        }

        public void EditClickCommandMethod()
        {
            TabSelectedIndex = 2;
        }
        #endregion

        #region Content Control
        public SongsViewModel SongsViewModel
        {
            get => _songsViewModel;
            set => Set(ref _songsViewModel, value);
        }
        private SongsViewModel _songsViewModel;
        #endregion
    }
}
