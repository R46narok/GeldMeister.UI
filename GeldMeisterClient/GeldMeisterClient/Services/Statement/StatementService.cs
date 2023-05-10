using GeldMeisterClient.Clients.Statement;
using GeldMeisterClient.Pages.Statements.Requests;

namespace GeldMeisterClient.Services.Statement;

public class StatementService : IStatementService
{
    private readonly IStatementClient _statementClient;

    public StatementService(IStatementClient statementClient)
    {
        _statementClient = statementClient;
    }

    public async Task CreateStatement(StatementCreateRequest request)
    {
        var result = await _statementClient.CreateStatementAsync(request);

        if (result.IsSuccessStatusCode)
        {
            
        }
    }

    public Task GetStatementDetails(StatementDetailsRequest request)
    {
        throw new NotImplementedException();
    }
}