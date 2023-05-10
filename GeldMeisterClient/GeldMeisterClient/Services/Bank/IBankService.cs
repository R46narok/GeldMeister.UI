using GeldMeisterClient.Clients.Bank.Responses;
using GeldMeisterClient.Pages.Banks.Requests;

namespace GeldMeisterClient.Services.Bank;

public interface IBankService
{
    Task CreateBank(BankCreateRequest request);
    Task<List<BankDetailsResponse>> GetAllBankDetails();
    Task<BankDetailsResponse> GetBankDetails(BankDetailsRequest request);
    Task UpdateBank(BankUpdateRequest request);
    Task DeleteBank(BankDeleteRequest request);
}