
using DataAcesss.Data;
using DataAcesss.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Models.ViewModels;

namespace DataAcesss.Repositories.Implementations
{
    public class StatsRepository : IStatsRepository
    {
        private readonly AppDbContext context;

        public StatsRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<List<ClanStatsVM.ClanStatsPercentage>> GetClanStatsAsync()
        {
            return await context.ClanStats.FromSqlRaw("spGetClanStats").ToListAsync();
        }

        public async Task<List<ClanStatsVM.ClanStatsAbs>> GetClanStatsAbsAsync()
        {
            return await context.ClanStatsAbs.FromSqlRaw("spGetClanStatsAbs").ToListAsync();
        }

        public async Task<List<ClanStatsVM.ClanUsers>> GetClanUsersAsync()
        {
            return await context.ClanUsers.FromSqlRaw("spGetUserByClan").ToListAsync();
        }

        public async Task<List<GeneralStatsVM.BestUserStreak>> GetBestUserStreakAsync()
        {
            List<ApplicationUser> users = await context.Users.ToListAsync();
            List<Bet> bets = await context.Bets.OrderBy(b => b.UserId).ThenBy(b => b.MatchId).ToListAsync();
            List<GeneralStatsVM.BestUserStreak> userStreaks = new List<GeneralStatsVM.BestUserStreak>();

            foreach (ApplicationUser user in users)
            {
                int streak = 0;
                int streakMax = 0;
                List<int> matchIdList = new List<int>();
                GeneralStatsVM.BestUserStreak userStreak = new GeneralStatsVM.BestUserStreak();

                userStreak.UserId = user.Id;
                userStreak.UserName = user.UserName;

                foreach (Bet bet in bets)
                {
                    if (bet.UserId == user.Id)
                    {
                        if (bet.IsWinningBet)
                        {
                            streak++;
                            streakMax = streak;
                            matchIdList.Add(bet.MatchId);
                        }
                        else
                        {
                            if (streak > userStreak.Streak)
                            {
                                userStreak.Streak = streak;
                                userStreak.MatchIdList.Clear();

                                foreach (int matchId in matchIdList)
                                {
                                    userStreak.MatchIdList.Add(matchId);
                                }
                            }

                            streak = 0;
                            matchIdList.Clear();
                        }

                        if (streakMax > userStreak.Streak)
                        {
                            userStreak.Streak = streakMax;
                            userStreak.MatchIdList.Clear();

                            foreach (int matchid in matchIdList)
                            {
                                userStreak.MatchIdList.Add(matchid);
                            }
                        }
                    }
                }

                userStreaks.Add(userStreak);
            }

            userStreaks = userStreaks.OrderByDescending(u => u.Streak).Take(5).ToList();
            return userStreaks;
        }

        public async Task<List<GeneralStatsVM.BestUserCoeficient>> GetBestUsersCoeficientAsync()
        {
            List<Bet> winningBets = await context.Bets.Where(b => b.IsWinningBet).OrderByDescending(b => b.BetCoeficient).Take(5).ToListAsync();
            List<GeneralStatsVM.BestUserCoeficient> coeficientList = new List<GeneralStatsVM.BestUserCoeficient>();

            foreach (Bet bet in winningBets)
            {
                GeneralStatsVM.BestUserCoeficient bestUserCoeficient = new GeneralStatsVM.BestUserCoeficient();
                ApplicationUser user = await context.Users.Where(u => u.Id == bet.UserId).FirstOrDefaultAsync();
                Match match = await context.Matches.Where(m => m.MatchId == bet.MatchId).FirstOrDefaultAsync();

                bestUserCoeficient.UserId = user.Id;
                bestUserCoeficient.UserName = user.UserName;
                bestUserCoeficient.BestCoeficient = bet.BetCoeficient;
                bestUserCoeficient.Match = $"{match.HomeTeam} - {match.AwayTeam} ({match.Result})";
                coeficientList.Add(bestUserCoeficient);
            }

            return coeficientList;
        }

        public async Task<MyStatsVM> GetMyStatsAsync(string userId)
        {
            var userIdParam = new SqlParameter("@UserId", userId);
            var results = await context.MyStats.FromSqlRaw("spGetMyStats @UserId", parameters: new[] { userIdParam }).ToListAsync();
            return results.FirstOrDefault();
        }

        public async Task<List<GeneralStatsVM.WinsPerDay>> GetWinsPerDayAsync()
        {
            return await context.WinsPerDay.FromSqlRaw("spGetWinsPerDay").ToListAsync();
        }

        public async Task<List<MyStatsGridVM>> GetBetsByUserAsync(string userId)
        {
            var userIdParam = new SqlParameter("@UserId", userId);
            return await context.MyBetList.FromSqlRaw("spGetMyBetList @UserId", parameters: new[] { userIdParam }).ToListAsync();
        }

        public async Task<ScalarInt> GetCurrentRankingAsync(string userId)
        {
            var userIdParam = new SqlParameter("@UserId", userId);
            var currentRanking = await context.ScalarInt.FromSqlRaw("spGetLeaderBoardById @UserId", parameters: new[] { userIdParam }).ToListAsync();
            return currentRanking.FirstOrDefault();
        }
    }
}
