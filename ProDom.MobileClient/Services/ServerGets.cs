using Newtonsoft.Json;
using ProDom.MobileClient.Constants;
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

        public Models.User GetCurrentUserInfo()
        {
            string userAPI = Preferences.Default.Get("API", "0");
            if(userAPI == "0") return null;
            return null;
        }

        // Polls //

        public async Task<bool> IsHasPolls()
        {
            try
            {
                HttpResponseMessage response = await server.GetAsync(Constants.Server.SERVER_ADRESS + "api/Polls");
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync() != null;
            }
            catch (HttpRequestException e)
            {
                return false;
            }

           
        }

        public async Task<List<Models.Poll>> getPolls()
        {
            try
            {
                List<Models.Poll> polls = new();
                var response1 = await server.GetAsync(Constants.Server.SERVER_ADRESS+"Polls/-1");
                var response2 = await server.GetAsync(Constants.Server.SERVER_ADRESS+"Polls/-2");
                response1.EnsureSuccessStatusCode(); // Чтобы в ответе был код статуса запроса

                if (response1.IsSuccessStatusCode) // Если код статуса запроса успешный
                {
                    // Console.WriteLine(response.StatusCode.ToString());
                    string message1 = await response1.Content.ReadAsStringAsync(); // Сам запрос
                    string message2 = await response2.Content.ReadAsStringAsync();

                    Models.Poll poll = JsonConvert.DeserializeObject<Models.Poll>(message1); // Заполнение модели
                    polls.Add(poll);
                    poll = JsonConvert.DeserializeObject<Models.Poll>(message2);
                    polls.Add(poll);
                    //Console.WriteLine(user.FullName); // Обращение к полю модели
                    return polls;
                }
                else
                {
                    Console.WriteLine($"Respone error code: {response1.StatusCode}"); // Код статуса неудачного запроса
                    return null;
                }

            }
            catch (HttpRequestException e)
            {
                return null;
            }
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
                    userName = "Пётр Петров",
                    imageResource = "user_no_image.png",
                    dialogId = 0,
                    messageId = 0,
                    status = Constants.Server.MESSAGE_STATUS_NOTREADED,
                    message = "Вы во сколько приедете с работы?",
                    sendedAt = DateTime.Now,
                    messageFrom = Constants.Server.MESSAGE_FROM_ANOTHER,
                    notReadedCount = 3
                },

                new Models.Message()
                {
                    userName = "Иван Смирнов",
                    imageResource = "user_no_image.png",
                    dialogId = 0,
                    messageId = 0,
                    status = Constants.Server.MESSAGE_STATUS_SENDED,
                    message = "Привет",
                    sendedAt = DateTime.Now,
                    messageFrom = Constants.Server.MESSAGE_FROM_CURRENT,
                    notReadedCount = 0
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

        internal object getPollsByTitle(string name)
        {
            throw new NotImplementedException();
        }
    }
}

    
