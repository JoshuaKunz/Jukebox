using Jukebox.ViewModel;
using System.Windows;

namespace Jukebox.View
{
    public partial class JukeboxMainView : Window
    {
        public JukeboxMainView(JukeboxMainViewModel viewModel)
        {
            DataContext = viewModel;
            InitializeComponent();
        }
    }
}
