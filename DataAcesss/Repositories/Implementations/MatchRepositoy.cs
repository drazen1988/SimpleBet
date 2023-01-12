using AutoMapper;
using DataAcesss.Data;
using DataAcesss.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models.ViewModels;

namespace DataAcesss.Repositories.Implementations
{
    public class MatchRepositoy : IMatchRepository
    {
        private readonly AppDbContext context;
        private readonly IMapper _mapper;
        private readonly IBetRepository betRepository;

        public MatchRepositoy(AppDbContext context, IMapper mapper, IBetRepository betRepository)
        {
            this.context = context;
            this._mapper = mapper;
            this.betRepository = betRepository;
        }

        public async Task<bool> AddMatchAsync(MatchVM matchVM)
        {
            Match existingMatch = await GetMatchAsync(matchVM.WebId);

            // If match already exists in DB, then don't duplicate it.
            if (existingMatch != null)
            {
                return false;
            }
            else
            {
                Match match = _mapper.Map<MatchVM, Match>(matchVM);
                context.Matches.Add(match);
                await context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> DeleteMatchAsync(string webId)
        {
            Match match = await context.Matches.FirstOrDefaultAsync(m => m.WebId == webId);

            if (match != null)
            {
                context.Matches.Remove(match);
                await context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<Match> GetMatchAsync(string webId)
        {
            return await context.Matches.FirstOrDefaultAsync(m => m.WebId == webId);
        }

        public async Task<Match> GetMatchByIdAsync(int matchId)
        {
            return await context.Matches.FirstOrDefaultAsync(m => m.MatchId == matchId);
        }

        public async Task<List<MatchVM>> GetAllMatchesAsync()
        {
            return _mapper.Map<List<Match>, List<MatchVM>>(await context.Matches.Where(m => m.HomeCoeficient == 0).OrderBy(m => m.MatchDateTime).ToListAsync());
        }

        public async Task<int> AddCoeficientsAsync(MatchVM matchVM)
        {
            Match existingMatch = await GetMatchAsync(matchVM.WebId);

            // If coeficients already exist in DB, then don't update them.
            if (existingMatch != null && existingMatch.HomeCoeficient == 0)
            {
                existingMatch.HomeCoeficient = matchVM.HomeCoeficient;
                existingMatch.DrawCoeficient = matchVM.DrawCoeficient;
                existingMatch.AwayCoeficient = matchVM.AwayCoeficient;
                existingMatch.UserId = matchVM.UserId;

                context.Update(existingMatch);
                return await context.SaveChangesAsync();
            }
            else
            {
                return 0;
            }
        }

        public async Task<int> AddResultsAsync(MatchVM matchVM)
        {
            Match existingMatch = await GetMatchAsync(matchVM.WebId);

            // If result already exists in DB, then don't update it.
            if (existingMatch != null && existingMatch.Result == null)
            {
                betRepository.UpdateWinningBets(matchVM.MatchId, matchVM.WinningBetType);
                existingMatch.Result = matchVM.Result;
                existingMatch.WinningBetType = matchVM.WinningBetType;
                existingMatch.UserId = matchVM.UserId;
                context.Update(existingMatch);
                return await context.SaveChangesAsync();
            }
            else
            {
                return 0;
            }
        }

        public async Task<int> DeleteAllMatchesAsync()
        {
            return await context.Database.ExecuteSqlRawAsync("Delete from Matches");
        }

        public async Task<int> UpdateMatchAsync(MatchVM matchVM)
        {
            Match existingMatch = await GetMatchAsync(matchVM.WebId);

            if (existingMatch != null)
            {
                // First update winning bets
                if (!String.IsNullOrWhiteSpace(matchVM.Result))
                {
                    matchVM.HomeScore = Convert.ToInt32(matchVM.Result.Substring(0, 1));
                    string tempResult = matchVM.Result.Replace(" ", "");
                    matchVM.AwayScore = Convert.ToInt32(tempResult.Substring(tempResult.IndexOf(":") + 1, 1));

                    if (matchVM.HomeScore > matchVM.AwayScore)
                    {
                        matchVM.WinningBetType = 1;
                    }
                    else if (matchVM.HomeScore < matchVM.AwayScore)
                    {
                        matchVM.WinningBetType = 2;
                    }
                    else
                    {
                        matchVM.WinningBetType = 3;
                    }

                    betRepository.UpdateWinningBets(matchVM.MatchId, matchVM.WinningBetType);
                }

                existingMatch.MatchDateTime = matchVM.MatchDateTime;
                existingMatch.HomeTeam = matchVM.HomeTeam;
                existingMatch.AwayTeam = matchVM.AwayTeam;
                existingMatch.HomeCoeficient = matchVM.HomeCoeficient;
                existingMatch.DrawCoeficient = matchVM.DrawCoeficient;
                existingMatch.AwayCoeficient = matchVM.AwayCoeficient;
                existingMatch.Result = matchVM.Result;
                context.Update(existingMatch);
                return await context.SaveChangesAsync();
            }
            else
            {
                return 0;
            }
        }

        public async Task<List<MatchVM>> GetFutureMatchesAsync()
        {
            return _mapper.Map<List<Match>, List<MatchVM>>(await context.Matches.Where(m => m.MatchDateTime > DateTime.Now && m.HomeCoeficient > 0).OrderBy(m => m.MatchDateTime).ToListAsync());
        }

        public async Task<Match> GetFirstMatchAsync()
        {
            return await context.Matches.OrderBy(m => m.MatchDateTime).FirstOrDefaultAsync();
        }

        public async Task<List<MatchResultsVM>> GetAllMatchResultsAsync()
        {
            return await context.MatchResults.FromSqlRaw("spGetMatchResults").ToListAsync();
        }

        public async Task<int> GetPlayedMatches()
        {
            return await context.Matches.Where(m => m.MatchDateTime < DateTime.Now).CountAsync();
        }

        public async Task<List<CurrentMatchVM>> GetOngoingMatchesAsync()
        {
            List<Match> matches = await context.Matches.Where(m => m.MatchDateTime < DateTime.Now && m.Result == null).OrderByDescending(m => m.MatchDateTime).ToListAsync();
            List<CurrentMatchVM> currentMatches = _mapper.Map<List<Match>, List<CurrentMatchVM>>(matches);
            return currentMatches;
        }
    }
}
