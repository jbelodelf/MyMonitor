using JBD.MonitorCozinha.Domain.Entitys;
using JBD.MonitorCozinha.Domain.Interfaces.Repository;
using JBD.MonitorCozinha.Domain.Interfaces.Service;
using System.Collections.Generic;

namespace JBD.MonitorCozinha.Domain.Services
{
    public class UsuarioService : IUsuarioService
    {
        IUsuarioRepository _repository = null;

        public UsuarioService(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public void Deletar(int Id)
        {
            _repository.Deletar(Id);
        }

        public List<UsuarioEntity> ListarUsuarios()
        {
            return _repository.ListarUsuarios();
        }

        public UsuarioEntity ObterUsuarioById(int Id)
        {
            return _repository.ObterUsuarioById(Id);
        }

        public UsuarioEntity Salvar(UsuarioEntity usuario)
        {
            return _repository.Salvar(usuario);
        }

        public UsuarioEntity UsuarioLogar(string userName, string senha)
        {
            return _repository.UsuarioLogar(userName, senha);
        }
    }
}
