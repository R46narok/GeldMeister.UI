using GeldMeisterClient.Pages.Statements.Requests;

namespace GeldMeisterClient.Services.Statement;

public interface IStatementService
{
    Task CreateStatement(StatementCreateRequest request);
    Task GetStatementDetails(StatementDetailsRequest request);
}