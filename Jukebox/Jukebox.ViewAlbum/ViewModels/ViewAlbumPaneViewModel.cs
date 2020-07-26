using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using Jukebox.Shared.ViewModels;
using System;
using System.Collections.ObjectModel;

namespace Jukebox.ViewAlbum.ViewModels
{
    public class ViewAlbumPaneViewModel : ViewModelBase
    {
        private readonly IMessenger _messenger;

        public ViewAlbumPaneViewModel(IMessenger messenger)
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
