using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using Jukebox.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Jukebox.Albums.ViewModels
{
    public class AlbumsPaneViewModel : ViewModelBase
    {
        private readonly IMessenger _messenger;

        public AlbumsPaneViewModel(IMessenger messenger)
        {
            _messenger = messenger ?? throw new ArgumentNullException(nameof(messenger));

            //_messenger.Register(this, );
        }

        #region Properties
        public ObservableCollection<AlbumViewModel> Albums
        {
            get => _albums;
            set => Set(ref _albums, value);
        }
        private ObservableCollection<AlbumViewModel> _albums;

        private ImageSource AlbumCoverImage
        {
            get => _albumCoverImage;
            set => Set(ref _albumCoverImage, value);
        }
        private ImageSource _albumCoverImage;
        #endregion

        #region Commands
        public ICommand ShowAllAlbumSongs { get; set; }
        #endregion

        #region Command Methods

        #endregion

        #region Methods

        #endregion

        #region Message Methods
        public void AllSongsLoadedToAlbums(NotificationMessage<IEnumerable<SongViewModel>> message)
        {
            MessageBox.Show("allsongsloadedtoalbums");
        }
        #endregion
    }
}
