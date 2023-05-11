namespace GeldMeisterClient.Clients.User.Responses
{
    public class GetTokenResponse
    {
        public string Token { get; set; }
        public DateTime ValidTo { get; set; }
    }
}