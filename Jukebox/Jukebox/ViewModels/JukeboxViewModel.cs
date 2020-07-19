using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Jukebox.Albums.ViewModels;
using Jukebox.NowPlaying.ViewModels;
using Jukebox.Songs.ViewModels;
using Jukebox.Utility.ViewModels;
using System;
using System.Windows.Input;

namespace Jukebox.ViewModels
{
    public class JukeboxViewModel : ViewModelBase
    {
        public JukeboxViewModel(SongsPaneViewModel songsPaneViewModel,
            AlbumsPaneViewModel albumsPaneViewModel,
            NowPlayingPaneViewModel nowPlayingPaneViewModel,
            UtilityPaneViewModel utilityPaneViewModel)
        {
            SongsPaneViewModel = songsPaneViewModel ?? throw new ArgumentNullException(nameof(songsPaneViewModel));
            AlbumsPaneViewModel = albumsPaneViewModel ?? throw new ArgumentNullException(nameof(songsPaneViewModel));
            NowPlayingPaneViewModel = nowPlayingPaneViewModel ?? throw new ArgumentNullException(nameof(nowPlayingPaneViewModel));
            UtilityPaneViewModel = utilityPaneViewModel ?? throw new ArgumentNullException(nameof(utilityPaneViewModel));

            SongsButtonCommand = new RelayCommand(SongsButtonCommandMethod);
            AlbumsButtonCommand = new RelayCommand(AlbumsButtonCommandMethod);
            NowPlayingButtonCommand = new RelayCommand(NowPlayingButtonCommandMethod);
        }

        #region Properties
        public int SelectedIndex
        {
            get => _selectedIndex;
            set => Set(ref _selectedIndex, value);
        }
        private int _selectedIndex;
        #endregion

        #region Panes
        public SongsPaneViewModel SongsPaneViewModel { get; }
        public AlbumsPaneViewModel AlbumsPaneViewModel { get; }
        public NowPlayingPaneViewModel NowPlayingPaneViewModel { get; }
        public UtilityPaneViewModel UtilityPaneViewModel { get; }
        #endregion

        #region Commands
        public ICommand SongsButtonCommand { get; set; }
        public ICommand AlbumsButtonCommand { get; set; }
        public ICommand NowPlayingButtonCommand { get; set; }
        #endregion

        #region Command Methods
        private void SongsButtonCommandMethod() => SelectedIndex = 0;

        private void AlbumsButtonCommandMethod() => SelectedIndex = 1;

        private void NowPlayingButtonCommandMethod() => SelectedIndex = 2;
        #endregion
    }
}
