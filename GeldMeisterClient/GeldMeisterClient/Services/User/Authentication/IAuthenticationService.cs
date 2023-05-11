using GeldMeisterClient.Pages.Profiles.Requests;

namespace GeldMeisterClient.Services.User.Authentication
{
    public interface IAuthenticationService
    {
        Task RegisterAndLoginUser(SignUpRequest request);
        Task LoginUser(SignInRequest request);
        Task LogoutUser();
        Task RedirectIfIsAuthenticated(); 
    }
}
