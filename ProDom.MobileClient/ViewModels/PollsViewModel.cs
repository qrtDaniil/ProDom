using Newtonsoft.Json;
using ProDom.MobileClient.Services;
using System.Collections.ObjectModel;

namespace ProDom.MobileClient.ViewModels
{
    public class PollsViewModel: BaseViewModel
    {

        private Task Init { get; set; }

        public Command OpenAddPoll { get; private set; }
        public Command OpenPoll { get; set; }
        public Command SetPositiveVoice { get; set; }
        public Command SetNegativeVoice { get; set; }
        public Command HidePoll { get; set; }
        public Command ChangeVoice { get; set; }
        public Command Search { get; set; }
        

        private ObservableCollection<Models.Visual.Poll> _polls = new();

        public ObservableCollection<Models.Visual.Poll> Polls
        {
            get => _polls;
            set
            {
                _polls = value;
                OnPropertyChanged();
            }
        }

        public PollsViewModel()
        {
            Reload = new Command(async () => await getPolls());

            //Search = new Command<string>(async (name) => await SearchPollsByName(name));

            Init = getPolls();
            OpenAddPoll = new Command(async () => await Application.Current.MainPage.Navigation.PushAsync(new Pages.Session.AddPollPage()));

            OpenPoll = new Command<object>(async (item) =>
            {
                Console.WriteLine((item as Models.Visual.Poll).Title);
                await Application.Current.MainPage.Navigation.PushAsync(new Session.OpenPollPage()
                {
                    BindingContext = item as Models.Visual.Poll
                });
            });
        }

        

        private async Task getPolls()
        {
            IsLoading = true;
            if (!await server.IsHasConnection())
            {
                IsLoading = false;
                IsHasNotConnection = false;
            } 
            else 
            {
                if (!await server.IsHasPolls())
                {
                    IsHasNotData = true;
                    IsLoading = false;
                }
                else
                {
                    IsHasNotData = false;

                    var list =await server.getPolls();
                    _polls.Clear();
                    foreach (var item in list)
                    {
                        var poll = new Models.Visual.Poll()
                        {
                            ID = item.Id,
                            Title = item.Title,
                            Description = item.Body,
                            IsVisible = true,
                            setPositiveVoice = new Command<object>(async (item) =>
                            {
                                ServerSets set = new(ser);
                                string result = await set.SetPollVote((item as Models.Visual.Poll).ID, Constants.Server.POLLS_USERANSWER_ACCEPTED);
                                if (result != Constants.Server.STATUS_SUCCESS)
                                {
                                    await Application.Current.MainPage.DisplayAlert("Ошибка", "Не удалось добавить Ваш ответ, попробуйте позже!", "ОК");
                                    await getPolls();
                                }
                                await Application.Current.MainPage.Navigation.PopAsync();
                            }),
                            setNegativeVoice = new Command<object>(async (item) =>
                            {
                                ServerSets set = new(ser);
                                string result = await set.SetPollVote((item as Models.Visual.Poll).ID, Constants.Server.POLLS_USERANSWER_DENIED);
                                if (result != Constants.Server.STATUS_SUCCESS)
                                {
                                    await Application.Current.MainPage.DisplayAlert("Ошибка", "Не удалось добавить Ваш ответ, попробуйте позже!", "ОК");
                                    await getPolls();
                                }
                                await Application.Current.MainPage.Navigation.PopAsync();
                            })
                    };
                        _polls.Add(poll);
                    }
                    Polls = _polls;

                }
            }
        }

        private Color setVoicedStatusColor(string userAnswer)
        {
            switch (userAnswer)
            {
                case Constants.Server.POLLS_USERANSWER_NOTANSWERED: return new Color(30, 65, 160);
                case Constants.Server.POLLS_USERANSWER_ACCEPTED: return new Color(1, 176, 1);
                case Constants.Server.POLLS_USERANSWER_DENIED: return new Color(248, 0, 26);
            }
            return null;
        }

        private string setVoicedStatus(string userAnswer)
        {
            switch(userAnswer)
            {
                case Constants.Server.POLLS_USERANSWER_NOTANSWERED: return "НЕТ ГОЛОСА";
                case Constants.Server.POLLS_USERANSWER_ACCEPTED: return "ЗА";
                case Constants.Server.POLLS_USERANSWER_DENIED: return "ПРОТИВ";
            }
            return null;
        }

        private string getTimeSpan(DateTime dateStart, TimeSpan timeConducting)
        {
            var timeRemaining = timeConducting - (DateTime.Now - dateStart);
            return $"Осталось: {timeRemaining.Days} д.";
        }


    }
}
