using GeldMeisterClient.Pages.Profiles.Requests;

namespace GeldMeisterClient.Services.User.Management;

public interface IAccountManagementService
{
    Task UpdateUserDetails(UpdateRequest request);
}