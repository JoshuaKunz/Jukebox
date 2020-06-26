using Jukebox.ViewModel;
using System.Windows;

namespace Jukebox.View
{
    public partial class SplashView : Window
    {
        public SplashView(SplashViewModel viewModel)
        {
            DataContext = viewModel;
            InitializeComponent();
        }
    }
}
