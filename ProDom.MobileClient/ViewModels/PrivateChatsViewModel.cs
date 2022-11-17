using ProDom.MobileClient.Models;
using ProDom.MobileClient.Models.Tables;
using ProDom.MobileClient.Services;
using System.Collections.ObjectModel;

namespace ProDom.MobileClient.ViewModels
{

    public class PrivateChatsViewModel : BaseViewModel
    {
        private ObservableCollection<Message> _chats = new();

        public ObservableCollection<Message> chats
        {
            get => _chats;
            set
            {
                _chats = value;
                OnPropertyChanged();
            }
        }

        async Task init()
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
                if (!server.IsHasRequests())
                {
                    IsHasNotData = true;
                    IsLoading = false;
                }
                else
                {
                    var list = server.GetChats();
                    foreach (var item in list)
                    {
                        item.statusImageResouce = getStatusImageResourceByMessageStatus(item.status);
                        _chats.Add(item);
                    }

                    chats = _chats;
                }
            }
        }



        public PrivateChatsViewModel()
        {
            Reload = new Command(async () => await init());
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
                case Constants.Server.MESSAGE_STATUS_READED: return "messagestatus_readed.svg";
                default: return null;
            }
        }

        private string getTimeBefore(DateTime timeSended)
        {
            var timeAgo = "";
            var timeNow = DateTime.Now;
            TimeSpan ago = timeNow - timeSended;
            if (ago.Days > 30) { timeAgo = $"{ago.Days / 31} мес."; }
            else if (ago.TotalDays > 7) timeAgo = timeAgo = $"{(int)(timeNow - timeSended).TotalDays / 7} н";
            else if ((timeNow - timeSended).TotalDays > 0) timeAgo = timeAgo = $"{(int)(timeNow - timeSended).TotalDays} д";
            else if ((timeNow - timeSended).TotalHours > 0) timeAgo = timeAgo = $"{(int)(timeNow - timeSended).TotalHours} ч";
            else if ((timeNow - timeSended).TotalMinutes > 0) timeAgo = timeAgo = $"{(int)(timeNow - timeSended).TotalMinutes} мин";
            else timeAgo = "Сейчас";

            return timeAgo;
        }
    }
}
