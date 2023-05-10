using GeldMeisterClient.Clients.Statement.Responses;
using GeldMeisterClient.Pages.Statements.Requests;
using Refit;

namespace GeldMeisterClient.Clients.Statement;

public interface IStatementClient
{
    [Post("/api/bankstatements")]
    public Task<IApiResponse> CreateStatementAsync(StatementCreateRequest request);

    [Get("/api/bankstatements/{id}")]
    public Task<IApiResponse<StatementDetailsResponse>> GetStatementAsync([Query] string id);
}