using GeldMeisterClient.Clients.User;
using GeldMeisterClient.Pages.Profiles.Requests;
using GeldMeisterClient.Services.User.Authentication.Extensions;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace GeldMeisterClient.Services.User.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAuthenticationClient _authenticationClient;
        private readonly IAuthorizationClient _authorizationClient;
        private readonly TokenAuthenticationStateProvider _tokenAuthenticationStateProvider;
        private readonly NavigationManager _navigationManager;

        public AuthenticationService(IAuthenticationClient authenticationClient, IAuthorizationClient authorizationClient, 
            TokenAuthenticationStateProvider tokenAuthenticationStateProvider, NavigationManager navigationManager)
        {
            _authenticationClient = authenticationClient;
            _authorizationClient = authorizationClient;
            _tokenAuthenticationStateProvider = tokenAuthenticationStateProvider;
            _navigationManager = navigationManager;
        }

        public async Task RegisterAndLoginUser(SignUpRequest request)
        {
            var result = await _authenticationClient.CreateUserAsync(request);
            if (result.IsSuccessStatusCode)
            {

                var tokenResponse = await _authorizationClient.GetTokenAsync(new SignInRequest { Username = request.Username, Password = request.Password });
                await SetAuthenticationStateAndNavigatePage(tokenResponse.Content.Token);
            }
        }

        public async Task LoginUser(SignInRequest request)
        {
            var tokenResponse = await _authorizationClient.GetTokenAsync(request);

            if (tokenResponse.IsSuccessStatusCode) await SetAuthenticationStateAndNavigatePage(tokenResponse.Content.Token);
        }

        public async Task LogoutUser()
        {
            await SetAuthenticationStateAndNavigatePage(null);
        }

        private async Task SetAuthenticationStateAndNavigatePage(string? token)
        {
            await _tokenAuthenticationStateProvider.SetAuthenticationStateAsync(token);
            _navigationManager.NavigateTo("/", forceLoad: true);
        }

        public async Task RedirectIfIsAuthenticated()
        {
            var authState = await _tokenAuthenticationStateProvider.GetAuthenticationStateAsync();

            var result = authState.User.IsAuthenticated();
            if (result) _navigationManager.NavigateTo("/");
        }
    }
}