using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using Jukebox.Shared.Classes;
using Jukebox.Shared.Extensions;
using Jukebox.Shared.ViewModels;
using System;

namespace Jukebox.Utility.ViewModels
{
    public class UtilityPaneViewModel : ViewModelBase
    {
        private readonly IMessenger _messenger;

        public UtilityPaneViewModel(IMessenger messenger)
        {
            _messenger = messenger ?? throw new ArgumentNullException(nameof(messenger));

            _messenger.RegisterMessageListener<SongViewModel>(this, Messages.SendSongToUtility, UpdateSong);
        }

        #region Properties
        public SongViewModel Song
        {
            get => _song;
            set => Set(ref _song, value);
        }
        private SongViewModel _song;
        #endregion

        #region Message Methods
        private void UpdateSong(NotificationMessage<SongViewModel> message)
        {
            Song = message.Content;
        }
        #endregion
    }
}
