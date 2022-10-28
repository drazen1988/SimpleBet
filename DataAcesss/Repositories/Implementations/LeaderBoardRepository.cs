using DataAcesss.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models.ViewModels;

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
    }
}
