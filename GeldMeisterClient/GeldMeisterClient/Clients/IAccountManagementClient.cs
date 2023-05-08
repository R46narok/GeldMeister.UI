using GeldMeisterClient.Clients.Responses;
using GeldMeisterClient.Pages.Profiles.Requests;
using Refit;

namespace GeldMeisterClient.Clients;

public interface IAccountManagementClient
{
    [Patch("/api/user")]
    public Task<IApiResponse> UpdateUserDetails(UpdateRequest request);

    [Get("/api/user")]
    public Task<IApiResponse<UserProfileDetailsResponse>> GetUserDetailsAsync(DetailsRequest request);

    [Delete("/api/user")]
    public Task<IApiResponse> DeleteUserProfileAsync([Body] DeleteRequest request);
}