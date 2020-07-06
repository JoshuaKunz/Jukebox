using Jukebox.Model.Audio;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jukebox.Services.Interfaces
{
    public interface IJukeboxService
    {
        Task ImportMusicFile(string filePath, string coverPath, string title, string artist);
        Task<List<Song>> GetAllSongs();
    }
}
