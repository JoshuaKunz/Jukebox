using Jukebox.Model.Audio;
using Jukebox.Services.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Jukebox.Services
{
    public class JukeboxService : IJukeboxService
    {
        public Task<List<Song>> GetAllSongs()
        {
            return Task.Run(() =>
            {
                var songList = new List<Song>();

                var path = Startup.AppDataPath;

                foreach (var folder in Directory.GetDirectories(path))
                {

                }

                return songList;
            });
        }

        public Task ImportMusicFile(string filePath, string coverPath,
                                                    string title, string artist)
        {
            return Task.Run(() =>
            {
                var path = Startup.AppDataPath;

                if (ArtistExistsInPath(path, artist))
                {
                    //check if song exists anywhere by title
                    if (SongExistsInPath(path, title))
                    {

                    }
                }
                else
                {

                }
            });
        }

        private bool ArtistExistsInPath(string path, string artist)
        {
            //check if the artist/band already exists
            foreach (var folder in Directory.GetDirectories(path))
            {
                if (folder == artist.ToUpper())
                {
                    return true;
                }
            }

            return false;
        }

        private bool SongExistsInPath(string path, string title)
        {
            foreach (var folder in Directory.GetDirectories(path))
            {

            }
        }
    }
}
