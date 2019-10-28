using Data.Repositories.Base;
using JBD.MonitorCozinha.Domain.Entitys;
using JBD.MonitorCozinha.Domain.Enuns;
using JBD.MonitorCozinha.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        //Delete Usuario
        public void Deletar(int Id)
        {
            Expression<Func<UsuarioEntity, bool>> expressionFiltro = (a => a.IdStatus == (int)StatusEnum.Ativo && a.IdUsuario == (Int64)Id);

            using (var rep = new RepositoryBase<UsuarioEntity>())
            {
                UsuarioEntity usuario = rep.Select(expressionFiltro).FirstOrDefault();
                if (usuario != null)
                {
                    rep.Delete(usuario);
                }
            }
        }

        //List Usuarios
        public List<UsuarioEntity> ListarUsuarios()
        {
            List<UsuarioEntity> ListaUsuarios = new List<UsuarioEntity>();
            Expression<Func<UsuarioEntity, bool>> expressionFiltro = (a => a.IdStatus == (int)StatusEnum.Ativo);

            using (var rep = new RepositoryBase<UsuarioEntity>())
            {
                ListaUsuarios = rep.Select(expressionFiltro).ToList();
            }
            return ListaUsuarios;
        }

        // Get Usuario By Id
        public UsuarioEntity ObterUsuarioById(int Id)
        {
            UsuarioEntity usuario = new UsuarioEntity();
            Expression<Func<UsuarioEntity, bool>> expressionFiltro = (a => a.IdStatus == (int)StatusEnum.Ativo && a.IdUsuario == (Int64)Id);

            using (var rep = new RepositoryBase<UsuarioEntity>())
            {
                usuario = rep.Select(expressionFiltro).FirstOrDefault();
            }
            return usuario;
        }

        public UsuarioEntity ObterUsuarioByUserName(string userName)
        {
            UsuarioEntity usuario = new UsuarioEntity();
            Expression<Func<UsuarioEntity, bool>> expressionFiltro = (a => a.IdStatus == (int)StatusEnum.Ativo && a.UserName.Trim() == userName.Trim());
            string[] includes = new string[] { "Pessoa" };

            using (var rep = new RepositoryBase<UsuarioEntity>())
            {
                usuario = rep.Select(expressionFiltro, includes).FirstOrDefault();
            }
            return usuario;
        }

        //Save Usuario
        public UsuarioEntity Salvar(UsuarioEntity usuario)
        {
            using (var rep = new RepositoryBase<UsuarioEntity>())
            {
                if (usuario.IdUsuario == 0)
                {
                    usuario = rep.Insert(usuario);
                }
                else
                {
                    rep.Update(usuario);
                    usuario = null;
                }
            }
            return usuario;
        }

        // Get Usuario By userName and Password
        public UsuarioEntity UsuarioLogar(string userName, string senha)
        {
            UsuarioEntity usuario = new UsuarioEntity();
            string[] includes = new string[] { "Unidade" };
            Expression<Func<UsuarioEntity, bool>> expressionFiltro = u => (u.IdStatus == (int)StatusEnum.Ativo && u.UserName.Trim() == userName.Trim() && u.Password.Trim() == senha.Trim());

            using (var rep = new RepositoryBase<UsuarioEntity>())
            {
                if (userName == "operacional")
                {
                    usuario = rep.Select(expressionFiltro).FirstOrDefault();
                }
                else
                {
                    usuario = rep.Select(expressionFiltro, includes).FirstOrDefault();
                }
            }
            return usuario;
        }
    }
}
