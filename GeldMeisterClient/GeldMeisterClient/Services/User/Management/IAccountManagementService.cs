using GeldMeisterClient.Clients.User.Responses;
using GeldMeisterClient.Pages.Profiles.Requests;

namespace GeldMeisterClient.Services.User.Management;

public interface IAccountManagementService
{
    Task UpdateUserDetails(UserUpdateRequest request);
    Task<UserProfileDetailsResponse> GetUserDetails(UserDetailsRequest request);
    Task DeleteUserProfile(UserDeleteRequest request);
}