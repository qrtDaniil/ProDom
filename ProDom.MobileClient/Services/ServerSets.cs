using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProDom.MobileClient.Constants;
using ProDom.MobileClient.Models.Tables;

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

        public async Task<string> SendRegisterProfile(Models.RegisterProfile profile)
        {
            return Constants.Server.REGISTER_STATUS_SUCCESS;
        }

        public Task<string> SendCode(Users user)
        {
            return null;
        }

        // polls //

        public async Task<string> SetPollVote(int pollId, string vote)
        {
            return Constants.Server.STATUS_SUCCESS;
        }

        public async Task<string> AddPoll(Models.Poll poll)
        {
            return Constants.Server.STATUS_SUCCESS;
        }


    }

    
}
