using AutoMapper;
using DataAcesss.Data;
using DataAcesss.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Models.ViewModels;
using System.Collections.Generic;

namespace DataAcesss.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext context;
        private readonly IMapper _mapper;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserRepository(AppDbContext context, IMapper mapper, RoleManager<IdentityRole> roleManager)
        {
            this.context = context;
            this._mapper = mapper;
            this._roleManager = roleManager;
        }

        public async Task<List<UsersOverviewVM>> GetUsersAsync()
        {
            List<UsersOverviewVM> userList = _mapper.Map<List<ApplicationUser>, List<UsersOverviewVM>>(await context.Users.OrderBy(u => u.UserName).ToListAsync());

            foreach (UsersOverviewVM user in userList)
            {
                user.ClanName = context.Clans.Where(u => u.ClanId == user.ClanId).FirstOrDefault().ClanName;
            }

            return userList;
        }

        public async Task<int> GetUserCountAsync()
        {
            return await context.Users.CountAsync();
        }

        public async Task<ApplicationUser> GetUserByNameAsync(string userName)
        {
            return await context.Users.FirstOrDefaultAsync(u => u.UserName == userName);
        }

        public async Task<List<UserRoleDropDown>> GetUserRolesAsync()
        {
            return _mapper.Map<List<IdentityRole>, List<UserRoleDropDown>>(await _roleManager.Roles.OrderBy(r => r.Id).ToListAsync());
        }

        public async Task<List<UnactiveUsersVM>> GetUnActiveUsersAsync()
        {
            return await context.UsageOverview.FromSqlRaw("spGetUnActiveUsers").ToListAsync();
        }

        public async Task<List<ApplicationUsageVM.LoginTypes>> GetApplicationUsageAsync()
        {
            return await context.AplicationUsage.FromSqlRaw("spApplicationUsage").ToListAsync();
        }

        public async Task<int> GetActiveUserCountAsync()
        {
            int totalUserCount = await context.Users.CountAsync();
            List<UnactiveUsersVM> unactiveUsers = await GetUnActiveUsersAsync();
            return totalUserCount - unactiveUsers.Count();
        }

    }
}
