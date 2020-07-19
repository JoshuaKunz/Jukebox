using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Jukebox.Shared.ViewModels
{
    public class SongViewModel : ViewModelBase
    {
        private readonly IMessenger _messenger;

        public SongViewModel(IMessenger messenger)
        {
            _messenger = messenger ?? throw new ArgumentNullException(nameof(messenger));

            AddToPlaylistCommand = new RelayCommand(AddToPlaylistCommandMethod);
        }

        #region Properties
        public string Artist
        {
            get => _artist;
            set => Set(ref _artist, value);
        }
        private string _artist;

        public string Album
        {
            get => _album;
            set => Set(ref _album, value);
        }
        private string _album;

        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }
        private string _title;

        public string Path
        {
            get => _path;
            set => Set(ref _path, value);
        }
        private string _path;

        public short TrackNumber
        {
            get => _trackNumber;
            set => Set(ref _trackNumber, value);
        }
        private short _trackNumber;

        public string Year
        {
            get => _year;
            set => Set(ref _year, value);
        }
        private string _year;

        public string Length
        {
            get => _length;
            set => Set(ref _length, value);
        }
        private string _length;

        public ImageSource CoverImage
        {
            get => _coverImage;
            set => Set(ref _coverImage, value);
        }
        private ImageSource _coverImage;
        #endregion

        #region Commands
        public ICommand AddToPlaylistCommand { get; set; }
        #endregion

        #region Methods

        #endregion

        #region Command Methods
        public void AddToPlaylistCommandMethod()
        {
            //Send message to the playlist adding this song.
        }
        #endregion
    }
}
