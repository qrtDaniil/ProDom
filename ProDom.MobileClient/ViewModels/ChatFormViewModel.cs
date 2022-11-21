using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProDom.MobileClient.Models.Visual;
using ProDom.MobileClient.Services;

namespace ProDom.MobileClient.ViewModels
{
    public partial class ChatFormViewModel : BaseViewModel, IQueryAttributable
    {
        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Dialog = query["Dialog"] as Models.Dialog;
        }

        Command ShowProfile { get; set; }
        Timer _timer;
        Models.Dialog dialog;

        public Models.Dialog Dialog
        {
            get {
                Console.WriteLine($"dialog.title: {dialog.Title}");
                return dialog; }
            set
            {
                dialog = value;
                OnPropertyChanged();
            }
        }

        public Command SendMessage { get; private set; }



        private ObservableCollection<MessageInChat> _messages = new();
        public bool isBackButtonVisible;
        private string _newMessageText ="";


        public ObservableCollection<MessageInChat> Messages
        {
            get => _messages;
            set
            {
                if (value != _messages)
                {
                    _messages = value;
                    OnPropertyChanged();
                }
            }
        }

        public string NewMessageText
        {   
            get => _newMessageText;
            set
            {
                _newMessageText = value;
                OnPropertyChanged(nameof(NewMessageText));
            }
        }
      

        async Task UploadMessages()
        {
            IsLoading = true;
            if (!server.IsHasConnection())
            {
                IsLoading = false;
                IsHasNotConnection = true;
            }
            else
            {
                IsHasNotConnection = false;
                if (!server.IsHasMessages())
                {
                    IsHasNotData = true;
                    IsLoading = false;
                }
                //else
                {
                    Console.WriteLine("Upload is running1");
                    IsHasNotData = false;
                    Console.WriteLine("Upload is running2");
                    _messages.Clear();
                    Console.WriteLine("Upload is running3");
                    List<Models.Message> list = server.GetDialog(dialog.DialogID);
                    Console.WriteLine("Upload is running4");
                    Console.WriteLine($"[Messages] List length: {list.Count}");
                    foreach (var item in list)
                    {
                        MessageInChat message = new()
                        {
                            SenderID = item.userId,
                            ID = item.messageId,
                            Message = item.message,
                            UserImage = item.imageResource,
                            MessageFrom = item.messageFrom,
                            timeSended = TimeToString(item.sendedAt),

                            GridColumnMessage = item.messageFrom ==
                                Constants.Server.MESSAGE_FROM_ANOTHER ? 1 : 0,
                            GridColumnImage = item.messageFrom ==
                                Constants.Server.MESSAGE_FROM_ANOTHER ? 0 : 1,
                            statusImage = getStatusImageResourceByMessageStatus(item.status),
                            HorizontalOption = item.messageFrom ==
                                Constants.Server.MESSAGE_FROM_ANOTHER ? "start" : "end",
                            Background = item.messageFrom == Constants.Server.MESSAGE_FROM_ANOTHER ?
                                Color.FromRgb(234, 221, 248) : Color.FromRgb(240, 235, 245),
                        };
                        _messages.Add(message);
                    }

                    Messages = _messages;
                    IsLoading = false;
                    Console.WriteLine("Upload is ended");
                    Console.WriteLine($"Chats length: {_messages.Count}");
                }
            }
        }

        async Task init()
        {
            Console.WriteLine("Checker init");
            if (server.IsHasNewMessages()) await UploadMessages();


        }

        Task Init { get; set; }

        public ChatFormViewModel()
        {
            Console.WriteLine("init viewmodel");
            SendMessage = new Command<string>(async (string message) => {
                ServerSets serverSets = new ServerSets(ser);
                IsLoading = true;
                Console.WriteLine($"message: {message}");
                if (message == null) return;
                if (!ser.IsHasConnection())
                {
                    IsLoading = false;
                    IsHasNotConnection = true;
                } else
                {
                    string Result = await serverSets.SendMessage(Dialog.DialogID, message);
                    if (Result == Constants.Server.STATUS_SUCCESS) NewMessageText = "";
                    if (Result == Constants.Server.STATUS_DENIED) await Application.Current.MainPage.DisplayAlert("Ошибка", "Ошибка при отправке сообщения, попробуйте позже", "ОК");
                }
            });

            _timer = new Timer(new TimerCallback(async (s) => await init()),
                          null, TimeSpan.Zero, TimeSpan.FromMilliseconds(300));
            Init = UploadMessages();
        }

        ~ChatFormViewModel() => _timer.Dispose();



        private static string getStatusImageResourceByMessageStatus(string status)
        {
            switch (status)
            {
                case Constants.Server.MESSAGE_STATUS_ERROR: return "messagestatus_error.svg";
                case Constants.Server.MESSAGE_STATUS_NOTREADED: return "messagestatus_newmessages.svg";
                case Constants.Server.MESSAGE_STATUS_SENDED: return "messagestatus_notreaded.svg";
                default: return null;
            }
        }

        private string TimeToString(DateTime timeSended)
        {
            return $"{timeSended.Hour}:{timeSended.Minute}";
        }


    }
}
