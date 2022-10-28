
using Models.ViewModels;

namespace DataAcesss.Repositories.Interfaces
{
    public interface IStatsRepository
    {
        Task<List<ClanStatsVM.ClanStatsPercentage>> GetClanStatsAsync();
        Task<List<ClanStatsVM.ClanStatsAbs>> GetClanStatsAbsAsync();
        Task<List<ClanStatsVM.ClanUsers>> GetClanUsersAsync();
        Task<List<GeneralStatsVM.BestUserStreak>> GetBestUserStreakAsync();
        Task<List<GeneralStatsVM.BestUserCoeficient>> GetBestUsersCoeficientAsync();
        Task<List<GeneralStatsVM.WinsPerDay>> GetWinsPerDayAsync();
        Task<MyStatsVM> GetMyStatsAsync(string userId);
        Task<List<MyStatsGridVM>> GetBetsByUserAsync(string userId);
    }
}
