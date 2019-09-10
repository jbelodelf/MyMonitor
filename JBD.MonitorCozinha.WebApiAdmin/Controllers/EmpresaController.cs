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
    [Route("api/empresa")]
    [ApiController]
    [EnableCors("AllowSpecificOrigin")]
    public class EmpresaController : ControllerBase
    {
        private readonly IMapper _mapper;
        IEmpresaApp _empresaApp;

        public EmpresaController(IMapper mapper, IEmpresaApp empresaApp)
        {
            _mapper = mapper;
            _empresaApp = empresaApp;
        }

        //[AcceptVerbs("GET")]
        //[Route("ListarEmpresas")]
        [HttpGet("listar")]
        public ObjectResult Get()
        {
            var empresasEntity = _empresaApp.ListarEmpresas();
            var empresasDTO = _mapper.Map<List<EmpresaDTO>>(empresasEntity);
            return StatusCode((int)HttpStatusCode.OK, empresasDTO); 
        }

        [AcceptVerbs("GET")]
        [Route("ObterEmpresa/{id}")]
        public ObjectResult Get(int id)
        {
            var empresaEntity = _empresaApp.ObterEmpresaById(id);
            var empresaDTO = _mapper.Map<EmpresaDTO>(empresaEntity);
            return StatusCode((int)HttpStatusCode.OK, empresaDTO);
        }

        [AcceptVerbs("POST")]
        [Route("InserirEmpresa")]
        public ObjectResult Post([FromBody] EmpresaDTO empresa)
        {
            var empresaEntity = _mapper.Map<EmpresaEntity>(empresa);
            empresaEntity = _empresaApp.Salvar(empresaEntity);
            empresa = _mapper.Map<EmpresaDTO>(empresaEntity);
            return StatusCode((int)HttpStatusCode.Created, empresa);
        }

        [AcceptVerbs("PUT")]
        [Route("AlterarEmpresa")]
        public ObjectResult Put([FromBody] EmpresaDTO empresa)
        {
            var empresaEntity = _mapper.Map<EmpresaEntity>(empresa);
            _empresaApp.Salvar(empresaEntity);
            return StatusCode((int)HttpStatusCode.Created, empresa);
        }

        [AcceptVerbs("DELETE")]
        [Route("AlterarEmpresa/{id}")]
        public ObjectResult Delete(int id)
        {
            _empresaApp.Deletar(id);
            return StatusCode((int)HttpStatusCode.Created, id);
        }

        [AcceptVerbs("GET")]
        [Route("GetVerificaDuplicidadeCPF/{cpfcnpj}")]
        public ObjectResult GetVerificaDuplicidadeCPF(string cpfcnpj)
        {
            bool retorno = _empresaApp.VeficaDuplicidadeCnpjCpf(cpfcnpj);
            return StatusCode((int)HttpStatusCode.OK, retorno);

        }

    }
}
