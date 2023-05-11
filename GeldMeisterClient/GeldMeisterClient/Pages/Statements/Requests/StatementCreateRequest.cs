using Microsoft.AspNetCore.Components.Forms;

namespace GeldMeisterClient.Pages.Statements.Requests;

public class StatementCreateRequest
{
    public string BankId { get; set; }
    public IBrowserFile File { get; set; }
}