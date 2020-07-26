using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Jukebox.Shared.Classes;
using Jukebox.Shared.Extensions;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using System.Windows.Media;

namespace Jukebox.Shared.ViewModels
{
    public class AlbumViewModel : ViewModelBase
    {
        private readonly IMessenger _messenger;

        public AlbumViewModel(IMessenger messenger)
        {
            _messenger = messenger ?? throw new ArgumentNullException(nameof(messenger));

            ViewAlbumSongsCommand = new RelayCommand(ViewAlbumSongsCommandMethod);
        }

        #region Properties
        public ObservableCollection<SongViewModel> Songs
        {
            get => _songs;
            set => Set(ref _songs, value);
        }
        private ObservableCollection<SongViewModel> _songs = new ObservableCollection<SongViewModel>();

        public string AlbumTitle
        {
            get => _albumTitle;
            set => Set(ref _albumTitle, value);
        }
        private string _albumTitle;

        public ImageSource AlbumCover
        {
            get => _albumCover;
            set => Set(ref _albumCover, value);
        }
        private ImageSource _albumCover;

        public string AlbumArtist
        {
            get => _albumArtist;
            set => Set(ref _albumArtist, value);
        }
        private string _albumArtist;

        public short AlbumYear
        {
            get => _albumYear;
            set => Set(ref _albumYear, value);
        }
        private short _albumYear;

        public int NumberOfTracks
        {
            get => _numberOfTracks;
            set => Set(ref _numberOfTracks, value);
        }
        private int _numberOfTracks;
        #endregion

        #region Commands
        public ICommand ViewAlbumSongsCommand { get; set; }
        #endregion

        #region Command Methods
        public void ViewAlbumSongsCommandMethod()
        {
            _messenger.SendMessage(Songs.ToList(), Messages.SendSongsToViewAlbum);
        }
        #endregion
    }
}
