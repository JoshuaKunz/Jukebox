using GalaSoft.MvvmLight.Messaging;
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
        }

        private void RecordPlayer_MediaEnded(object sender, EventArgs e)
        {
            //send message to let the playlist know that the media has ended
            _messenger.Send(Messages.SongEnded);
        }

        public void PlaySong(SongViewModel song)
        {
            Open(new Uri(song.Path));
            Play();
        }
    }
}
