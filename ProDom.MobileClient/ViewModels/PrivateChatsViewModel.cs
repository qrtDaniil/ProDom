using ProDom.MobileClient.Models;
using ProDom.MobileClient.Services;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Timers;

namespace ProDom.MobileClient.ViewModels
{

    public class PrivateChatsViewModel : BaseViewModel
    {
        private CancellationTokenSource _cts;
        private ObservableCollection<Models.Visual.MessageInPrivateChats> _chats = new();
        private Task Init { get; set; }
        public Command OpenDialog { get; set; }

        public ObservableCollection<Models.Visual.MessageInPrivateChats> Chats
        {
            get => _chats;
            set
            {
                if (_chats != value)
                {
                    _chats = value;
                    OnPropertyChanged();
                }
            }
        }




        async Task init()
        {
            while (true)
            {
                await Task.Run(async () =>
                {
                    if (server.IsHasNewMessages()) await UploadMessages(_cts.Token);
                });
                await Task.Delay(500);
            }
        }

        private async Task UploadMessages(CancellationToken token)
        {
            try
            {
                //while (true)
                {
                    IsLoading = true;
                    NotIsLoading = false;
                    if (!server.IsHasConnection())
                    {
                        IsLoading = false;
                        NotIsLoading = true;
                        IsHasNotConnection = true;
                    }
                    else
                    {
                        IsHasNotConnection = false;
                        if (!server.IsHasMessages())
                        {
                            IsHasNotData = true;
                            IsLoading = false;
                            NotIsLoading = true;
                        }
                        else
                        {
                            IsHasNotData = false;
                            _chats.Clear();
                            List<Models.Message> list = server.GetChats();
                            Console.WriteLine($"List length: {list.Count}");
                            foreach (var item in list)
                            {
                                Models.Visual.MessageInPrivateChats message = new()
                                {
                                    DialogID = item.dialogId,
                                    MessageID = item.messageId,
                                    LastMessageText = item.message,
                                    notReadedCount = item.notReadedCount,
                                    isHasNotReaded = item.notReadedCount > 0,
                                    isHasNotNotReaded = item.notReadedCount == 0,
                                    ImageStatusResource = getStatusImageResourceByMessageStatus(item.status),
                                    TimeBeforeLastMessage = getTimeBefore(item.sendedAt),

                                    Title = item.userName,
                                    UserImageResource = item.imageResource
                                };
                                _chats.Add(message);
                            }

                            Chats = _chats;
                            IsLoading = false;
                            NotIsLoading = true;
                            Console.WriteLine($"Chats length: {Chats.Count}");
                        }
                    }
                    await Task.Delay(1000, token);
                }
            }
            catch (OperationCanceledException)
            { } // сработала отмена, ничего не делать
        }





        public PrivateChatsViewModel()
        {
            OpenDialog = new Command<Models.Visual.MessageInPrivateChats>(async (Models.Visual.MessageInPrivateChats message) =>
            {
                Models.Dialog Dialog = new()
                {
                    Title = message.Title,
                    DialogID = message.DialogID,
                    Type = Constants.Server.DIALOG_TYPE_PRIVATE
                };
                Debug.WriteLine($"Dialog sended: {Dialog.Title}", "PrivateChatsViewModel");
                await Shell.Current.GoToAsync($"chats/ChatForm", true, new Dictionary<string, object>
                {
                    ["Dialog"] = Dialog
                });

            });

            _cts = new CancellationTokenSource();
            Init = UploadMessages(_cts.Token);
        }


        /*

        public async Task<IList<MessageForAllChat>> getUsersWithMessages()
        {
            IList<MessageForAllChat> usersWithMessages;

            Database.SmartYardDB db = new Database.SmartYardDB();
            var res = await db.getUsersWithMessages();

            usersWithMessages = new List<MessageForAllChat>();

            foreach (var user in res)
            {
                usersWithMessages.Add(new MessageForAllChat
                {
                    userId = user.userId,
                    userName = user.Name,
                    imageResource = user.ImageResource,

                    lastMessage = (await db.GetLastMessageByUserId(user.userId)).message,
                    timeBeforelastMessage = getTimeBefore((await db.GetLastMessageByUserId(user.userId)).timeSended),
                    notReadedCount = await (db.GetNotReadedCountByUserId(user.userId)),
                    statusImageResouce = getStatusImageResourceByMessageStatus((await db.GetLastMessageByUserId(user.userId)).status)

                });
            }
            return usersWithMessages;
        }

        */



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

        private string getTimeBefore(DateTime timeSended)
        {
            var timeAgo = "";
            var timeNow = DateTime.Now;
            TimeSpan ago = timeNow - timeSended;
            if (ago.Days > 30) { timeAgo = $"{ago.Days / 31} мес."; }
            else if (ago.TotalDays > 7) timeAgo = $"{(int)ago.TotalDays / 7} н";
            else if (ago.TotalDays > 0) timeAgo = $"{(int)ago.TotalDays} д";
            else if (ago.TotalHours > 0) timeAgo =  $"{(int)ago.TotalHours} ч";
            else if (ago.TotalMinutes > 0) timeAgo = $"{(int)ago.TotalMinutes} мин";
            else timeAgo = "Сейчас";

            return timeAgo;
        }
    }
}
