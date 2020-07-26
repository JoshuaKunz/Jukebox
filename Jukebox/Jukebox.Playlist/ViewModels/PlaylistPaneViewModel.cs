using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using Jukebox.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Jukebox.Playlist.ViewModels
{
    public class PlaylistPaneViewModel : ViewModelBase
    {
        private readonly IMessenger _messenger;

        public PlaylistPaneViewModel(IMessenger messenger)
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
    }
}
