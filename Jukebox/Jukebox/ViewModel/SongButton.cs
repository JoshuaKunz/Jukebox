using GalaSoft.MvvmLight.Command;
using Jukebox.Model.Audio;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Jukebox.ViewModel
{
    public class SongButton : Button
    {
        private readonly Song _song;

        public SongButton(Song song, Action commandAction)
        {
            _song = song ?? throw new ArgumentNullException(nameof(song));
            Command = new RelayCommand(commandAction);

            Setup();
        }

        private void Setup()
        {
            var grid = new Grid();

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

            grid.RowDefinitions.Add(row0);
            grid.RowDefinitions.Add(row1);
            grid.RowDefinitions.Add(row2);

            var tb = new TextBlock()
            {
                Text = _song.Title,
                TextAlignment = TextAlignment.Center,
                Foreground = Brushes.White
            };

            Content = grid;
        }
    }
}
