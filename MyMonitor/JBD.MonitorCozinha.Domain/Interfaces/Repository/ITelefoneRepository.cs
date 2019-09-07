using JBD.MonitorCozinha.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBD.MonitorCozinha.Domain.Interfaces.Repository
{
    public interface ITelefoneRepository
    {
        List<TelefoneEntity> ListarTelefones();
        TelefoneEntity ObterTelefoneById(int Id);
        void Salvar(TelefoneEntity telefone);
        void Deletar(int Id);

    }
}
