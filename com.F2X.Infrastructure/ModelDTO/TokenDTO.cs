using Newtonsoft.Json;
namespace com.F2X.Infrastructure.ModelDTO
{
    public class TokenDTO
    {
        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
