using GalaSoft.MvvmLight.Messaging;
using Jukebox.Shared.Art;
using Jukebox.Shared.Extensions;
using Jukebox.Shared.Factory.Interface;
using Jukebox.Shared.Models;
using Jukebox.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Media.Imaging;

namespace Jukebox.Shared.Factory
{
    public class JukeboxFactory : IJukeboxFactory
    {
        private readonly IMessenger _messenger;

        public JukeboxFactory(IMessenger messenger)
        {
            _messenger = messenger ?? throw new ArgumentNullException(nameof(messenger));
        }

        public SongViewModel ConvertSongModel(SongModel model)
        {
            GetImageFromMp3(model.Path, model.Album);

            AlbumArtCollection.SharedAlbumArt.TryGetValue(model.Album, out var albumArt);

            return new SongViewModel(_messenger)
            {
                Artist = model.Artist,
                Album = model.Album,
                CoverImage = albumArt ?? new BitmapImage(),
                Path = model.Path,
                TrackNumber = model.TrackNumber,
                Year = model.Year,
                Title = model.Title
            };
        }

        public IEnumerable<SongViewModel> ConvertSongModels(IEnumerable<SongModel> models) => models.Select(ConvertSongModel);

        public AlbumViewModel ConvertSongsToAlbum(List<SongViewModel> songs)
        {
            var firstSong = songs?.FirstOrDefault();

            return new AlbumViewModel(_messenger)
            {
                Songs = songs.ToObservableCollection(),
                AlbumArtist = firstSong?.Artist,
                AlbumTitle = firstSong?.Album,
                AlbumYear = firstSong?.Year ?? 0,
                NumberOfTracks = songs?.Count ?? 0,
                AlbumCover = firstSong?.CoverImage
            };
        }

        public void GetImageFromMp3(string path, string albumName)
        {
            var f = new TagLib.Mpeg.AudioFile(path);

            if (!f.Tag.Pictures.Any()) return;

            TagLib.IPicture pic = f?.Tag?.Pictures[0];

            var ms = new MemoryStream(pic.Data.Data);
            ms.Seek(0, SeekOrigin.Begin);

            // ImageSource for System.Windows.Controls.Image
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.StreamSource = ms;
            bitmap.EndInit();

            AlbumArtCollection.SharedAlbumArt[albumName] = bitmap;
        }
    }
}
