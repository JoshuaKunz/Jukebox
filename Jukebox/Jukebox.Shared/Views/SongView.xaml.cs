using System.DirectoryServices.ActiveDirectory;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Jukebox.Shared.Views
{
    public partial class SongView : Button
    {
        public SongView()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(SongView),
                new FrameworkPropertyMetadata("Title", FrameworkPropertyMetadataOptions.AffectsRender));

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public static readonly DependencyProperty YearProperty =
            DependencyProperty.Register("Year", typeof(string), typeof(SongView),
                new FrameworkPropertyMetadata("Year", FrameworkPropertyMetadataOptions.AffectsRender));

        public string Year
        {
            get => (string)GetValue(YearProperty);
            set => SetValue(YearProperty, value);
        }

        public static readonly DependencyProperty ImageProperty =
            DependencyProperty.Register(nameof(Image), typeof(ImageSource), typeof(SongView),
                new UIPropertyMetadata(null));

        public ImageSource Image
        {
            get => (ImageSource)GetValue(ImageProperty);
            set => SetValue(ImageProperty, value);
        }
    }
}
