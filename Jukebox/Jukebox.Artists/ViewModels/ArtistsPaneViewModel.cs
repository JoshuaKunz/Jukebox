using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using Jukebox.Shared.ViewModels;
using System;
using System.Collections.ObjectModel;

namespace Jukebox.Artists.ViewModels
{
    public class ArtistsPaneViewModel : ViewModelBase
    {
        private readonly IMessenger _messenger;

        public ArtistsPaneViewModel(IMessenger messenger)
        {
            _messenger = messenger ?? throw new ArgumentNullException(nameof(messenger));
        }

        #region Properties
        public ObservableCollection<ArtistViewModel> Artists
        {
            get => _artists;
            set => Set(ref _artists, value);
        }
        private ObservableCollection<ArtistViewModel> _artists = new ObservableCollection<ArtistViewModel>();
        #endregion
    }
}
