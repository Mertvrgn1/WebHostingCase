using System.Net.Http;

namespace WebHostingUI.Helper
{
    public class AccountAPI
    {
        public HttpClient Initial()
        {
            var client=new HttpClient();
            client.BaseAddress = new System.Uri("https://localhost:44312/");
            return client;
        }
    }
}
