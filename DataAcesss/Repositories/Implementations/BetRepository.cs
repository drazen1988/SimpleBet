using AutoMapper;
using DataAcesss.Data;
using DataAcesss.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models.ViewModels;

namespace DataAcesss.Repositories.Implementations
{
    public class BetRepository : IBetRepository
    {
        private readonly AppDbContext context;
        private readonly IMapper _mapper;

        public BetRepository(AppDbContext context, IMapper mapper)
        {
            this.context = context;
            this._mapper = mapper;
        }

        public async Task<Bet> GetBetAsync(int matchId, string userId)
        {
            return await context.Bets.SingleOrDefaultAsync(b => b.MatchId == matchId && b.UserId == userId);
        }

        public async Task<string> SaveBetAsync(BetVM betVM)
        {
            Bet existingBet = await GetBetAsync(betVM.MatchId, betVM.UserId);

            // If bet already exists in DB, then update it.
            if (existingBet != null)
            {
                existingBet.BetType = betVM.BetType;
                context.Bets.Update(existingBet);
                await context.SaveChangesAsync();
                return "update";
            }
            else
            {
                Bet bet = _mapper.Map<BetVM, Bet>(betVM);
                context.Bets.Add(bet);
                await context.SaveChangesAsync();
                return "insert";
            }
        }

        public Task<bool> DeleteBetAsync(int betId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<WinnerListVM>> GetWinnerListAsync(int matchId)
        {
            Task<List<WinnerListVM>> winnerList = (from bet in context.Bets
                                              join user in context.Users
                                                  on bet.UserId equals user.Id
                                              where bet.MatchId == matchId && bet.IsWinningBet == true
                                              select new WinnerListVM() { UserId = user.Id, UserName = user.UserName }).ToListAsync();

            return await winnerList;
        }

        public void UpdateWinningBets(int matchId, int betType)
        {
            List<Bet> winningBets = context.Bets.Where(b => b.MatchId == matchId).ToList();

            foreach (Bet bet in winningBets)
            {
                if (bet.BetType == betType)
                {
                    bet.IsWinningBet = true;
                }
                else
                {
                    bet.IsWinningBet = false;
                }
                context.Update(bet);
            }
            context.SaveChanges();
        }

        //public bool Add(Bet bet)
        //{
        //    context.Bets.Add(bet);
        //    context.SaveChanges();
        //    return true;
        //}

        //public Bet Delete(int id)
        //{
        //    Bet bet = context.Bets.SingleOrDefault(b => b.BetId == id);

        //    if (bet != null)
        //    {
        //        context.Bets.Remove(bet);
        //        context.SaveChanges();
        //    }

        //    return bet;
        //}

        //public bool Update(Bet betChanges)
        //{
        //    context.Update(betChanges).Property(b => b.BetId).IsModified = false;
        //    context.Entry(betChanges).Property(b => b.BetDate).IsModified = false;
        //    context.Entry(betChanges).Property(b => b.UserId).IsModified = false;

        //    context.SaveChanges();
        //    return true;
        //}
    }
}
