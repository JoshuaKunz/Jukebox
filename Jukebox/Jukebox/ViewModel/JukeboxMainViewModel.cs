using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Jukebox.Factory.Interface;
using Jukebox.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;

namespace Jukebox.ViewModel
{
    public class JukeboxMainViewModel : ViewModelBase
    {
        private IJukeboxFactory _factory;
        private IJukeboxService _service;

        public JukeboxMainViewModel(IJukeboxService service,
                                    IJukeboxFactory factory)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));

            SongsClickCommand = new RelayCommand(SongsClickCommandMethod);
            AlbumsClickCommand = new RelayCommand(AlbumsClickCommandMethod);
            EditClickCommand = new RelayCommand(EditClickCommandMethod);
        }

        public void Load()
        {
            SongsViewModel = new SongsViewModel(_service, _factory);
        }

        #region Properties
        public int TabSelectedIndex
        {
            get => _tabSelectedIndex;
            set => Set(ref _tabSelectedIndex, value);
        }
        private int _tabSelectedIndex;
        #endregion


        #region Commands
        public ICommand SongsClickCommand { get; set; }
        public ICommand AlbumsClickCommand { get; set; }
        public ICommand EditClickCommand { get; set; }
        #endregion

        #region command methods
        public void SongsClickCommandMethod()
        {
            TabSelectedIndex = 0;
        }

        public void AlbumsClickCommandMethod()
        {
            TabSelectedIndex = 1;
        }

        public void EditClickCommandMethod()
        {
            TabSelectedIndex = 2;
        }
        #endregion

        #region Content Control
        public SongsViewModel SongsViewModel
        {
            get => _songsViewModel;
            set => Set(ref _songsViewModel, value);
        }
        private SongsViewModel _songsViewModel;
        #endregion
    }
}
