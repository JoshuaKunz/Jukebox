using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Jukebox.Shared.Classes;
using Jukebox.Shared.Extensions;
using Jukebox.Shared.Factory.Interface;
using Jukebox.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using System.Windows.Media;

namespace Jukebox.Albums.ViewModels
{
    public class AlbumsPaneViewModel : ViewModelBase
    {
        private readonly IMessenger _messenger;
        private readonly IJukeboxFactory _factory;

        public AlbumsPaneViewModel(IMessenger messenger, IJukeboxFactory factory)
        {
            _messenger = messenger ?? throw new ArgumentNullException(nameof(messenger));
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));

            _messenger.RegisterMessageListener<List<SongViewModel>>(this, Messages.AllSongsLoadedSendToAlbums, AllSongsLoadedToAlbums);

            ShowAllAlbumSongsCommand = new RelayCommand<AlbumViewModel>(ShowAllAlbumSongsCommandMethod);
        }

        #region Properties
        public ObservableCollection<AlbumViewModel> Albums
        {
            get => _albums;
            set => Set(ref _albums, value);
        }
        private ObservableCollection<AlbumViewModel> _albums = new ObservableCollection<AlbumViewModel>();

        private ImageSource AlbumCoverImage
        {
            get => _albumCoverImage;
            set => Set(ref _albumCoverImage, value);
        }
        private ImageSource _albumCoverImage;
        #endregion

        #region Commands
        public ICommand ShowAllAlbumSongsCommand { get; set; }
        #endregion

        #region Command Methods

        #endregion

        #region Methods
        public void ShowAllAlbumSongsCommandMethod(AlbumViewModel album)
        {

        }
        #endregion

        #region Message Methods
        public void AllSongsLoadedToAlbums(NotificationMessage<List<SongViewModel>> message)
        {
            //create the albums with this list of lists
            var albums = message.Content.GroupBy(x => x.Album);

            var albumList = new List<AlbumViewModel>();

            foreach (var album in albums)
            {
                var albumSongs = new List<SongViewModel>();

                foreach (var song in album)
                {
                    albumSongs.Add(song);
                }

                albumList.Add(_factory.ConvertSongsToAlbum(albumSongs));
            }

            albumList = albumList.OrderBy(x => x.AlbumYear).ToList();

            albumList.ForEach(x => Albums.Add(x));

            //TODO: send message to artists pane with all of the albums


            albumList = null;
        }
        #endregion
    }
}
