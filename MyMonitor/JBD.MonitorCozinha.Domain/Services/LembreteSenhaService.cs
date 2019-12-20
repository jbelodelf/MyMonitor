using JBD.MonitorCozinha.Domain.Entitys;
using JBD.MonitorCozinha.Domain.Interfaces.Repository;
using JBD.MonitorCozinha.Domain.Interfaces.Service;
using System;

namespace JBD.MonitorCozinha.Domain.Services
{
    public class LembreteSenhaService : ILembreteSenhaService
    {
        private ILembreteSenhaRepository _repository;

        public LembreteSenhaService(ILembreteSenhaRepository repository)
        {
            _repository = repository;
        }

        public void Delete(int IdLembreteSenha)
        {
            _repository.Delete(IdLembreteSenha);
        }

        public void Insert(LembreteSenhaEntity lembreteSenhaEntity)
        {
            _repository.Insert(lembreteSenhaEntity);
        }

        public LembreteSenhaEntity ObterByChave(Guid chave)
        {
            return _repository.ObterByChave(chave);
        }

        public void Update(LembreteSenhaEntity lembreteSenhaEntity)
        {
            _repository.Update(lembreteSenhaEntity);
        }
    }
}
