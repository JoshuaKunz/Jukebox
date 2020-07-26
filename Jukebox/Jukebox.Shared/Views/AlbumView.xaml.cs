using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Jukebox.Shared.Views
{
    public partial class AlbumView : Button
    {
        public AlbumView()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty AlbumTitleProperty =
            DependencyProperty.Register("AlbumTitle", typeof(string), typeof(SongView),
                new FrameworkPropertyMetadata("AlbumTitle", FrameworkPropertyMetadataOptions.AffectsRender));

        public string AlbumTitle
        {
            get => (string)GetValue(AlbumTitleProperty);
            set => SetValue(AlbumTitleProperty, value);
        }

        public static readonly DependencyProperty AlbumYearProperty =
            DependencyProperty.Register("AlbumYear", typeof(string), typeof(SongView),
                new FrameworkPropertyMetadata("AlbumYear", FrameworkPropertyMetadataOptions.AffectsRender));

        public string AlbumYear
        {
            get => (string)GetValue(AlbumYearProperty);
            set => SetValue(AlbumYearProperty, value);
        }

        public static readonly DependencyProperty CoverImageProperty =
            DependencyProperty.Register(nameof(CoverImage), typeof(ImageSource), typeof(SongView),
                new UIPropertyMetadata(null));

        public ImageSource CoverImage
        {
            get => (ImageSource)GetValue(CoverImageProperty);
            set => SetValue(CoverImageProperty, value);
        }
    }
}
