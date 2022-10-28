using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;

namespace SimpleBet.Pages
{
    public partial class RedirectToLogin
    {
        [Inject]
        private NavigationManager navigationManager { get; set; }

        [CascadingParameter]
        private Task<AuthenticationState> authenticationState { get; set; }

        bool notAuthorized { get; set; } = false;

        protected override async Task OnInitializedAsync()
        {
            var authState = await authenticationState;

            if (authState?.User?.Identity is null || !authState.User.Identity.IsAuthenticated)
            {
                var returnUrl = navigationManager.ToBaseRelativePath(navigationManager.Uri);
                if (string.IsNullOrEmpty(returnUrl))
                {
                    navigationManager.NavigateTo("/", true);
                }
                else
                {
                    navigationManager.NavigateTo($"/?returnUrl={returnUrl}", true);
                }
            }
            else
            {
                notAuthorized = true;
            }
        }
    }
}
