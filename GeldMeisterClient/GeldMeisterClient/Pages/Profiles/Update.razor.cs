using GeldMeisterClient.Pages.Profiles.Requests;
using GeldMeisterClient.Services.User.Authentication;
using GeldMeisterClient.Services.User.Management;

namespace GeldMeisterClient.Pages.Profiles
{
    public partial class Update
    {
        private readonly UserUpdateRequest _request = new();

        private async Task HandleValidSubmitAsync()
        {
            await AccountManagementService.UpdateUserDetails(_request);
        }
    }
}