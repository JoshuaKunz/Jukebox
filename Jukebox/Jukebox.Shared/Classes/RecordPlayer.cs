using GalaSoft.MvvmLight.Messaging;
using Jukebox.Shared.Extensions;
using Jukebox.Shared.ViewModels;
using System;
using System.Windows.Media;

namespace Jukebox.Shared.Classes
{
    public class RecordPlayer : MediaPlayer
    {
        private readonly IMessenger _messenger;

        public RecordPlayer(IMessenger messenger)
        {
            _messenger = messenger ?? throw new ArgumentNullException(nameof(messenger));
            Volume = 1.0;
            MediaEnded += RecordPlayer_MediaEnded;

            _messenger.RegisterMessageListener<SongViewModel>(this, Messages.PlaySong, PlaySong);
        }

        private void RecordPlayer_MediaEnded(object sender, EventArgs e)
        {
            _messenger.SendMessage(Messages.SongEnded);
        }

        public void PlaySong(SongViewModel song)
        {
            Open(new Uri(song.Path));
            Play();
            _messenger.SendMessage(song, Messages.SendSongToUtility);
        }

        public void PlaySong(NotificationMessage<SongViewModel> message)
        {
            PlaySong(message.Content);
        }
    }
}
