using DataAcesss.Data;
using Models.ViewModels;

namespace DataAcesss.Repositories.Interfaces
{
    public interface IBetRepository
    {
        Task<Bet> GetBetAsync(int matchId, string userId);
        Task<string> SaveBetAsync(BetVM betVM);
        Task<bool> DeleteBetAsync(int betId);
        Task<List<UserListVM>> GetWinnerListAsync(int matchId);
        void UpdateWinningBets(int matchId, int betType);
        Task<int> GetAllClosedBetsAsync();
        Task<int> GetAllWinningBetsAsync();
        Task<List<LeaderBoardDetailsVM>> GetAllWinningBetsByUserAsync(string userId);
        Task<List<UserListVM>> GetUserBetsAsync(int matchId, int betType);
    }
}
