using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Jukebox.Shared.Views
{
    public partial class ArtistView : Button
    {
        public ArtistView()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty ArtistProperty =
            DependencyProperty.Register(nameof(Artist), typeof(string), typeof(SongView),
                new FrameworkPropertyMetadata(nameof(Artist), FrameworkPropertyMetadataOptions.AffectsRender));

        public string Artist
        {
            get => (string)GetValue(ArtistProperty);
            set => SetValue(ArtistProperty, value);
        }

        public static readonly DependencyProperty CoverImageProperty =
            DependencyProperty.Register(nameof(ArtistCoverImage), typeof(ImageSource), typeof(SongView),
                new UIPropertyMetadata(null));

        public ImageSource ArtistCoverImage
        {
            get => (ImageSource)GetValue(CoverImageProperty);
            set => SetValue(CoverImageProperty, value);
        }
    }
}
