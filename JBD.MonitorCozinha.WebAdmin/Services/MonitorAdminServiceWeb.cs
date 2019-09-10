using AutoMapper;
using JBD.MonitorCozinha.Domain.DTOS;
using JBD.MonitorCozinha.WebAdmin.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace JBD.MonitorCozinha.WebAdmin.Services
{
    public class MonitorAdminServiceWeb
    {
        private readonly IMapper _mapper;

        public MonitorAdminServiceWeb(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<NumeroPedidoViewModel> ListarNumeroPedidos(int IdEmpresa, int IdUnidade)
        {
            using (HttpClient client = new HttpClient())
            {
                ServiceBase(client);
                string paramentos = string.Format("{0}/{1}", IdEmpresa, IdUnidade);
                HttpResponseMessage response = client.GetAsync("ListarNumeroPedidos/" + paramentos).Result;
                string stringData = response.Content.ReadAsStringAsync().Result;
                List<NumeroPedidoDTO> data = JsonConvert.DeserializeObject<List<NumeroPedidoDTO>>(stringData);

                var numeroPedidoModel = _mapper.Map<List<NumeroPedidoViewModel>>(data);
                return numeroPedidoModel;
            }
        }

        public NumeroPedidoViewModel ObterNumeroPedido(int IdNumeroPedido)
        {
            using (HttpClient client = new HttpClient())
            {
                ServiceBase(client);
                HttpResponseMessage response = client.GetAsync("ObterNumeroPedido/" + IdNumeroPedido).Result;
                string stringData = response.Content.ReadAsStringAsync().Result;
                NumeroPedidoDTO data = JsonConvert.DeserializeObject<NumeroPedidoDTO>(stringData);

                var numeroPedidoModel = _mapper.Map<NumeroPedidoViewModel>(data);
                return numeroPedidoModel;
            }
        }

        public void CadastrarNumeroPedido(NumeroPedidoViewModel numeroPedido)
        {
            using (HttpClient client = new HttpClient())
            {
                var numeroPedidoDTO = _mapper.Map<NumeroPedidoDTO>(numeroPedido);
                ServiceBase(client);
                string parametroJSON = JsonConvert.SerializeObject(numeroPedidoDTO);
                StringContent conteudo = new StringContent(parametroJSON, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync("InserirNumeroPedido", conteudo).Result;
                string stringData = response.Content.ReadAsStringAsync().Result;
                NumeroPedidoDTO data = JsonConvert.DeserializeObject<NumeroPedidoDTO>(stringData);
            }
        }

        public void AlterarNumeroPedido(NumeroPedidoViewModel numeroPedido)
        {
            using (HttpClient client = new HttpClient())
            {
                var numeroPedidoDTO = _mapper.Map<NumeroPedidoDTO>(numeroPedido);
                ServiceBase(client);
                string parametroJSON = JsonConvert.SerializeObject(numeroPedidoDTO);
                StringContent conteudo = new StringContent(parametroJSON, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PutAsync("AtualizaNumeroPedido", conteudo).Result;
                string stringData = response.Content.ReadAsStringAsync().Result;
                NumeroPedidoDTO data = JsonConvert.DeserializeObject<NumeroPedidoDTO>(stringData);
            }
        }

        public bool DeletarNumeroPedido(int IdNumeroPedido)
        {
            using (HttpClient client = new HttpClient())
            {
                ServiceBase(client);
                HttpResponseMessage response = client.GetAsync("DeleteNumeroPedido/" + IdNumeroPedido).Result;
                string stringData = response.Content.ReadAsStringAsync().Result;
                bool data = JsonConvert.DeserializeObject<bool>(stringData);

                return data;
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
