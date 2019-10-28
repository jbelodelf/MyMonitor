using System;

namespace JBD.MonitorCozinha.WebAdmin.Models
{
    public class LembreteSenhaViewModel
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
