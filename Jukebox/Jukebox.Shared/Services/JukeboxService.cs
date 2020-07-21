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
                    //var ext = new List<string> { "mp3" };
                    var files = Directory.EnumerateFiles(folder, "*.mp3", SearchOption.AllDirectories);
                    songs.AddRange(ConvertFilePathsToSongModel(files));
                }

                return songs.AsEnumerable();
            });
        }

        private IEnumerable<SongModel> ConvertFilePathsToSongModel(IEnumerable<string> paths)
        {
            var songModels = new List<SongModel>();

            foreach (var path in paths)
            {
                var file = TagLib.File.Create(path).Tag;

                songModels.Add(new SongModel
                {
                    Artist = file.FirstAlbumArtist,
                    Title = file.Title,
                    TrackNumber = (short)file.Track,
                    Path = path,
                    Year = (short)file.Year,
                    Album = file.Album
                });
            }

            return songModels.AsEnumerable();
        }
    }
}
