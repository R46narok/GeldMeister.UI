using GeldMeisterClient.Clients.Bank;
using GeldMeisterClient.Clients.Bank.Responses;
using GeldMeisterClient.Pages.Banks.Requests;
using Microsoft.AspNetCore.Components;

namespace GeldMeisterClient.Services.Bank;

public class BankService : IBankService
{
    private readonly IBankClient _bankClient;
    private readonly NavigationManager _navigationManager;

    public BankService(IBankClient bankClient, NavigationManager navigationManager)
    {
        _bankClient = bankClient;
        _navigationManager = navigationManager;
    }

    public async Task CreateBank(BankCreateRequest request)
    {
        var result = await _bankClient.CreateBankAsync(request);

        if (result.IsSuccessStatusCode)
        {
            _navigationManager.NavigateTo("/", forceLoad: true);
        }
    }

    public Task<List<BankDetailsResponse>> GetAllBankDetails()
    {
        throw new NotImplementedException();
    }

    public Task<BankDetailsResponse> GetBankDetails(BankDetailsRequest request)
    {
        throw new NotImplementedException();
    }

    public Task UpdateBank(BankUpdateRequest request)
    {
        throw new NotImplementedException();
    }

    public Task DeleteBank(BankDeleteRequest request)
    {
        throw new NotImplementedException();
    }
}