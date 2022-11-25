using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using ProDom.MobileClient.Models.Visual;
using ProDom.MobileClient.Services;

namespace ProDom.MobileClient.ViewModels
{
    [QueryProperty(nameof(Dialog), "Dialog")]
    public partial class ChatFormViewModel : BaseViewModel
    {

        Command ShowProfile { get; set; }
        private Models.Dialog dialog;

        public Models.Dialog Dialog
        {
            get => dialog;
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
            
        }

        async Task init()
        {
            Console.WriteLine("Checker init");
            if (server.IsHasNewMessages()) await UploadMessages();


        }

        Task Init { get; set; }

        public ChatFormViewModel()
        {
            Debug.WriteLine($"dialog responsed: {Dialog.Title}", "ChatFormViewModel");
            //init messages
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
                else
                {
                    IsHasNotData = false;
                    _messages.Clear();
                    List<Models.Message> list = server.GetDialog(dialog.DialogID);
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

        }




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
