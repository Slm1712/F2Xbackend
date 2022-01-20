using System;
using System.Collections.Generic;

namespace com.F2X.Infrastructure.Models
{
    public partial class recaudos
    {
        public long recaudoId { get; set; }
        public string recaudoEstacion { get; set; }
        public string recaudoSentido { get; set; }
        public int recaudoHora { get; set; }
        public string recaudoCategoria { get; set; }
        public int? recaudoCantidad { get; set; }
        public int? recaudoValorTabulado { get; set; }
    }
}
