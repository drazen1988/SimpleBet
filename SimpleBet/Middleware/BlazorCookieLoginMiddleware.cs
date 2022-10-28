using DataAcesss.Data;
using Microsoft.AspNetCore.Identity;
using NLog;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace SimpleBet.Middleware
{
    public class BlazorCookieLoginMiddleware
    {
        public static IDictionary<Guid, LoginInfo> Logins { get; private set; }
            = new ConcurrentDictionary<Guid, LoginInfo>();


        private readonly RequestDelegate _next;

        public BlazorCookieLoginMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, SignInManager<ApplicationUser> signInMgr)
        {
            if (context.Request.Path == "/login" && context.Request.Query.ContainsKey("key"))
            {
                var key = Guid.Parse(context.Request.Query["key"]);
                var info = Logins[key];

                var result = await signInMgr.PasswordSignInAsync(info.UserName, info.Password, false, lockoutOnFailure: true);

                info.Password = null;

                //if (result.Succeeded)
                //{
                    Logins.Remove(key);
                    context.Response.Redirect("/Home");

                Logger logger = LogManager.GetLogger("auditLogger");
                logger.WithProperty("UserName", info.UserName).WithProperty("LogType", "Sign in").Info("User signed in.");
                return;
                //}
            }
            else
            {
                await _next.Invoke(context);
            }
        }
    }
}
