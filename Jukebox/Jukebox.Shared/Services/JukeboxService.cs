using Jukebox.Shared.Models;
using Jukebox.Shared.Services.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Jukebox.Shared.Services
{
    public class JukeboxService : IJukeboxService
    {
        public Task<IEnumerable<SongModel>> GetAllSongs()
        {
            return Task.Run(() =>
            {
                var musicFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);

                var songs = new List<SongModel>();

                foreach (var folder in Directory.GetDirectories(musicFolder))
                {
                    var ext = new List<string> { "mp3" };
                    var files = Directory.EnumerateFiles(folder, "*.*", SearchOption.AllDirectories).Where(s => ext.Contains(Path.GetExtension(s).ToLowerInvariant()));
                }

                return songs.AsEnumerable();
            });

        }

        private IEnumerable<SongModel> ConvertFilePathsToSongModel(IEnumerable<string> paths)
        {
            var songModels = new List<SongModel>();

            foreach (var path in paths)
            {

            }

            return songModels.AsEnumerable();
        }
    }
}
