using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProDom.MobileClient.Constants;
using ProDom.MobileClient.Models;
using ProDom.MobileClient.Models.Server;

namespace ProDom.MobileClient.Services
{
    public class ServerSets: Server
    {
        Server server;

        public ServerSets(Server server)
        {
            this.server = server;
        }

        // registration //

        public async Task RegisterUserAsync(string fullName, string phoneNumber, string password)
        {
            PostUser user = new PostUser
            {
                FullName = fullName,
                PhoneNumber = phoneNumber,
                Password = password,
                PersonalAccount = new PostPersonalAccount
                {
                    AccountCode = "4326346346",
                    Points = 1000,
                    Address = new PostAddress
                    {
                        Index = "150014",
                        City = "Ярославль",
                        Street = "улица Богдановича",
                        House = "6",
                        Entrance = 1,
                        Apartment = 22
                    }
                }
            };


            string json = JsonConvert.SerializeObject(user, Formatting.Indented);

            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            Console.WriteLine(json);

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var response = await client.PostAsync("https://localhost:7192/api/Users", content);
                    response.EnsureSuccessStatusCode();

                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine(response.IsSuccessStatusCode);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(@"ERROR {0}", ex);
                }
            }

        }

        public async Task<string> SendRegisterProfile(Models.RegisterProfile profile)
        {
            return Constants.Server.REGISTER_STATUS_SUCCESS;
        }

        public Task<string> SendCode(RegisterProfile user, string code)
        {
            return null;
        }

        // polls //

        public async Task<string> SetPollVote(int pollId, string vote)
        {
            return Constants.Server.STATUS_DENIED;
        }

        public async Task CreatePollAsync(string title, string body, int duration)
        {
            PostPoll poll = new PostPoll
            {
                Title = title,
                Body = body,
                Duration = duration,
                PollsOptions = new List<PostPollOption>()
            {
                new PostPollOption()
                {
                    Title = "Да",
                    Votes = 0
                },
                new PostPollOption()
                {
                    Title = "Нет",
                    Votes = 0
                }
            }
            };


            string json = JsonConvert.SerializeObject(poll, Formatting.Indented);

            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            Console.WriteLine(json);

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var response = await client.PostAsync("https://localhost:7192/api/Polls", content);
                    response.EnsureSuccessStatusCode();

                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine(response.IsSuccessStatusCode);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(@"ERROR {0}", ex);
                }
            }

        }

        public async Task<string> SendMessage(int dialogID, string message)
        {
            return Constants.Server.STATUS_DENIED;
        }
    }

    
}
