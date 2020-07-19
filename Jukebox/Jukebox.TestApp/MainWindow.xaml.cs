using Jukebox.TestApp.ViewModel;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using TagLib;
using TagLib.Image;

namespace Jukebox.TestApp
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new WindowViewModel();

            //var file = @"C:\Users\engnd\Desktop\Metallica - Hardwired...To Self-Destruct\Metallica Am I savage (oficial audio).mp3";

            //var image = GetImageFromMp3(file);

            ////MyImage = (BitmapImage)image.Source;

            ////MyGrid.Children.Add(image);
            //MetImage.Source = image.Source;

            //MyImage = image.Source;

            //MetImage2.Source = MyImage;

            //MyGrid.UpdateLayout();
        }

        //public System.Windows.Controls.Image GetImageFromMp3(string file)
        //{
        //    var f = new TagLib.Mpeg.AudioFile(file);
        //    TagLib.IPicture pic = f.Tag.Pictures[0];
        //    MemoryStream ms = new MemoryStream(pic.Data.Data);
        //    ms.Seek(0, SeekOrigin.Begin);

        //    // ImageSource for System.Windows.Controls.Image
        //    BitmapImage bitmap = new BitmapImage();
        //    bitmap.BeginInit();
        //    bitmap.StreamSource = ms;
        //    bitmap.EndInit();

        //    // Create a System.Windows.Controls.Image control
        //    System.Windows.Controls.Image img = new System.Windows.Controls.Image();
        //    img.Source = bitmap;
        //    return img;
        //}

        //public ImageSource MyImage { get; set; }
    }
}
