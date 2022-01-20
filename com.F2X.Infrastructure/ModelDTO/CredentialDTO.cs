using Newtonsoft.Json;
namespace com.F2X.Infrastructure.ModelDTO
{
    public class CredentialDTO
    {
        [JsonProperty("userName")]
        public string userName { get; set; }

        [JsonProperty("password")]
        public string password { get; set; }
    }
}
