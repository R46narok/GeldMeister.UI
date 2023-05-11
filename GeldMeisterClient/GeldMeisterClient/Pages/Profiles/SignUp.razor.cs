using GeldMeisterClient.Pages.Profiles.Requests;

namespace GeldMeisterClient.Pages.Profiles
{
    public partial class SignUp
    {
        private readonly SignUpRequest _request = new();

        protected override async Task OnInitializedAsync()
        {
            await AuthenticationService.RedirectIfIsAuthenticated();
        }

        private async Task HandleValidSubmitAsync()
        {
            await AuthenticationService.RegisterAndLoginUser(_request);
        }
    }
}