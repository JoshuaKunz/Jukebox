using GalaSoft.MvvmLight;
using Jukebox.Factory.Interface;
using Jukebox.Services.Interfaces;
using NAudio.MediaFoundation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Jukebox.ViewModel
{
    public class SongsViewModel : ViewModelBase
    {
        private readonly IJukeboxFactory _factory;
        private readonly IJukeboxService _service;

        public Grid SongsGrid
        {
            get => _songsGrid;
            set => Set(ref _songsGrid, value);
        }
        private Grid _songsGrid;

        

        public SongsViewModel(IJukeboxService service, IJukeboxFactory factory)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));

            Setup();
        }

        private void Setup()
        {
            var grid = new Grid();

            ColumnDefinition col0 = new ColumnDefinition();
            ColumnDefinition col1 = new ColumnDefinition();
            ColumnDefinition col2 = new ColumnDefinition();

            col0.Width = new GridLength(80, GridUnitType.Star);
            col1.Width = new GridLength(80, GridUnitType.Star);
            col2.Width = new GridLength(80, GridUnitType.Star);

            grid.ColumnDefinitions.Add(col0);
            grid.ColumnDefinitions.Add(col1);
            grid.ColumnDefinitions.Add(col2);

            var columnCounter = 0;
            var rowCounter = 0;
            for (var i = 0; i < 10; i++)
            {
                switch (columnCounter)
                {
                    case 0:
                        {
                            var row = new RowDefinition();
                            row.Height = new GridLength(80, GridUnitType.Auto);
                            grid.RowDefinitions.Add(row);

                            var btn = new Button
                            {
                                Content = $"Test-{i}"
                            };

                            grid.Children.Add(btn);

                            Grid.SetRow(btn, rowCounter);
                            Grid.SetColumn(btn, columnCounter);

                            columnCounter++;
                            break;
                        }
                    case 1:
                        {
                            var btn = new Button
                            {
                                Content = $"Test-{i}"
                            };

                            grid.Children.Add(btn);

                            Grid.SetRow(btn, rowCounter);
                            Grid.SetColumn(btn, columnCounter);

                            columnCounter++;
                            break;
                        }
                    case 2:
                        {
                            var btn = new Button
                            {
                                Content = $"Test-{i}"
                            };

                            grid.Children.Add(btn);

                            Grid.SetRow(btn, rowCounter);
                            Grid.SetColumn(btn, columnCounter);

                            columnCounter = 0;
                            rowCounter++;
                            break;
                        }
                }
            }

            SongsGrid = grid;
        }
    }
}
