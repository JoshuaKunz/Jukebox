using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using Jukebox.Shared.Factory.Interface;
using Jukebox.Shared.Services.Interface;
using Jukebox.Shared.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Jukebox.Songs.ViewModels
{
    public class SongsPaneViewModel : ViewModelBase
    {
        private readonly IMessenger _messenger;
        private readonly IJukeboxFactory _factory;
        private readonly IJukeboxService _service;

        public SongsPaneViewModel(IMessenger messenger, IJukeboxFactory factory, IJukeboxService service)
        {
            _messenger = messenger ?? throw new ArgumentNullException(nameof(messenger));
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));
            _service = service ?? throw new ArgumentNullException(nameof(service));

            Load();
        }

        #region Properties
        public bool IsLoading
        {
            get => _isLoading;
            set => Set(ref _isLoading, value);
        }
        private bool _isLoading;

        public ObservableCollection<SongViewModel> Songs
        {
            get => _songs;
            set => Set(ref _songs, value);
        }
        private ObservableCollection<SongViewModel> _songs = new ObservableCollection<SongViewModel>();
        #endregion

        #region Loading
        public async Task Load()
        {
            try
            {
                IsLoading = true;
            }
            finally
            {
                IsLoading = false;
            }
        }
        #endregion
    }
}
