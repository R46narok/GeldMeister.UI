using GeldMeisterClient.Clients.Responses;
using GeldMeisterClient.Pages.Profiles.Requests;

namespace GeldMeisterClient.Services.User.Management;

public interface IAccountManagementService
{
    Task UpdateUserDetails(UpdateRequest request);
    Task<UserProfileDetailsResponse> GetUserDetails(DetailsRequest request);
    Task DeleteUserProfile(DeleteRequest request);
}