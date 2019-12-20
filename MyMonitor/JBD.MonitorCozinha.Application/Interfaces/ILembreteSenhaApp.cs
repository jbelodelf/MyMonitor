using JBD.MonitorCozinha.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBD.MonitorCozinha.Application.Interfaces
{
    public interface ILembreteSenhaApp
    {
        LembreteSenhaEntity ObterByChave(Guid chave);
        void Update(LembreteSenhaEntity lembreteSenhaEntity);
        void Delete(int IdLembreteSenha);
        void Insert(LembreteSenhaEntity lembreteSenhaEntity);
    }
}
