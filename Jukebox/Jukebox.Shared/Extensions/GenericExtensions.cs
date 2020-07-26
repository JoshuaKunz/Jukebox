using Jukebox.Shared.ViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Jukebox.Shared.Extensions
{
    public static class GenericExtensions
    {
        public static ObservableCollection<SongViewModel> ToObservableCollection(this IEnumerable<SongViewModel> songs)
        {
            var obs = new ObservableCollection<SongViewModel>();

            foreach (var song in songs)
            {
                obs.Add(song);
            }

            return obs;
        }

        public static ObservableCollection<AlbumViewModel> ToObservableCollection(this IEnumerable<AlbumViewModel> albums)
        {
            var obs = new ObservableCollection<AlbumViewModel>();

            foreach(var album in albums)
            {
                obs.Add(album);
            }

            return obs;
        }
    }
}
