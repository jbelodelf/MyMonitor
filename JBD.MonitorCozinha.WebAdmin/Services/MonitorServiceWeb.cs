using AutoMapper;
using JBD.MonitorCozinha.Domain.DTOS;
using JBD.MonitorCozinha.WebAdmin.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace JBD.MonitorCozinha.WebAdmin.Services
{
    public class MonitorServiceWeb
    {
        private readonly IMapper _mapper;

        public MonitorServiceWeb(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<NumeroPedidoViewModel> ListarNumeroPedidos(int IdEmpresa, int IdUnidade)
        {
            using (HttpClient client = new HttpClient())
            {
                ServiceBase(client);
                string parametros = string.Format("/{0}/{1}", IdEmpresa, IdUnidade);
                HttpResponseMessage response = client.GetAsync("ListarNumeroPedidos" + parametros).Result;
                string stringData = response.Content.ReadAsStringAsync().Result;
                List<NumeroPedidoDTO> data = JsonConvert.DeserializeObject<List<NumeroPedidoDTO>>(stringData);

                var numeroPedidoModel = _mapper.Map<List<NumeroPedidoViewModel>>(data);
                return numeroPedidoModel;
            }
        }

        public void ServiceBase(HttpClient client)
        {
            //client.BaseAddress = new Uri("http://localhost:52936/api/Monitor/");
            client.BaseAddress = new Uri("http://www.apimymonitor.com.br/api/Monitor/");
            MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
        }

    }
}
