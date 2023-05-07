using GeldMeisterClient.Pages.Profiles.Requests;
using Refit;

namespace GeldMeisterClient.Clients;

public interface IAccountManagementClient
{
    [Patch("/api/user")]
    public Task<IApiResponse> UpdateUserDetails(UpdateRequest request);
}