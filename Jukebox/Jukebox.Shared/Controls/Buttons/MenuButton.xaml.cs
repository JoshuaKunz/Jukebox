using System.Windows;
using System.Windows.Controls;

namespace Jukebox.Shared.Controls.Buttons
{
    public partial class MenuButton : Button
    {
        public MenuButton()
        {
            InitializeComponent();
        }

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(MenuButton),
                new FrameworkPropertyMetadata("Title", FrameworkPropertyMetadataOptions.AffectsRender));

        public FrameworkElement Image
        {
            get { return (FrameworkElement)GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }

        public static readonly DependencyProperty ImageProperty =
            DependencyProperty.Register("Image", typeof(FrameworkElement), typeof(MenuButton),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender));
    }
}
