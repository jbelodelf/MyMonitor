using AutoMapper;
using JBD.MonitorCozinha.Domain.DTOS;
using JBD.MonitorCozinha.WebAdmin.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace JBD.MonitorCozinha.WebAdmin.Services
{
    public class UnidadeServiceWeb : ServiceBaseUrl
    {
        private readonly IMapper _mapper;

        public UnidadeServiceWeb(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<UnidadeViewModel> ListarUnidades()
        {
            using (HttpClient client = new HttpClient())
            {
                ServiceBase(client);
                HttpResponseMessage response = client.GetAsync("ListarUnidades").Result;
                string stringData = response.Content.ReadAsStringAsync().Result;
                List<UnidadeDTO> data = JsonConvert.DeserializeObject<List<UnidadeDTO>>(stringData);

                var unidadesModel = _mapper.Map<List<UnidadeViewModel>>(data);
                return unidadesModel;
            }
        }

        public List<UnidadeViewModel> ListarUnidadesByIdEmpresa(int Id)
        {
            using (HttpClient client = new HttpClient())
            {
                ServiceBase(client);
                HttpResponseMessage response = client.GetAsync("ListarUnidadeByIdEmpresa/" + Id).Result;
                string stringData = response.Content.ReadAsStringAsync().Result;
                List<UnidadeDTO> data = JsonConvert.DeserializeObject<List<UnidadeDTO>>(stringData);

                var unidadeModel = _mapper.Map<List<UnidadeViewModel>>(data);
                return unidadeModel;
            }

        }

        public UnidadeViewModel ObterUnidade (int Id)
        {
            using (HttpClient client = new HttpClient())
            {
                ServiceBase(client);
                HttpResponseMessage response = client.GetAsync("ObterUnidade/" + Id).Result;
                string stringData = response.Content.ReadAsStringAsync().Result;
                UnidadeDTO data = JsonConvert.DeserializeObject<UnidadeDTO>(stringData);

                var unidadeModel = _mapper.Map<UnidadeViewModel>(data);
                return unidadeModel;
            }

        }

        public UnidadeViewModel CadastrarUnidade(UnidadeViewModel unidade)
        {
            using (HttpClient client = new HttpClient())
            {
                var unidadeDTO = _mapper.Map<UnidadeDTO>(unidade);
                ServiceBase(client);
                string parametroJSON = JsonConvert.SerializeObject(unidadeDTO);
                StringContent conteudo = new StringContent(parametroJSON, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync("InserirUnidade", conteudo).Result;
                string stringData = response.Content.ReadAsStringAsync().Result;
                UnidadeDTO data = JsonConvert.DeserializeObject<UnidadeDTO>(stringData);
                unidade = _mapper.Map<UnidadeViewModel>(data);
            }
            return unidade;
        }

        public void AlterarUnidade(UnidadeViewModel unidade)
        {
            using (HttpClient client = new HttpClient())
            {
                var unidadeDTO = _mapper.Map<UnidadeDTO>(unidade);
                ServiceBase(client);
                string parametroJSON = JsonConvert.SerializeObject(unidadeDTO);
                StringContent conteudo = new StringContent(parametroJSON, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PutAsync("AlterarUnidade", conteudo).Result;
                string stringData = response.Content.ReadAsStringAsync().Result;
                UnidadeDTO data = JsonConvert.DeserializeObject<UnidadeDTO>(stringData);
            }
        }

        public void ServiceBase(HttpClient client)
        {
            client.BaseAddress = new Uri(Url);

            MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
        }


    }
}
