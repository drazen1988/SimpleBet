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

        public LogoutModel(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            await _signInManager.SignOutAsync();
            Logger logger = LogManager.GetLogger("auditLogger");
            logger.WithProperty("UserName", User.Identity.Name).WithProperty("LogType", "Sign out").Info("User signed out.");
            return LocalRedirect("~/");
        }
    }
}
