using DataAcesss.Data;
using Models.ViewModels;

namespace DataAcesss.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<UsersOverviewVM>> GetUsersAsync();
        Task<int> GetUserCountAsync();
        Task<ApplicationUser> GetUserByNameAsync(string userName);
        Task<List<UserRoleDropDown>> GetUserRolesAsync();
    }
}
