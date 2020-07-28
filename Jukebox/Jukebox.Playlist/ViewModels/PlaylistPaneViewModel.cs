using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using Jukebox.Shared.Classes;
using Jukebox.Shared.Extensions;
using Jukebox.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Jukebox.Playlist.ViewModels
{
    public class PlaylistPaneViewModel : ViewModelBase
    {
        private readonly IMessenger _messenger;

        public PlaylistPaneViewModel(IMessenger messenger)
        {
            _messenger = messenger ?? throw new ArgumentNullException(nameof(messenger));

            _messenger.RegisterMessageListener(this, Messages.SongEnded, SongEnded);
            _messenger.RegisterMessageListener<SongViewModel>(this, Messages.AddSongToPlaylist, AddSongToPlaylist);
        }

        #region Properties
        public ObservableCollection<SongViewModel> Songs
        {
            get => _songs;
            set => Set(ref _songs, value);
        }
        private ObservableCollection<SongViewModel> _songs = new ObservableCollection<SongViewModel>();
        #endregion

        #region Message Methods
        private void SongEnded(NotificationMessage message)
        {
            Songs.Remove(Songs.FirstOrDefault());

            if (Songs.Count > 0)
                _messenger.SendMessage(Songs.FirstOrDefault(), Messages.PlaySong);
            else
                _messenger.SendMessage((SongViewModel)null, Messages.SendSongToUtility);
        }

        private void AddSongToPlaylist(NotificationMessage<SongViewModel> message)
        {
            if (Songs.Count < 1)
            {
                Songs.Add(message.Content);
                _messenger.SendMessage(message.Content, Messages.PlaySong);
            }
            else
            {
                Songs.Add(message.Content);
            }
        }
        #endregion
    }
}
