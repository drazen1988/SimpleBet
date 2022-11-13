using DataAcesss.Data;
using Models.ViewModels;

namespace DataAcesss.Repositories.Interfaces
{
    public interface ICountryRepository
    {
        Task<bool> AddCountryAsync(ManageCountriesVM countryVM);
        Task<int> UpdateCountryAsync(ManageCountriesVM countryVM);
        Task<bool> DeleteCountryAsync(int countryId);
        Task<Country> GetCountryAsync(int countryId);
        Task<CountryBet> GetCountryBetAsync(string userId);
        Task<List<Country>> GetWinningCountryAsync();
        Task<List<CountryBetVM>> GetAllCountryBetsAsync();
        Task<List<ManageCountriesVM>> GetAllCountriesAsync();
        Task<string> SaveCountryBetAsync(CountryBetVM countryBetVM);
        Task UpdateWinningCountryBetsAsync(int countryId, bool isWinningBet);
    }
}
