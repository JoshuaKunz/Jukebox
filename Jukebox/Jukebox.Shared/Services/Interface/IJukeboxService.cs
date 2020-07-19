using Jukebox.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jukebox.Shared.Services.Interface
{
    public interface IJukeboxService
    {
        Task<IEnumerable<SongModel>> GetAllSongs();
    }
}
