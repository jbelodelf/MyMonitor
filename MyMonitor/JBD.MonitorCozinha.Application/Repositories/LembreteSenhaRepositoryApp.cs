using JBD.MonitorCozinha.Application.Interfaces;
using JBD.MonitorCozinha.Domain.Entitys;
using JBD.MonitorCozinha.Domain.Interfaces.Service;
using System;

namespace JBD.MonitorCozinha.Application.Repositories
{
    public class LembreteSenhaRepositoryApp : ILembreteSenhaApp
    {
        private ILembreteSenhaService _service;

        public LembreteSenhaRepositoryApp(ILembreteSenhaService service)
        {
            _service = service;
        }

        public void Delete(int IdLembreteSenha)
        {
            _service.Delete(IdLembreteSenha);
        }

        public void Insert(LembreteSenhaEntity lembreteSenhaEntity)
        {
            _service.Insert(lembreteSenhaEntity);
        }

        public LembreteSenhaEntity ObterByChave(Guid chave)
        {
            return _service.ObterByChave(chave);
        }

        public void Update(LembreteSenhaEntity lembreteSenhaEntity)
        {
            _service.Update(lembreteSenhaEntity);
        }
    }
}
