using JBD.MonitorCozinha.Application.Interfaces;
using JBD.MonitorCozinha.Domain.Entitys;
using JBD.MonitorCozinha.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBD.MonitorCozinha.Application.Repositories
{
    public class TelefoneRepositoryApp : ITelefoneApp
    {
        ITelefoneService _service = null;

        public TelefoneRepositoryApp(ITelefoneService service)
        {
            _service = service;
        }


        public void Deletar(int Id)
        {
            _service.Deletar(Id);
        }

        public List<TelefoneEntity> ListarTelefones()
        {
            return _service.ListarTelefones();
        }

        public TelefoneEntity ObterTelefoneById(int Id)
        {
            return _service.ObterTelefoneById(Id);
        }

        public void Salvar(TelefoneEntity telefone)
        {
            _service.Salvar(telefone);
        }
    }
}
