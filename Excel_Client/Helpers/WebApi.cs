namespace Excel_Client.Helpers
{
    public class WebApi
    {
        public HttpClient Initial()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7086/");
            return client;
        }
    }
}
