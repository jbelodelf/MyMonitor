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
    public class MonitorController : ControllerBase
    {
        private readonly IMapper _mapper;
        INumeroPedidoApp _numeroPedidoApp;

        public MonitorController(IMapper mapper, INumeroPedidoApp numeroPedidoApp)
        {
            _mapper = mapper;
            _numeroPedidoApp = numeroPedidoApp;
        }

        // GET: api/Monitor
        [AcceptVerbs("GET")]
        [Route("ListarNumeroPedidos/{IdEmpresa}/{IdUnidade}")]
        public ObjectResult Get(int IdEmpresa, int IdUnidade)
        {
            var numeroPedidoEntity = _numeroPedidoApp.ListarPedidos(IdEmpresa, IdUnidade);
            var numeroPedidoDTO = _mapper.Map<List<NumeroPedidoDTO>>(numeroPedidoEntity);
            return StatusCode((int)HttpStatusCode.OK, numeroPedidoDTO);
        }

        [AcceptVerbs("GET")]
        [Route("ObterNumeroPedido/{id}")]
        public ObjectResult Get(int id)
        {
            var numeroPedidoEntity = _numeroPedidoApp.ObterPedidoById(id);
            var numeroPedidoDTO = _mapper.Map<NumeroPedidoDTO>(numeroPedidoEntity);
            return StatusCode((int)HttpStatusCode.OK, numeroPedidoDTO);
        }

        [AcceptVerbs("POST")]
        [Route("InserirNumeroPedido")]
        public ObjectResult Post([FromBody] NumeroPedidoDTO numeroPedido)
        {
            var numeroPedidoEntity = _mapper.Map<NumeroPedidoEntity>(numeroPedido);
            _numeroPedidoApp.Salvar(numeroPedidoEntity);
            return StatusCode((int)HttpStatusCode.Created, numeroPedido);
        }

        [AcceptVerbs("PUT")]
        [Route("AtualizaNumeroPedido")]
        public ObjectResult Put([FromBody] NumeroPedidoDTO numeroPedido)
        {
            var numeroPedidoEntity = _mapper.Map<NumeroPedidoEntity>(numeroPedido);
            _numeroPedidoApp.Salvar(numeroPedidoEntity);
            return StatusCode((int)HttpStatusCode.Created, numeroPedido);
        }

        [AcceptVerbs("GET")]
        [Route("DeleteNumeroPedido/{id}")]
        public ObjectResult Delete(int id)
        {
            _numeroPedidoApp.Deletar(id);
            return StatusCode((int)HttpStatusCode.OK, true);
        }
    }
}
