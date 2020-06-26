using Jukebox.Model.Audio;
using System;
using System.Windows.Media;

namespace Jukebox.Model.Players
{
    public class RecordPlayer
    {
        private MediaPlayer _player;

        private double _volume = 1.00;

        public RecordPlayer()
        {
            _player = new MediaPlayer
            {
                Volume = _volume
            };

            _player.MediaEnded += _player_MediaEnded;
        }

        private void _player_MediaEnded(object sender, EventArgs e)
        {
            //send message to jukebox to start the next song
        }

        public void Play(Song song)
        {
            _player.Open(new Uri(song.FilePath));
            _player.Play();
        }

        public void Play(string songPath)
        {
            _player.Open(new Uri(songPath));
            _player.Play();
        }

        public void Mute()
        {
            if(_player.IsMuted)
                return;

            _player.Volume = 0;
            _player.IsMuted = true;
        }

        public void UnMute()
        {
            if (!_player.IsMuted)
                return;

            _player.Volume = _volume;
            _player.IsMuted = false;
        }
    }
}
