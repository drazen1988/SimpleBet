using AutoMapper;
using DataAcesss.Data;
using DataAcesss.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models.ViewModels;
using System.Text.RegularExpressions;

namespace DataAcesss.Repositories.Implementations
{
    public class CountryRepository : ICountryRepository
    {
        private readonly AppDbContext context;
        private readonly IMapper _mapper;

        public CountryRepository(AppDbContext context, IMapper mapper)
        {
            this.context = context;
            this._mapper = mapper;
        }

        public async Task<CountryBet> GetCountryBetAsync(string userId)
        {
            return await context.CountryBets.FirstOrDefaultAsync(c => c.UserId == userId);
        }

        public async Task<List<CountryBetVM>> GetAllCountryBetsAsync()
        {
            return _mapper.Map<List<Country>, List<CountryBetVM>>(await context.Countries.OrderBy(c => c.CountryName).ToListAsync());
        }

        public async Task<List<ManageCountriesVM>> GetAllCountriesAsync()
        {
            return _mapper.Map<List<Country>, List<ManageCountriesVM>>(await context.Countries.OrderBy(c => c.CountryName).ToListAsync());
        }

        public async Task<string> SaveCountryBetAsync(CountryBetVM countryBetVM)
        {
            CountryBet existingCountryBet = await GetCountryBetAsync(countryBetVM.UserId);

            // If bet already exists in DB, then update it.
            if (existingCountryBet != null)
            {
                existingCountryBet.CountryId = countryBetVM.CountryId;
                existingCountryBet.CountryCoeficient = countryBetVM.CountryCoeficient;
                context.CountryBets.Update(existingCountryBet);
                await context.SaveChangesAsync();
                return "update";
            }
            else
            {
                CountryBet country = _mapper.Map<CountryBetVM, CountryBet>(countryBetVM);
                context.CountryBets.Add(country);
                await context.SaveChangesAsync();
                return "insert";
            }
        }

        public async Task<List<Country>> GetWinningCountryAsync()
        {
            return await context.Countries.Where(c => c.IsWinner == true).ToListAsync();
        }

        public async Task<bool> AddCountryAsync(ManageCountriesVM countryVM)
        {
            Country existingCountry = await GetCountryAsync(countryVM.CountryId);

            if (existingCountry != null)
            {
                return false;
            }
            else
            {
                await UpdateWinningCountryBetsAsync(countryVM.CountryId, countryVM.IsWinner);

                Country country = _mapper.Map<ManageCountriesVM, Country>(countryVM);
                context.Countries.Add(country);
                await context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<int> UpdateCountryAsync(ManageCountriesVM countryVM)
        {
            Country existingCountry = await GetCountryAsync(countryVM.CountryId);

            if (existingCountry != null)
            {
                await UpdateWinningCountryBetsAsync(countryVM.CountryId, countryVM.IsWinner);

                existingCountry.CountryName = countryVM.CountryName;
                existingCountry.CountryCoeficient = countryVM.CountryCoeficient;
                existingCountry.IsWinner = countryVM.IsWinner;
                context.Update(existingCountry);
                return await context.SaveChangesAsync();
            }
            else
            {
                return 0;
            }
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

        public async Task<bool> DeleteCountryAsync(int countryId)
        {
            Country existingCountry = await GetCountryAsync(countryId);

            if (existingCountry != null)
            {
                context.Countries.Remove(existingCountry);
                await context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<Country> GetCountryAsync(int countryId)
        {
            return await context.Countries.FirstOrDefaultAsync(c => c.CountryId == countryId);
        }

        public async Task UpdateWinningCountryBetsAsync(int countryId, bool isWinningBet)
        {
            List<CountryBet> countryBets = await context.CountryBets.Where(cb => cb.CountryId == countryId).ToListAsync();

            if (countryBets != null && countryBets.Any())
            {
                foreach (CountryBet countryBet in countryBets)
                {
                    countryBet.IsWinningBet = isWinningBet;
                    context.Update(countryBet);
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
