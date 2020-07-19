using System.Windows.Media;

namespace Jukebox.Shared.Models
{
    public class SongModel
    {
        public string Artist { get; set; }
        public string Album { get; set; }
        public string Title { get; set; }
        public string Path { get; set; }
        public short TrackNumber { get; set; }
        public string Length { get; set; }
    }
}
