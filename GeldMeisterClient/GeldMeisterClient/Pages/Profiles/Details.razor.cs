using GeldMeisterClient.Clients.User.Responses;
using GeldMeisterClient.Pages.Profiles.Requests;
using GeldMeisterClient.Services.User.Management;
using Microsoft.AspNetCore.Components;

namespace GeldMeisterClient.Pages.Profiles
{
    public partial class Details
    {
        private readonly UserDetailsRequest _userDetailsRequest = new();
        private UserProfileDetailsResponse _userProfileDetailsResponse = new();
        private readonly UserDeleteRequest _userDeleteRequest = new();

        protected override async Task OnInitializedAsync()
        {
            _userProfileDetailsResponse = await AccountManagementService.GetUserDetails(_userDetailsRequest);
        }

        private async Task OnClickDeleteUserProfile()
        {
            await AccountManagementService.DeleteUserProfile(_userDeleteRequest);
        }
    }
}