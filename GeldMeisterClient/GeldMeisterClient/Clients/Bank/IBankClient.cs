using GeldMeisterClient.Clients.Bank.Responses;
using GeldMeisterClient.Pages.Banks.Requests;
using Refit;

namespace GeldMeisterClient.Clients.Bank;

public interface IBankClient
{
    [Post("/api/bank")]
    public Task<IApiResponse> CreateBankAsync(BankCreateRequest request);

    [Get("/api/bank")]
    public Task<List<IApiResponse<BankDetailsResponse>>> GetAllBanksAsync();

    [Get("/api/bank/{id}")]
    public Task<IApiResponse<BankDetailsResponse>> GetBankAsync([Query] string id);

    [Patch("/api/bank")]
    public Task<IApiResponse> UpdateBankDetailsAsync(BankUpdateRequest request);

    [Delete("/api/bank/{id}")]
    public Task<IApiResponse> DeleteBankAsync([Query] string id);
}
