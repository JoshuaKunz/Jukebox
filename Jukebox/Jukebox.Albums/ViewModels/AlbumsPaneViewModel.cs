using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using Jukebox.Shared.ViewModels;
using System.Collections;
using System.Collections.Generic;
using Jukebox.Shared.Classes;
using System.Collections.ObjectModel;

namespace Jukebox.Albums.ViewModels
{
    public class AlbumsPaneViewModel : ViewModelBase
    {
        private readonly IMessenger _messenger;

        public AlbumsPaneViewModel(IMessenger messenger)
        {
            _messenger.Register<IEnumerable<SongViewModel>>(this, Messages.AllSongsLoadedSendToAlbums, );
        }


        #region Properties
        public ObservableCollection<>
        #endregion

        #region Commands

        #endregion

        #region Command Methods

        #endregion

        #region Methods

        #endregion


    }
}
