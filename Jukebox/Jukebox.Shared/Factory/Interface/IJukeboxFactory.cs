using Jukebox.Shared.Models;
using Jukebox.Shared.ViewModels;
using System.Collections.Generic;
using System.Windows.Media;

namespace Jukebox.Shared.Factory.Interface
{
    public interface IJukeboxFactory
    {
        ImageSource GetImageFromMp3(string path);

        SongViewModel ConvertSongModel(SongModel model);
        IEnumerable<SongViewModel> ConvertSongModels(IEnumerable<SongModel> models);
    }
}
