using GeldMeisterClient.Clients.Responses;
using GeldMeisterClient.Pages.Profiles.Requests;
using Refit;

namespace GeldMeisterClient.Clients
{
    public interface IAuthenticationClient
    {
        [Post("/api/user")]
        public Task<IApiResponse> CreateUserAsync(SignUpRequest request);

        [Get("/api/user")]
        public Task<IApiResponse<UserResponse>> GetUserAsync([Query] string userName);
    }
}
