using DataAcesss.Data;
using Models.ViewModels;

namespace DataAcesss.Repositories.Interfaces
{
    public interface IBetRepository
    {
        Task<Bet> GetBetAsync(int matchId, string userId);
        Task<string> SaveBetAsync(BetVM betVM);
        Task<bool> DeleteBetAsync(int betId);
        Task<List<WinnerListVM>> GetWinnerListAsync(int matchId);
        void UpdateWinningBets(int matchId, int betType);
    }
}
