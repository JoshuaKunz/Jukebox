using Jukebox.Model.Audio;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Jukebox.UI
{
    public class SongsGrid : Grid
    {
        public SongsGrid(IEnumerable<Song> songs)
        {
            Setup(songs);
        }

        private void Setup(IEnumerable<Song> songs)
        {
            ColumnDefinition col0 = new ColumnDefinition();
            ColumnDefinition col1 = new ColumnDefinition();
            ColumnDefinition col2 = new ColumnDefinition();

            col0.Width = new GridLength(80, GridUnitType.Star);
            col1.Width = new GridLength(80, GridUnitType.Star);
            col2.Width = new GridLength(80, GridUnitType.Star);

            ColumnDefinitions.Add(col0);
            ColumnDefinitions.Add(col1);
            ColumnDefinitions.Add(col2);

            var columnCounter = 0;
            var rowCounter = 0;

            foreach (var song in songs)
            {
                switch (columnCounter)
                {
                    case 0:
                        {
                            var row = new RowDefinition
                            {
                                Height = new GridLength(80, GridUnitType.Auto)
                            };
                            RowDefinitions.Add(row);

                            var btn = new SongButton(song, GetPlaySongAction(song));

                            Children.Add(btn);

                            SetRow(btn, rowCounter);
                            SetColumn(btn, columnCounter);

                            columnCounter++;
                            break;
                        }
                    case 1:
                        {
                            var btn = new SongButton(song, GetPlaySongAction(song));

                            Children.Add(btn);

                            SetRow(btn, rowCounter);
                            SetColumn(btn, columnCounter);

                            columnCounter++;
                            break;
                        }
                    case 2:
                        {
                            var btn = new SongButton(song, GetPlaySongAction(song));

                            Children.Add(btn);

                            SetRow(btn, rowCounter);
                            SetColumn(btn, columnCounter);

                            columnCounter = 0;
                            rowCounter++;
                            break;
                        }
                }
            }
        }

        private Action GetPlaySongAction(Song song)
        {
            return new Action(() =>
            {

            });
        }
    }
}
