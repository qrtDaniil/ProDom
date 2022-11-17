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

        public bool IsHasPolls()
        {
            return false;
        }


/* Необъединенное слияние из проекта "SmartYard (net6.0-ios)"
До:
        public List<Models.Tables.Polls> getPolls()
После:
        public List<Polls> getPolls()
*/
        public List<Models.Poll> getPolls()
        {
            return null;
        }

        // Requests //

        public bool IsHasRequests()
        {
            return false;
        }

        public List<Models.Tables.Requests> getRequests()
        {
            return null;
        }

        

        // chats //

        public bool IsHasMessages()
        {
            return false;
        }

        public bool IsHasDialogWithUser(int userId)
        {
            return false;
        }


        public List<Models.Message> GetChats()
        {
            return null;
        }


        public List<Models.Message> GetDialogWithUser(int userId)
        {
            return null;
        }

        public string GetAPI(string login, string password)
        {
            return Constants.Server.STATUS_DENIED;
        }
    }
}

    
