using JBD.MonitorCozinha.Domain.Entitys;
using JBD.MonitorCozinha.Domain.Interfaces.Repository;
using JBD.MonitorCozinha.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBD.MonitorCozinha.Domain.Services
{
    public class TelefoneService : ITelefoneService
    {
        ITelefoneRepository _repository = null;

        public TelefoneService(ITelefoneRepository repository)
        {
            _repository = repository;
        }


        public void Deletar(int Id)
        {
            _repository.Deletar(Id);
        }

        public List<TelefoneEntity> ListarTelefones()
        {
            return _repository.ListarTelefones();
        }

        public TelefoneEntity ObterTelefoneById(int Id)
        {
            return _repository.ObterTelefoneById(Id);
        }

        public void Salvar(TelefoneEntity telefone)
        {
            _repository.Salvar(telefone);
        }
    }
}
