using ProDom.MobileClient.Constants;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ProDom.MobileClient.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected Services.Server ser;
        protected Services.ServerGets server;

        public BaseViewModel()
        {
            ser = new();
            server = new(ser);
        }

        private bool _isHasNotData;
        private bool _isHasNotConnection;
        private bool _isLoading;
        private bool _NotIsLoading;

        public Command Reload { get; set; }

        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                _isLoading = value;
                OnPropertyChanged();
            }
        }


        public bool IsHasNotData
        {
            get => _isHasNotData;
            set
            {
                _isHasNotData = value;
                OnPropertyChanged();
            }
        }

        public bool IsHasNotConnection
        {
            get => _isHasNotConnection;
            set
            {
                Shell.Current.DisplayAlert("Ошибка", "Отсутствует соединение, попробуйте, пожалуйста, позже", "OK");
                _isHasNotConnection = value;
                OnPropertyChanged();
            }
        }

        public bool NotIsLoading
        {
            get => _NotIsLoading;
            set 
            {
                _NotIsLoading = value;
                OnPropertyChanged();
            }
        }

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));



    }
}
