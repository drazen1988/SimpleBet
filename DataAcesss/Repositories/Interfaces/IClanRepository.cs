
using DataAcesss.Data;
using Models.ViewModels;

namespace DataAcesss.Repositories.Interfaces
{
    public interface IClanRepository
    {
        Task<bool> AddClanAsync(string clanName, string userId);
        Task<Clan> GetClanAsync(int clanId);
        Task<List<ClanDropDown>> GetClansDropDownAsync();
        Task<Clan> GetClanByNameAsync(string clanName);
        Task<bool> DeleteClanAsync(int clanId);
        Task<int> UpdateClanAsync(int clanId, string clanName);
        Task<List<UsersPerClanVM>> GetUsersPerClanAsync();
        Task<int> GetClanCountAsync();
    }
}
