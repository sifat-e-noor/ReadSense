using ReadSenseApi.Database.Entities;
using System.Text.Json.Serialization;

namespace ReadSenseApi.Models
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? UserName { get; set; }

        public Boolean? AgreementSigned { get; set; }

        [JsonPropertyName("accessToken")]
        public string Token { get; set; }


        public AuthenticateResponse(User user, string token)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            UserName = user.Username;
            AgreementSigned = user.AgreementSigned;
            Token = token;
        }
    }
}
