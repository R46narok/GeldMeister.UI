using GeldMeisterClient.Clients;
using GeldMeisterClient.Pages.Profiles.Requests;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace GeldMeisterClient.Services.User.Management;

public class AccountManagementService : IAccountManagementService
{
    private readonly IAccountManagementClient _accountManagementClient;
    private readonly NavigationManager _navigationManager;
    private readonly AuthenticationStateProvider _authenticationStateProvider;

    public AccountManagementService(IAccountManagementClient accountManagementClient,
        NavigationManager navigationManager, AuthenticationStateProvider authenticationStateProvider)
    {
        _accountManagementClient = accountManagementClient;
        _navigationManager = navigationManager;
        _authenticationStateProvider = authenticationStateProvider;
    }

    public async Task UpdateUserDetails(UpdateRequest request)
    {
        var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();

        request.Username = authState.User.Identity.Name;

        var result = await _accountManagementClient.UpdateUserDetails(request);
        if (result.IsSuccessStatusCode)
        {
            _navigationManager.NavigateTo("/", forceLoad: true);
        }
    }
}