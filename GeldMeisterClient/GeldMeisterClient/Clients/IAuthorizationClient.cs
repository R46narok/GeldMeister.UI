using GeldMeisterClient.Clients.Responses;
using GeldMeisterClient.Pages.Profiles.Requests;
using Refit;

namespace GeldMeisterClient.Clients
{
    public interface IAuthorizationClient
    {
        [Post("/api/token")]
        public Task<IApiResponse<GetTokenResponse>> GetTokenAsync(SignInRequest request);
    }
}
