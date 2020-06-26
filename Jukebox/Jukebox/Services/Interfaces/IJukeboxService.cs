using System.Threading.Tasks;

namespace Jukebox.Services.Interfaces
{
    public interface IJukeboxService
    {
        Task ImportMusicFile(string filePath);
    }
}
