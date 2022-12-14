using httpClientEmailWebApp.Models;

namespace httpClientEmailWebApp.Services
{
    public class EmailService : IEmailService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public EmailService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClient = httpClientFactory.CreateClient("sendemail");
            _configuration = configuration;
        }

        public async Task<string> SendSubscriptionEmail(Email newEmail)
        {
            var test = _configuration["AzureKeyRequestAddress"];
            var responseMessage = await _httpClient.PostAsJsonAsync(test, newEmail);
            if (!responseMessage.IsSuccessStatusCode)
            {
                return "Some error ocurred";
            }
            return "Email will be sent";
        }
    }
}
