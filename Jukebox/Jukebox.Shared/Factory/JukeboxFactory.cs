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
using System.Windows;
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

        #region Songs
        public SongViewModel ConvertSongModel(SongModel model)
        {
            GetImageFromMp3(model.Path, model.Album);
            GetImageFromMp3ForArtists(model.Path, model.Artist);

            AlbumArtCollection.SharedAlbumArt.TryGetValue(model.Album, out var albumArt);

            if(albumArt == null)
            {
                MessageBox.Show($"album art null on song: {model.Title}");
            }

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

        public IEnumerable<SongViewModel> ConvertSongModels(IEnumerable<SongModel> models)
        {
            List<SongViewModel> songs = new List<SongViewModel>();

            var missingDataCount = 0;
            var songPathsWithMissingData = new List<string>();

            foreach (var song in models)
            {
                if (song.Album == null || song.Title == null || song.Artist == null)
                {
                    songPathsWithMissingData.Add(song.Path);
                    missingDataCount++;
                    continue;
                }
                else
                {
                    songs.Add(ConvertSongModel(song));
                }
            }

            if (missingDataCount > 0)
            {
                var paths = string.Join('\n', songPathsWithMissingData);

                MessageBox.Show($"There were {missingDataCount} song(s) that were missing MP3 metadata and were rejected.\nSong paths are {paths}", "Some songs were not loaded", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            return songs;
        }
        #endregion

        #region Albums
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
        #endregion

        #region Artists
        public List<ArtistViewModel> ConvertAlbumsToArtist(List<AlbumViewModel> albums)
        {
            var albumGroups = albums.GroupBy(x => x.AlbumArtist).ToList();

            List<ArtistViewModel> artists = new List<ArtistViewModel>();

            foreach(var albumGroup in albumGroups)
            {
                artists.Add(ConvertAlbumsToArtistSingle(albumGroup.ToList()));
            }

            return artists;
        }

        public ArtistViewModel ConvertAlbumsToArtistSingle(List<AlbumViewModel> albums)
        {
            var firstAlbum = albums?.FirstOrDefault();

            var albName = firstAlbum.AlbumTitle;

            AlbumArtCollection.SharedArtistArt.TryGetValue(firstAlbum.AlbumArtist, out var artistArt);

            return new ArtistViewModel(_messenger)
            {
                Albums = albums?.ToObservableCollection(),
                Artist = firstAlbum?.AlbumArtist,
                AlbumCount = albums?.Count ?? 0,
                ArtistCover = artistArt
            };
        }
        #endregion

        #region MP3
        public void GetImageFromMp3(string path, string albumName)
        {
            var f = new TagLib.Mpeg.AudioFile(path);

            if (!f.Tag.Pictures.Any()) return;

            TagLib.IPicture pic = f?.Tag?.Pictures[0];

            var ms = new MemoryStream(pic.Data.Data);
            ms.Seek(0, SeekOrigin.Begin);

            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.StreamSource = ms;
            bitmap.EndInit();

            AlbumArtCollection.SharedAlbumArt[albumName] = bitmap;
        }

        public void GetImageFromMp3ForArtists(string path, string artist)
        {
            var f = new TagLib.Mpeg.AudioFile(path);

            if (!f.Tag.Pictures.Any()) return;

            TagLib.IPicture pic = f?.Tag?.Pictures[0];

            var ms = new MemoryStream(pic.Data.Data);
            ms.Seek(0, SeekOrigin.Begin);

            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.StreamSource = ms;
            bitmap.EndInit();

            AlbumArtCollection.SharedArtistArt[artist] = bitmap;
        }
        #endregion
    }
}
