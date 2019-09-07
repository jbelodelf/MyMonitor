using System;
using System.Collections.Generic;
using System.Text;

namespace JBD.MonitorCozinha.Domain.DTOS
{
    public class TipoUsuarioDTO
    {
        public int IdTipoUsuario { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}
