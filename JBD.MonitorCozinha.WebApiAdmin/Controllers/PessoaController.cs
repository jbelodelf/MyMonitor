using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using JBD.MonitorCozinha.Application.Interfaces;
using JBD.MonitorCozinha.Domain.DTOS;
using JBD.MonitorCozinha.Domain.Entitys;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JBD.MonitorCozinha.WebApiAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowSpecificOrigin")]
    public class PessoaController : ControllerBase
    {

        private readonly IMapper _mapper;
        IPessoaApp _pessoaApp;


        public PessoaController(IMapper mapper, IPessoaApp pessoaApp)
        {
            _mapper = mapper;
            _pessoaApp = pessoaApp;
        }


        // GET: api/Pessoa
        //[HttpGet]
        [AcceptVerbs("GET")]
        [Route("ListarPessoas")]
        public ObjectResult Get()
        {
            var pessoaEntity = _pessoaApp.ListarPessoas();
            var pessoasDTO = _mapper.Map<List<PessoaDTO>>(pessoaEntity);
            return StatusCode((int)HttpStatusCode.OK, pessoasDTO);
        }

        // GET: api/Pessoa/
        //[HttpGet("{id}", Name = "Get")]
        [AcceptVerbs("GET")]
        [Route("ObterPessoa/{id}")]
        public ObjectResult Get(int id)
        {
            var pessoaEntity = _pessoaApp.ObterPessoaById(id);
            var pessoaDTO = _mapper.Map<PessoaDTO>(pessoaEntity);
            return StatusCode((int)HttpStatusCode.OK, pessoaDTO);
        }

        // GET: api/Pessoa/
        //[HttpGet("{id}", Name = "Get")]
        [AcceptVerbs("GET")]
        [Route("ListarPessoaByIdUnidade/{idUnidade}")]
        public ObjectResult GetPessoaByUnidade(int idUnidade)
        {
            var pessoaEntity = _pessoaApp.ListarPessoasByUnidade(idUnidade);
            var pessoaDTO = _mapper.Map<List<PessoaDTO>>(pessoaEntity);
            return StatusCode((int)HttpStatusCode.OK, pessoaDTO);
        }


        // POST: api/Pessoa
        //[HttpPost]
        [AcceptVerbs("POST")]
        [Route("InserirPessoa")]
        public ObjectResult Post([FromBody] PessoaDTO pessoa)
        {
            var pessoaEntity = _mapper.Map<PessoaEntity>(pessoa);
            _pessoaApp.Salvar(pessoaEntity);
            return StatusCode((int)HttpStatusCode.Created, pessoa);
        }

        // PUT: api/Pessoa/5
        //[HttpPut("{id}")]
        [AcceptVerbs("PUT")]
        [Route("AlterarPessoa")]
        public ObjectResult Put([FromBody] PessoaDTO pessoa)
        {
            var pessoaEntity = _mapper.Map<PessoaEntity>(pessoa);
            _pessoaApp.Salvar(pessoaEntity);
            return StatusCode((int)HttpStatusCode.Created, pessoa);
        }

        // DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        [AcceptVerbs("DELETE")]
        [Route("AlterarUnidade/{id}")]
        public ObjectResult Delete(int id)
        {
            _pessoaApp.Deletar(id);
            return StatusCode((int)HttpStatusCode.Created, id);
        }


    }
}
