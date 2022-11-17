using ProDom.MobileClient.Models;
using SQLite;
using System.Threading.Tasks;

namespace ProDom.MobileClient.Database
{
    
    public class SmartYardDB
    {
        public SQLiteAsyncConnection db;

        /*
        public async Task init()
        {
            if (db is not null)
            {
                return;
            }

            db = new SQLiteAsyncConnection(Constants.Database.DatabasePath, Constants.Database.Flags);
            await db.CreateTableAsync<Models.Tables.Users>();
            await db.CreateTableAsync<Models.Tables.Messages>();
        }

        */
        
        //
        // Messages Table Requests
        //

        /*

        public async Task<List<Models.Tables.Messages>> GetMessagesByUserId(int id)
        {
            await init();
            return await db.Table<Models.Tables.Messages>().Where(i => i.Id == id).ToListAsync();
        }

        public async void addMessage(Models.Tables.Messages msg)
        {
            await init();
            await db.InsertAsync(msg);
        }

        public async Task<int> GetNotReadedCountByUserId(int id)
        {
            return await db.Table<Models.Tables.Messages>().CountAsync(
                x => x.dialogWithUser == id && x.status == Constants.Database.MESSAGE_STATUS_NOTREADED);
        }

        public async Task<Models.Tables.Messages> GetLastMessageByUserId(int id)
        {
            await init();
            return await db.Table<Models.Tables.Messages>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Models.Tables.Messages> GetlastMessageByUserId(int id)
        {
            await init();
            return await db.Table<Models.Tables.Messages>().Where(i => i.dialogWithUser == id).FirstOrDefaultAsync();
        }

        public async Task ChangeMessageStatus(Models.Tables.Messages msg, string newStatus)
        {
            await init();
            msg.status = newStatus;
            await db.InsertAsync(msg);
        }

        public async Task<int> DeleteMessage(Models.Tables.Messages item)
        {
            await init();
            return await db.DeleteAsync(item);
        }

        */

        //
        // Users Table Requests
        //

        /*

        public async Task<int> DeleteUser(Models.Tables.Users item)
        {
            await init();
            return await db.DeleteAsync(item);
        }

        public async Task<bool> isAccountValid(string phone, string password)
        {
            await init();
            var result = await db.Table<Models.Tables.Users>().Where(x => x.Phone == phone && x.Password == password).FirstOrDefaultAsync();
            if (result == null)
                return false;
            return true;
        }

        public async Task<Models.Tables.Users> getMainUserInfo()
        {
            await init();
            return await db.Table<Models.Tables.Users>().Where(i => i.userId == 1).FirstOrDefaultAsync();
        }

        public async Task<Models.Tables.Users> getUserById(int id)
        {
            await init();
            return await db.Table<Models.Tables.Users>().Where(i => i.userId == id).FirstOrDefaultAsync();
        }

        public async Task addUser(Models.Tables.Users user)
        {
            await init();
            await db.InsertAsync(user);
        }

        public async Task<List<Models.Tables.Users>> getUsersWithMessages()
        {
            await init();
            return await db.Table<Models.Tables.Users>().Where(x => x.IsHasMessages == true && x.userId != 0).ToListAsync();
        }

        public async Task UpdateUser(Models.Tables.Users user)
        {
            await init();
            await db.UpdateAsync(user);
        }

        */

        //
        // Polls Table Requests
        //

        /*
        public async Task<List<Models.Tables.Polls>> getNotAnsweredPolls()
        {
            await init();
            return await db.Table<Models.Tables.Polls>().Where(
                x => x.userAnswer != Constants.Database.POLLS_USERANSWER_NOTANSWERED &&
                x.status == Constants.Database.POLLS_STATUS_ACTIVE).ToListAsync();

        }

        public async Task addPoll(Models.Tables.Polls poll)
        {
            await init();
            poll.status = Constants.Database.POLLS_STATUS_ACTIVE;
            poll.userAnswer = Constants.Database.POLLS_USERANSWER_NOTANSWERED;
            await db.InsertAsync(poll);
        }

        public async Task<List<Models.Tables.Polls>> getDeactivePolls()
        {
            await init();
            return await db.Table<Models.Tables.Polls>().Where(
                x => x.status == Constants.Database.POLLS_STATUS_DEACTIVE).ToListAsync();

        }

        public async void ChangePollsAnswer(Models.Tables.Polls poll, string answer)
        {
            await init();
            poll.userAnswer = answer;
            await db.InsertAsync(poll);
        }
        */


    }

}
