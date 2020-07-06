using Jukebox.Model.Audio;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Jukebox.UI
{
    public class SongButtonGrid : Grid
    {
        public SongButtonGrid(Song song)
        {
            Setup(song);
        }

        private void Setup(Song song)
        {
            Background = Brushes.Transparent;

            var row0 = new RowDefinition();
            var row1 = new RowDefinition();
            var row2 = new RowDefinition();

            //title row
            row0.Height = new GridLength(0, GridUnitType.Auto);

            //album cover row
            row1.Height = new GridLength(0, GridUnitType.Star);
            row1.MaxHeight = 100; //could have some user made settings to give a more custom feel

            //album/band row
            row2.Height = new GridLength(0, GridUnitType.Auto);

            RowDefinitions.Add(row0);
            RowDefinitions.Add(row1);
            RowDefinitions.Add(row2);

            var tb = new TextBlock()
            {
                Text = song.Title,
                FontSize = 15,
                TextAlignment = TextAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Foreground = Brushes.White
            };

            SetColumn(tb, 0);

            var cover = new Image()
            {
                Source = new BitmapImage(new Uri(song.AlbumCoverPath)),
                Height = 100,
                MaxHeight = 100,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };

            SetColumn(cover, 1);

            var bandText = new TextBlock()
            {
                Text = song.Artist,
                FontSize = 15,
                TextAlignment = TextAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Foreground = Brushes.White
            };

            SetColumn(bandText, 2);
        }
    }
}
