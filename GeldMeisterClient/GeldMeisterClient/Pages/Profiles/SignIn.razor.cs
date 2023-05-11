using GeldMeisterClient.Pages.Profiles.Requests;

namespace GeldMeisterClient.Pages.Profiles
{
    public partial class SignIn
    {
        private readonly SignInRequest _request = new();

        protected override async Task OnInitializedAsync()
        {
            await AuthenticationService.RedirectIfIsAuthenticated();
        }

        private async Task HandleValidSubmitAsync()
        {
            await AuthenticationService.LoginUser(_request);
        }
    }
}