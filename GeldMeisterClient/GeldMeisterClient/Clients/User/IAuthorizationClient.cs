using GeldMeisterClient.Clients.User.Responses;
using GeldMeisterClient.Pages.Profiles.Requests;
using Refit;

namespace GeldMeisterClient.Clients.User
{
    public interface IAuthorizationClient
    {
        [Post("/api/token")]
        public Task<IApiResponse<GetTokenResponse>> GetTokenAsync(SignInRequest request);
    }
}
