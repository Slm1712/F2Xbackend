using System;
using System.Collections.Generic;
using System.Text;

namespace com.F2X.Shared.ModelDTO
{
    public class UsuarioDTO
    {
        public long? usuarioId { get; set; }
        public string usuarioUser { get; set; }
        public string usuarioPassword { get; set; }
        public long instalacionId { get; set; }

    }
}
