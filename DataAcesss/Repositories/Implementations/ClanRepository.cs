using AutoMapper;
using DataAcesss.Data;
using DataAcesss.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models.ViewModels;
using System.Text.RegularExpressions;

namespace DataAcesss.Repositories.Implementations
{
    public class ClanRepository : IClanRepository
    {
        private readonly AppDbContext context;
        private readonly IMapper _mapper;

        public ClanRepository(AppDbContext context, IMapper mapper)
        {
            this.context = context;
            _mapper = mapper;
        }

        public async Task<bool> AddClanAsync(string clanName, string userId)
        {
            Clan existingClan = await GetClanByNameAsync(clanName);

            // If clan already exists in DB, then don't duplicate it.
            if (existingClan != null)
            {
                return false;
            }
            else
            {
                Clan clan = new Clan() { ClanName = clanName, UserId = userId };
                context.Clans.Add(clan);
                await context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> DeleteClanAsync(int clanId)
        {
            Clan clan = await context.Clans.SingleOrDefaultAsync(c => c.ClanId == clanId);

            if (clan != null)
            {
                context.Clans.Remove(clan);
                await context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<Clan> GetClanAsync(int clanId)
        {
            return await context.Clans.SingleOrDefaultAsync(c => c.ClanId == clanId);
        }

        public async Task<Clan> GetClanByNameAsync(string clanName)
        {
            return await context.Clans.SingleOrDefaultAsync(c => c.ClanName == clanName);
        }

        public async Task<int> UpdateClanAsync(int clanId, string clanName)
        {
            Clan existingClan = await GetClanAsync(clanId);

            if (existingClan != null)
            {
                existingClan.ClanName = clanName;
                context.Update(existingClan);
                return await context.SaveChangesAsync();
            }
            else
            {
                return 0;
            }
        }

        public async Task<int> GetClanCountAsync()
        {
            return await context.Clans.Select(c => c.ClanId).CountAsync();
        }

        public async Task<List<UsersPerClanVM>> GetUsersPerClanAsync()
        {
            return await context.UsersPerClan.FromSqlRaw("spGetUsersPerClan").ToListAsync();
        }

        public async Task<List<ClanDropDown>> GetClansDropDownAsync()
        {
            return _mapper.Map<List<Clan>, List<ClanDropDown>>(await context.Clans.OrderBy(c => c.ClanName).ToListAsync());
        }
    }
}
