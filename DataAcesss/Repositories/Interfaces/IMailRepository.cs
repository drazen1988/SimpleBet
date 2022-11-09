
namespace DataAcesss.Repositories.Interfaces
{
    public interface IMailRepository
    {
        Task<bool> SendResetPasswordAsync(string userName, string password, string firstName, string email);
        Task<bool> SendFeedbackAsync(string feedbackTypeText, string description, string userName, string fullName);
        Task<bool> NotifyUserAsync(string userName, string password, string firstName, string email, string clanName);
    }
}
