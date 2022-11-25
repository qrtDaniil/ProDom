using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProDom.MobileClient.Services
{
    public class ServerGets: Server
    {
        public ServerGets(Server server)
        {
            Server = server;
        }

        public Server Server { get; }

        // Users //

        public bool IsSession()
        {
            return true;
        }

        public Models.CurrentUser GetCurrentUserInfo()
        {
            string userAPI = Preferences.Default.Get("API", "0");
            if(userAPI == "0") return null;
            return null;
        }

        // Polls //

        public async Task<bool> IsHasPolls()
        {
            await Init("");

        }

        public List<Models.Poll> getPolls()
        {
            return new List<Models.Poll>()
            {
                new Models.Poll() {
                    ID = 0,
                    Title = "Очистка подъезда",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas feugiat placerat justo sit amet blandit. Proin malesuada neque at pellentesque convallis. Etiam facilisis augue pharetra, rhoncus sapien at, maximus nibh. Sed faucibus rutrum ultrices. Curabitur condimentum nunc in erat aliquet, sed dictum magna mollis. Nulla quis orci quis massa tristique venenatis. Cras urna ipsum, gravida quis pellentesque in, mattis nec diam.\r\n\r\nNunc ut metus a odio porttitor luctus. Nam mattis lobortis magna at euismod. Fusce non aliquet nibh. Vestibulum sed urna mattis, interdum magna sed, luctus felis. Mauris auctor tempor tortor, sit amet venenatis risus elementum a. Donec vitae consequat tellus. Vestibulum at mollis lectus. Praesent consequat commodo tellus, nec aliquet sapien venenatis non. Fusce hendrerit auctor ex, a convallis dolor eleifend quis. Donec pharetra lacus quis sapien semper ultricies. Suspendisse id enim sapien. Fusce tincidunt laoreet nulla in bibendum. Quisque tempus libero risus, non tincidunt nisl sodales vitae. Vestibulum pulvinar lacus pharetra erat pellentesque, non semper justo efficitur.\r\n\r\nPraesent aliquet, lorem non cursus efficitur, metus turpis rutrum enim, non hendrerit orci ipsum sit amet libero. Nunc venenatis velit at nisl viverra posuere. Duis vehicula, mi fringilla feugiat sodales, metus eros pulvinar ipsum, ac tincidunt ipsum eros at est. Morbi hendrerit massa vel suscipit imperdiet. Vivamus dapibus porttitor diam, et vestibulum sapien. Sed eu gravida elit. Pellentesque a elit ut nisi pellentesque pharetra vitae nec quam. Morbi in mauris consectetur, finibus sapien a, blandit orci. Duis tempus nibh ac lectus fermentum vestibulum. Cras venenatis finibus ipsum, sit amet ultrices sapien tempus posuere. In placerat, libero quis pellentesque blandit, est nibh hendrerit orci, eu interdum est lacus eu felis. Cras egestas purus quis urna dictum, eget egestas felis sagittis.",
                    DateStart = DateTime.Now.AddDays(-3),
                    TimeConducting = new TimeSpan(5,0,0,0),
                    Status = Constants.Server.POLLS_STATUS_ACTIVE,
                    UserAnswer = Constants.Server.POLLS_USERANSWER_NOTANSWERED
                }
            };
        }

        // Requests //

        public bool IsHasRequests()
        {
            return false;
        }


        public List<Models.Requests> getRequests()
        {
            return null;
        }

        

        // chats //

        public bool IsHasMessages()
        {
            return true;
        }

        public bool IsHasDialogWithUser(int userId)
        {
            return false;
        }


        public List<Models.Message> GetChats()
        {
            return new List<Models.Message>()
            {
                new Models.Message()
                {
                    userName = "Даниил Филиппов",
                    imageResource = "user_no_image.png",
                    dialogId = 0,
                    messageId = 0,
                    status = Constants.Server.MESSAGE_STATUS_NOTREADED,
                    message = "соси писю",
                    sendedAt = DateTime.Now,
                    messageFrom = Constants.Server.MESSAGE_FROM_ANOTHER,
                    notReadedCount = 3
                }
            };
        }


        public List<Models.Message> GetDialog(int dialogID)
        {
            Console.WriteLine("Method init");
            List<Models.Message> MsgList = new();

            MsgList.Add(new Models.Message()
            {
                userId = 0,
                messageId = 0,
                userName = "Даниил Филиппов",
                imageResource = "user_no_image.png",
                message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed nisl lacus, efficitur non enim eu, aliquet imperdiet justo. Vivamus sit amet mauris eros. Maecenas pulvinar interdum orci, ut pulvinar magna pellentesque in. Nam ut nisi vel nibh luctus interdum a quis enim. Donec quis finibus lacus, non dapibus est. Donec suscipit mauris consectetur quam bibendum, vel lobortis ligula egestas. Duis a mauris tellus. Fusce suscipit ac lorem sit amet vehicula.",
                messageFrom = Constants.Server.MESSAGE_FROM_ANOTHER,
                status = Constants.Server.MESSAGE_STATUS_NOTREADED,
                sendedAt = DateTime.Now,
            });

            MsgList.Add(new Models.Message()
            {
                userId = 0,
                messageId = 0,
                userName = "",
                imageResource = "user_no_image.png",
                message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed nisl lacus, efficitur non enim eu, aliquet imperdiet justo. Vivamus sit amet mauris eros. Maecenas pulvinar interdum orci, ut pulvinar magna pellentesque in. Nam ut nisi vel nibh luctus interdum a quis enim. Donec quis finibus lacus, non dapibus est. Donec suscipit mauris consectetur quam bibendum, vel lobortis ligula egestas. Duis a mauris tellus. Fusce suscipit ac lorem sit amet vehicula.",
                messageFrom = Constants.Server.MESSAGE_FROM_CURRENT,
                status = Constants.Server.MESSAGE_STATUS_NOTREADED,
                sendedAt = DateTime.Now,
            });

            return MsgList;
        }

        public string GetAPI(string login, string password)
        {
            return Constants.Server.STATUS_DENIED;
        }

        public bool IsHasNewMessages()
        {
            return false;
        }
    }
}

    
