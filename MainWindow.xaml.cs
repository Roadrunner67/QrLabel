using QrLabel.ViewModel;

using System.Windows;

namespace QrLabel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel _vm;

        public MainWindow()
        {
            InitializeComponent();
            _vm = new MainViewModel();
            DataContext = _vm;
            _vm.Url = "https://www.gocomics.com/calvinandhobbes";
        }

        private void SetUserControl_Click(object sender, RoutedEventArgs e)
        {
            TestQr.Url = UrlText.Text;
        }
        private void SetViewModel_Click(object sender, RoutedEventArgs e)
        {
            TestQr.Url = UrlText.Text;
        }
        
    }
}
