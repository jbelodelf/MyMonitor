using System.Collections.Generic;
using System.Net;
using AutoMapper;
using JBD.MonitorCozinha.Application.Interfaces;
using JBD.MonitorCozinha.Domain.DTOS;
using JBD.MonitorCozinha.Domain.Entitys;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace JBD.MonitorCozinha.WebApiAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowSpecificOrigin")]
    public class UsuarioController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioApp _usuarioApp;

        public UsuarioController(IMapper mapper, IUsuarioApp usuarioApp)
        {
            _mapper = mapper;
            _usuarioApp = usuarioApp;
        }

        [AcceptVerbs("GET")]
        [Route("ListarUsuarioss")]
        public ObjectResult Get()
        {
            var usuariosEntity = _usuarioApp.ListarUsuarios();
            var usuariosDTO = _mapper.Map<List<UsuarioDTO>>(usuariosEntity);
            return StatusCode((int)HttpStatusCode.OK, usuariosDTO);
        }

        [AcceptVerbs("GET")]
        [Route("ObterUsuario/{id}")]
        public ObjectResult Get(int id)
        {
            var usuarioEntity = _usuarioApp.ObterUsuarioById(id);
            var usuarioDTO = _mapper.Map<UsuarioDTO>(usuarioEntity);
            return StatusCode((int)HttpStatusCode.OK, usuarioDTO);
        }

        [AcceptVerbs("POST")]
        [Route("InserirUsuario")]
        public ObjectResult Post([FromBody] UsuarioDTO usuario)
        {
            var usuarioEntity = _mapper.Map<UsuarioEntity>(usuario);
            usuarioEntity = _usuarioApp.Salvar(usuarioEntity);
            usuario = _mapper.Map<UsuarioDTO>(usuarioEntity);
            return StatusCode((int)HttpStatusCode.Created, usuario);
        }

        [AcceptVerbs("PUT")]
        [Route("AlterarUsuario")]
        public ObjectResult Put([FromBody] UsuarioDTO usuario)
        {
            var usuarioEntity = _mapper.Map<UsuarioEntity>(usuario);
            _usuarioApp.Salvar(usuarioEntity);
            return StatusCode((int)HttpStatusCode.Created, usuario);
        }

        [AcceptVerbs("DELETE")]
        [Route("AlterarUsuario/{id}")]
        public ObjectResult Delete(int id)
        {
            _usuarioApp.Deletar(id);
            return StatusCode((int)HttpStatusCode.Created, id);
        }

        [AcceptVerbs("GET")]
        [Route("UsuarioLogar/{userName}/{senha}")]
        public ObjectResult Get(string userName, string senha)
        {
            var usuarioEntity = _usuarioApp.UsuarioLogar(userName, senha);
            var usuarioDTO = _mapper.Map<UsuarioDTO>(usuarioEntity);
            return StatusCode((int)HttpStatusCode.OK, usuarioDTO);
        }

    }
}
