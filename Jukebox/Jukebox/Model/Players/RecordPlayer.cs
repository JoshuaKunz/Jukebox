using Jukebox.Model.Audio;
using System;
using System.Windows.Media;

namespace Jukebox.Model.Players
{
    public class RecordPlayer
    {
        private MediaPlayer _player;

        public RecordPlayer()
        {
            _player = new MediaPlayer
            {
                Volume = 100
            };
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
    }
}
