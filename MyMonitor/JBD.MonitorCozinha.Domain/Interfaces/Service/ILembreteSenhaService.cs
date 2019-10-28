using JBD.MonitorCozinha.Domain.Entitys;
using System;

namespace JBD.MonitorCozinha.Domain.Interfaces.Service
{
    public interface ILembreteSenhaService
    {
        LembreteSenhaEntity ObterByChave(Guid chave);
        void Update(LembreteSenhaEntity lembreteSenhaEntity);
        void Delete(int IdLembreteSenha);
        void Insert(LembreteSenhaEntity lembreteSenhaEntity);
    }
}
