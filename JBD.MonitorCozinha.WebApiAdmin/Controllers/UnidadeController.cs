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
    public class UnidadeController : ControllerBase
    {
        private readonly IMapper _mapper;
        IUnidadeApp _unidadeApp;


        public UnidadeController(IMapper mapper, IUnidadeApp unidadeApp)
        {
            _mapper = mapper;
            _unidadeApp = unidadeApp;
        }

        // GET: api/Unidade
        //[HttpGet]
        [AcceptVerbs("GET")]
        [Route("ListarUnidades")]
        public ObjectResult Get()
        {
            var unidadeEntity = _unidadeApp.ListarUnidades();
            var unidadesDTO = _mapper.Map<List<UnidadeDTO>>(unidadeEntity);
            return StatusCode((int)HttpStatusCode.OK, unidadesDTO);
        }

        // GET: api/Unidade/
        //[HttpGet("{id}", Name = "Get")]
        [AcceptVerbs("GET")]
        [Route("ObterUnidade/{id}")]
        public ObjectResult Get(int id)
        {
            var unidadeEntity = _unidadeApp.ObterUnidadeById(id);
            var unidadeDTO = _mapper.Map<UnidadeDTO>(unidadeEntity);
            return StatusCode((int)HttpStatusCode.OK, unidadeDTO);
        }

        // GET: api/Unidade/
        //[HttpGet("{id}", Name = "Get")]
        [AcceptVerbs("GET")]
        [Route("ListarUnidadeByIdEmpresa/{idEmpresa}")]
        public ObjectResult GetUnidadeByEmpresa(int idEmpresa)
        {
            var unidadeEntity = _unidadeApp.ListarUnidadesByEmpresa(idEmpresa);
            var unidadeDTO = _mapper.Map<List<UnidadeDTO>>(unidadeEntity);
            return StatusCode((int)HttpStatusCode.OK, unidadeDTO);
        }

        // POST: api/Unidade
        //[HttpPost]
        [AcceptVerbs("POST")]
        [Route("InserirUnidade")]
        public ObjectResult Post([FromBody] UnidadeDTO unidade)
        {
            var unidadeEntity = _mapper.Map<UnidadeEntity>(unidade);
            unidadeEntity = _unidadeApp.Salvar(unidadeEntity);
            unidade = _mapper.Map<UnidadeDTO>(unidadeEntity);
            return StatusCode((int)HttpStatusCode.Created, unidade);
        }

        // PUT: api/Unidade/5
        //[HttpPut("{id}")]
        [AcceptVerbs("PUT")]
        [Route("AlterarUnidade")]
        public ObjectResult Put([FromBody] UnidadeDTO unidade)
        {
            var unidadeEntity = _mapper.Map<UnidadeEntity>(unidade);
            _unidadeApp.Salvar(unidadeEntity);
            return StatusCode((int)HttpStatusCode.Created, unidade);
        }

        // DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        [AcceptVerbs("DELETE")]
        [Route("AlterarUnidade/{id}")]
        public ObjectResult Delete(int id)
        {
            _unidadeApp.Deletar(id);
            return StatusCode((int)HttpStatusCode.Created, id);
        }
    }
}
