using httpClientEmailWebApp.Models;

namespace httpClientEmailWebApp.Services
{
    public interface IEmailService
    {
        Task<string> SendSubscriptionEmail(Email newEmail);
    }
}
