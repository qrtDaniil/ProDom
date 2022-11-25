

using System.Collections.ObjectModel;

namespace ProDom.MobileClient.ViewModels
{
    public class RequestsViewModel : BaseViewModel
    {

        private string _percentDecidedLabel;
        private int _percentDecidedProgress;

        public string percentDisabledLabel
        {
            get => _percentDecidedLabel;
            set
            {
                _percentDecidedLabel = value;
                OnPropertyChanged();
            }
        }

        public int percentDisabledProgress
        {
            get => _percentDecidedProgress;
            set
            {
                _percentDecidedProgress = value;
                OnPropertyChanged();
            }
        }





/* Необъединенное слияние из проекта "ProDom.MobileClient (net6.0-ios)"
До:
        public ObservableCollection<Models.Tables.Requests> Requests { get; } = new();
После:
        public ObservableCollection<Requests> Requests { get; } = new();
*/
        public ObservableCollection<Models.Requests> Requests { get; } = new();

        private async Task init()
        {
            IsLoading = true;
            if (! await server.IsHasConnection())
            {
                IsLoading = false;
                IsHasNotConnection = true;
            }
            else
            {
                IsHasNotConnection = false;
                if (!server.IsHasRequests())
                {
                    IsHasNotData = true;
                    IsLoading = false;
                }
                else
                {
                    var list = server.getRequests();
                    foreach (var request in list) Requests.Add(request);
                }
            }
        }

        public RequestsViewModel()
        {
            Reload = new Command(async () => await init());
        }

        private void setPercentDecided()
        {
            percentDisabledProgress = Requests.Count(x => x.isDecided == true) / Requests.Count;
            percentDisabledLabel = $"{percentDisabledProgress * 100}%";
        }
    }
}
