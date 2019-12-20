using JBD.MonitorCozinha.Application.Interfaces;
using JBD.MonitorCozinha.Domain.Entitys;
using JBD.MonitorCozinha.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBD.MonitorCozinha.Application.Repositories
{
    public class UsuarioRepositoryApp : IUsuarioApp
    {
        IUsuarioService _service = null;

        public UsuarioRepositoryApp(IUsuarioService service)
        {
            _service = service;
        }


        public void Deletar(int Id)
        {
            _service.Deletar(Id);
        }

        public List<UsuarioEntity> ListarUsuarios()
        {
            return _service.ListarUsuarios();
        }

        public UsuarioEntity ObterUsuarioById(int Id)
        {
            return _service.ObterUsuarioById(Id);
        }

        public UsuarioEntity ObterUsuarioByUserName(string userName)
        {
            return _service.ObterUsuarioByUserName(userName);
        }

        public UsuarioEntity Salvar(UsuarioEntity usuario)
        {
            return _service.Salvar(usuario);
        }

        public UsuarioEntity UsuarioLogar(string userName, string senha)
        {
            return _service.UsuarioLogar(userName,senha);
        }
    }
}
