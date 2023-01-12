using DataAcesss.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NLog;

namespace SimpleBet.Pages
{
    [Authorize]
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public LogoutModel(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            await _signInManager.SignOutAsync();

            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            Logger logger = LogManager.GetLogger("auditLogger");
            logger.WithProperty("UserId", user.Id).WithProperty("LogType", "Sign out").Info("User signed out.");
            return LocalRedirect("~/");
        }
    }
}
