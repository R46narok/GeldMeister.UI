using GeldMeisterClient.Clients.User;
using GeldMeisterClient.Clients.User.Responses;
using GeldMeisterClient.Pages.Profiles.Requests;
using GeldMeisterClient.Services.User.Authentication;
using Microsoft.AspNetCore.Components;

namespace GeldMeisterClient.Services.User.Management;

public class AccountManagementService : IAccountManagementService
{
    private readonly IAuthenticationService _authenticationService;
    private readonly IAccountManagementClient _accountManagementClient;
    private readonly NavigationManager _navigationManager;
    private readonly TokenAuthenticationStateProvider _tokenAuthenticationStateProvider;

    public AccountManagementService(IAuthenticationService authenticationService, IAccountManagementClient accountManagementClient,
        NavigationManager navigationManager, TokenAuthenticationStateProvider tokenAuthenticationStateProvider)
    {
        _authenticationService = authenticationService;
        _accountManagementClient = accountManagementClient;
        _navigationManager = navigationManager;
        _tokenAuthenticationStateProvider = tokenAuthenticationStateProvider;
    }

    public async Task UpdateUserDetails(UserUpdateRequest request)
    {
        var authState = await _tokenAuthenticationStateProvider.GetAuthenticationStateAsync();

        request.Username = authState.User.Identity.Name;

        var result = await _accountManagementClient.UpdateUserDetailsAsync(request);
        if (result.IsSuccessStatusCode)
        {
            _navigationManager.NavigateTo("/profile/details", forceLoad: true);
        }
    }

    public async Task<UserProfileDetailsResponse> GetUserDetails(UserDetailsRequest request)
    {
        var authState = await _tokenAuthenticationStateProvider.GetAuthenticationStateAsync();
        request.UserName = authState.User.Identity.Name;

        var result = await _accountManagementClient.GetUserDetailsAsync(request);
        if (result.IsSuccessStatusCode)
        {
            return new UserProfileDetailsResponse 
            { 
                UserName = result.Content.UserName, 
                Email = result.Content.Email,
                Phone = result.Content.Phone,
                GitHub = result.Content.GitHub,
                Instagram = result.Content.Instagram,
                Twitter = result.Content.Twitter
            };
        }
        throw new Exception($"Error retrieving details about user with username @{request.UserName}: {result.StatusCode}");
    }

    public async Task DeleteUserProfile(UserDeleteRequest request)
    {
        var authState = await _tokenAuthenticationStateProvider.GetAuthenticationStateAsync();
        request.UserName = authState.User.Identity.Name;
        request.Id = null;

        var result = await _accountManagementClient.DeleteUserProfileAsync(request);
        if (result.IsSuccessStatusCode) await _authenticationService.LogoutUser();
    }
}