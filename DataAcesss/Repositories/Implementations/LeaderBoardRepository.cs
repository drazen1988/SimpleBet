using DataAcesss.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models.ViewModels;
using System.Collections.Generic;

namespace DataAcesss.Repositories.Implementations
{
    public class LeaderBoardRepository : ILeaderBoardRepository
    {
        private readonly AppDbContext context;

        public LeaderBoardRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<List<LeaderBoardVM>> GetLeaderBoardAsync()
        {
            return await context.LeaderBoard.FromSqlRaw("spGetLeaderBoard").ToListAsync();
        }

        public async Task<string> GetOverallAverageCoeficientAsync()
        {
            List<LeaderBoardVM> leaderBoard = await GetLeaderBoardAsync();
            decimal totalCoeficient = leaderBoard.Sum(l => l.TotalCoeficient);
            decimal usersCount = leaderBoard.Count();
            decimal overallAverageCoeficient = totalCoeficient / usersCount;
            return overallAverageCoeficient.ToString("N2");
        }
    }
}
