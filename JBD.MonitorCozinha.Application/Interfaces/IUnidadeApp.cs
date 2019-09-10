using JBD.MonitorCozinha.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBD.MonitorCozinha.Application.Interfaces
{
    public interface IUnidadeApp
    {
        List<UnidadeEntity> ListarUnidades();
        UnidadeEntity ObterUnidadeById(int Id);
        List<UnidadeEntity> ListarUnidadesByEmpresa(int IdEmpresa);
        UnidadeEntity Salvar(UnidadeEntity unidade);
        void Deletar(int Id);

    }
}
