using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Jukebox.Shared.Classes;
using Jukebox.Shared.Extensions;

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

        public short Year
        {
            get => _year;
            set => Set(ref _year, value);
        }
        private short _year;

        public ImageSource CoverImage
        {
            get => _coverImage;
            set => Set(ref _coverImage, value);
        }
        private ImageSource _coverImage;

        public Visibility PlayButtonVisability
        {
            get => _playButtonVisability;
            set => Set(ref _playButtonVisability, value);
        }
        private Visibility _playButtonVisability = Visibility.Collapsed;
        #endregion

        #region Commands
        public ICommand AddToPlaylistCommand { get; set; }

        public ICommand LostFocusCommand { get; set; }
        public ICommand GotFocusCommand { get; set; }
        #endregion

        #region Command Methods
        public void AddToPlaylistCommandMethod()
        {
            _messenger.SendMessage(this, Messages.AddSongToPlaylist);
        }
        #endregion
    }
}
