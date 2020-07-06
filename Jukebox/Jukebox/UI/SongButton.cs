using GalaSoft.MvvmLight.Command;
using Jukebox.Model.Audio;
using System;
using System.Windows.Controls;

namespace Jukebox.UI
{
    public class SongButton : Button
    {
        public SongButton(Song song, Action commandAction)
        {
            Command = new RelayCommand(commandAction);
            Setup(song);
        }

        private void Setup(Song song)
        {
            Content = new SongButtonGrid(song);
        }
    }
}
