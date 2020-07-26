using System.Collections.Generic;
using System.Windows.Media;

namespace Jukebox.Shared.Art
{
    public static class AlbumArtCollection
    {
        public static Dictionary<string, ImageSource> SharedAlbumArt = new Dictionary<string, ImageSource>();

        public static Dictionary<string, ImageSource> SharedArtistArt = new Dictionary<string, ImageSource>();
    }
}
