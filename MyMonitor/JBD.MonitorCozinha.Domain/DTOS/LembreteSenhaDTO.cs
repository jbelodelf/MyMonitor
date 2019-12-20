using System;

namespace JBD.MonitorCozinha.Domain.DTOS
{
    public class LembreteSenhaDTO
    {
        public int IdLembreteSenha { get; set; }
        public int IdUsuario { get; set; }
        public int IdPessoa { get; set; }
        public string UserName { get; set; }
        public Guid Chave { get; set; }
        public bool ChaveValida { get; set; }
        public DateTime DataGerado { get; set; }
    }
}
