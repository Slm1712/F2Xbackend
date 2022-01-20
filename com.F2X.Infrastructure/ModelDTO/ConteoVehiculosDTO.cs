using Newtonsoft.Json;

namespace com.F2X.Infrastructure.ModelDTO
{
    public class ConteoVehiculosDTO
    {
        public int recaudoId { get; set; } = 0;

        [JsonProperty("estacion")]
        public string recaudoEstacion { get; set; }

        [JsonProperty("sentido")]
        public string recaudoSentido { get; set; }

        [JsonProperty("hora")]
        public int recaudoHora { get; set; }

        [JsonProperty("categoria")]
        public string recaudoCategoria { get; set; }

        [JsonProperty("cantidad")]
        public int? recaudoCantidad { get; set; }

        [JsonProperty("valorTabulado")]
        public int? recaudoValorTabulado { get; set; }
    }
}
