
namespace DataAcesss.Repositories.Interfaces
{
    public interface IMailRepository
    {
        Task<bool> SendFeedbackAsync(string feedbackTypeText, string description, string userName, string fullName);
    }
}
