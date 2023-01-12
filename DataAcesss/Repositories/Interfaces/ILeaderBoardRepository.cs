using Models.ViewModels;

namespace DataAcesss.Repositories.Interfaces
{
    public interface ILeaderBoardRepository
    {
        Task<List<LeaderBoardVM>> GetLeaderBoardAsync();
        Task<string> GetOverallAverageCoeficientAsync();
    }
}
