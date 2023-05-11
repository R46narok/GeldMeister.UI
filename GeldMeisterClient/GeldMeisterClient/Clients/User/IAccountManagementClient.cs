using GeldMeisterClient.Clients.User.Responses;
using GeldMeisterClient.Pages.Profiles.Requests;
using Refit;

namespace GeldMeisterClient.Clients.User;

public interface IAccountManagementClient
{
    [Patch("/api/user")]
    public Task<IApiResponse> UpdateUserDetailsAsync(UserUpdateRequest request);

    [Get("/api/user")]
    public Task<IApiResponse<UserProfileDetailsResponse>> GetUserDetailsAsync(UserDetailsRequest request);

    [Delete("/api/user")]
    public Task<IApiResponse> DeleteUserProfileAsync([Body] UserDeleteRequest request);
}