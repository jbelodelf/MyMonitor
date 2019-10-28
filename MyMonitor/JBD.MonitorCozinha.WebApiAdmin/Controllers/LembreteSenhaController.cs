using System;
using System.Net;
using AutoMapper;
using JBD.MonitorCozinha.Application.Interfaces;
using JBD.MonitorCozinha.Domain.DTOS;
using JBD.MonitorCozinha.Domain.Entitys;
using Microsoft.AspNetCore.Mvc;

namespace JBD.MonitorCozinha.WebApiAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LembreteSenhaController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILembreteSenhaApp _lembreteSenhaApp;

        public LembreteSenhaController(IMapper mapper, ILembreteSenhaApp lembreteSenhaApp)
        {
            _mapper = mapper;
            _lembreteSenhaApp = lembreteSenhaApp;
        }

        [AcceptVerbs("GET")]
        [Route("ObterLembreteSenhaByChave/{chave}")]
        public ObjectResult Get(Guid chave)
        {
            var lembreteSenhaEntity = _lembreteSenhaApp.ObterByChave(chave);
            var lembreteSenhaDTO = _mapper.Map<LembreteSenhaDTO>(lembreteSenhaEntity);
            return StatusCode((int)HttpStatusCode.OK, lembreteSenhaDTO);
        }

        [AcceptVerbs("POST")]
        [Route("InserirLembreteSenha")]
        public ObjectResult Post([FromBody] LembreteSenhaDTO lembreteSenha)
        {
            var lembreteSenhaEntity = _mapper.Map<LembreteSenhaEntity>(lembreteSenha);
            _lembreteSenhaApp.Insert(lembreteSenhaEntity);
            return StatusCode((int)HttpStatusCode.Created, lembreteSenha);
        }

        [AcceptVerbs("PUT")]
        [Route("AlterarLembreteSenha")]
        public ObjectResult Put([FromBody] LembreteSenhaDTO lembreteSenha)
        {
            var lembreteSenhaEntity = _mapper.Map<LembreteSenhaEntity>(lembreteSenha);
            _lembreteSenhaApp.Update(lembreteSenhaEntity);
            return StatusCode((int)HttpStatusCode.Created, lembreteSenha);
        }

        [AcceptVerbs("DELETE")]
        [Route("DeleteLembreteSenha/{idLembreteSenha}")]
        public ObjectResult Delete(int idLembreteSenha)
        {
            _lembreteSenhaApp.Delete(idLembreteSenha);
            return StatusCode((int)HttpStatusCode.Created, idLembreteSenha);
        }
    }
}