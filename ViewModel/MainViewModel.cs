using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace QrLabel.ViewModel
{
    class MainViewModel : INotifyPropertyChanged
    {
        private string _url;

        public string Url 
        { 
            get => _url;
            set 
            {
                _url = value;
                OnPropertyChanged();
            }
            
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
