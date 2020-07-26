using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Jukebox.Shared.Classes;
using Jukebox.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows.Media;

namespace Jukebox.Shared.ViewModels
{
    public class ArtistViewModel : ViewModelBase
    {
        private readonly IMessenger _messenger;

        public ArtistViewModel(IMessenger messenger)
        {
            _messenger = messenger ?? throw new ArgumentNullException(nameof(messenger));

            ViewArtistCommand = new RelayCommand(ViewArtistCommandMethod);
        }

        #region Properties
        public ObservableCollection<AlbumViewModel> Albums
        {
            get => _albums;
            set
            {
                Set(ref _albums, value);
                AlbumCount = _albums.Count;
            }
        }
        private ObservableCollection<AlbumViewModel> _albums;

        public string Artist
        {
            get => _artist;
            set => Set(ref _artist, value);
        }
        private string _artist;

        public int AlbumCount
        {
            get => _albumCount;
            set => Set(ref _albumCount, value);
        }
        private int _albumCount;

        public ImageSource ArtistCover
        {
            get => _artistCover;
            set => Set(ref _artistCover, value);
        }
        private ImageSource _artistCover;
        #endregion

        #region Commands
        public ICommand ViewArtistCommand { get; set; }
        #endregion

        #region Command Methods
        private void ViewArtistCommandMethod()
        {
            _messenger.SendMessage(Albums.ToList(), Messages.ViewArtistAlbums);
        }
        #endregion
    }
}
