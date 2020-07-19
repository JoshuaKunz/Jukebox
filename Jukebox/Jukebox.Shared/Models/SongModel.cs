using System;
using System.IO;
using System.Windows.Media.Imaging;

namespace Jukebox.Shared.Models
{
    public class SongModel
    {
        public string Artist { get; set; }
        public string Title { get; set; }
        public string Path { get; set; }
        public short TrackNumber { get; set; }
        public TimeSpan Length { get; set; }
        public BitmapImage CoverImage { get; set; }
    }
}
