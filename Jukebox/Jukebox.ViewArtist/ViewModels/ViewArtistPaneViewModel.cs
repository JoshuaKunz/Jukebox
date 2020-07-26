using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using Jukebox.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Jukebox.ViewArtist.ViewModels
{
    public class ViewArtistPaneViewModel : ViewModelBase
    {
        private readonly IMessenger _messenger;

        public ViewArtistPaneViewModel(IMessenger messenger)
        {
            _messenger = messenger ?? throw new ArgumentNullException(nameof(messenger));
        }

        #region Properties
        public ObservableCollection<AlbumViewModel> Albums
        {
            get => _albums;
            set => Set(ref _albums, value);
        }
        private ObservableCollection<AlbumViewModel> _albums = new ObservableCollection<AlbumViewModel>();
        #endregion
    }
}
