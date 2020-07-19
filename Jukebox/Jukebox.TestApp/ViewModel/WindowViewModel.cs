using GalaSoft.MvvmLight;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Jukebox.TestApp.ViewModel
{
    public class WindowViewModel : ViewModelBase
    {

        public WindowViewModel()
        {
            Path = @"C:\Users\engnd\Desktop\Metallica - Hardwired...To Self-Destruct\Metallica Am I savage (oficial audio).mp3";
            //BitMap = GetImageFromMp3(Path).Source;
            GetImageFromMp3(Path);
        }

        public ImageSource MyImageSource
        {
            get => _imageSource;
            set => Set(ref _imageSource, value);
        }
        private ImageSource _imageSource;

        public string Path
        {
            get => _path;
            set => Set(ref _path, value);
        }
        private string _path;

        private void GetImageFromMp3(string file)
        {
            var f = new TagLib.Mpeg.AudioFile(file);
            TagLib.IPicture pic = f.Tag.Pictures[0];

            ImageSource imageSource;

            var ms = new MemoryStream(pic.Data.Data);
            ms.Seek(0, SeekOrigin.Begin);

            // ImageSource for System.Windows.Controls.Image
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.StreamSource = ms;
            bitmap.EndInit();

            imageSource = bitmap;
            MyImageSource = imageSource;
        }
    }
}
