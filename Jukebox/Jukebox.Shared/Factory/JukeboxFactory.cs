using Jukebox.Shared.Factory.Interface;
using Jukebox.Shared.Models;
using Jukebox.Shared.ViewModels;
using System.Collections.Generic;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Linq;
using GalaSoft.MvvmLight.Messaging;
using System;

namespace Jukebox.Shared.Factory
{
    public class JukeboxFactory : IJukeboxFactory
    {
        private readonly IMessenger _messenger;

        public JukeboxFactory(IMessenger messenger)
        {
            _messenger = messenger ?? throw new ArgumentNullException(nameof(messenger));
        }

        public SongViewModel ConvertSongModel(SongModel model) => new SongViewModel(_messenger)
        {
            Artist = model.Artist,
            Album = model.Album,
            CoverImage = GetImageFromMp3(model.Path),
            Path = model.Path,
            Length = model.Length,
            TrackNumber = model.TrackNumber,
            Title = model.Title
        };

        public IEnumerable<SongViewModel> ConvertSongModels(IEnumerable<SongModel> models) => models.Select(ConvertSongModel);

        public ImageSource GetImageFromMp3(string path)
        {
            var f = new TagLib.Mpeg.AudioFile(path);

            if (f?.Tag?.Pictures[0] == null) return null;

            TagLib.IPicture pic = f?.Tag?.Pictures[0];

            var ms = new MemoryStream(pic.Data.Data);
            ms.Seek(0, SeekOrigin.Begin);

            // ImageSource for System.Windows.Controls.Image
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.StreamSource = ms;
            bitmap.EndInit();

            return bitmap;
        }
    }
}
