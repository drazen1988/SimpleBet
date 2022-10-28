using DataAcesss.Data;
using Models.ViewModels;

namespace DataAcesss.Repositories.Interfaces
{
    public interface IMatchRepository
    {
        Task<bool> AddMatchAsync(MatchVM matchVM);
        Task<int> UpdateMatchAsync(MatchVM matchVM);
        Task<bool> DeleteMatchAsync(string webId);
        Task<int> DeleteAllMatchesAsync();
        Task<List<MatchVM>> GetAllMatchesAsync();
        Task<List<MatchVM>> GetFutureMatchesAsync();
        Task<Match> GetMatchAsync(string webId);
        Task<Match> GetMatchByIdAsync(int matchId);
        Task<Match> GetFirstMatchAsync();
        Task<int> AddCoeficientsAsync(MatchVM matchVM);
        Task<int> AddResultsAsync(MatchVM matchVM);
        Task<List<MatchResultsVM>> GetAllMatchResultsAsync();
    }
}
