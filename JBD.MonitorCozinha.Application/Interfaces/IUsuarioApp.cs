using JBD.MonitorCozinha.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBD.MonitorCozinha.Application.Interfaces
{
    public interface IUsuarioApp
    {
        List<UsuarioEntity> ListarUsuarios();
        UsuarioEntity ObterUsuarioById(int Id);
        UsuarioEntity Salvar(UsuarioEntity usuario);
        void Deletar(int Id);
        UsuarioEntity UsuarioLogar(string userName, string senha);
    }
}
