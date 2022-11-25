namespace ProDom.MobileClient.Services
{
    public class Server
    {
        HttpClient server = new();
        bool isHasConnetion;

        public async Task<string> Init(string requestBody)
        {
            try
            {
                HttpResponseMessage response = await server.GetAsync(Constants.Server.SERVER_ADRESS + requestBody);
                response.EnsureSuccessStatusCode();
                isHasConnetion = true;
                return await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException e)
            {
                isHasConnetion = false;
                return Constants.Server.STATUS_DENIED;
            }
        }
    

        public async Task<bool> IsHasConnection()
        {
            await Init(null);
            return isHasConnetion;
        }
    }
}
