using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using Jukebox.Shared.ViewModels;
using System;
using System.Collections.ObjectModel;

namespace Jukebox.Albums.ViewModels
{
    public class AlbumViewModel : ViewModelBase
    {
        private readonly IMessenger _messenger;

        public AlbumViewModel(IMessenger messenger)
        {
            _messenger = messenger ?? throw new ArgumentNullException(nameof(messenger));
        }

        #region Properties
        public ObservableCollection<SongViewModel> Songs
        {
            get => _songs;
            set => Set(ref _songs, value);
        }
        private ObservableCollection<SongViewModel> _songs = new ObservableCollection<SongViewModel>();
        #endregion

        #region Commands

        #endregion

        #region Command Methods

        #endregion

        #region Methods

        #endregion

        #region Messages

        #endregion
    }
}
