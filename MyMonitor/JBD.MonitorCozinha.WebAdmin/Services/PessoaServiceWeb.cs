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
    public class PessoaServiceWeb
    {
        private readonly IMapper _mapper;

        public PessoaServiceWeb(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<PessoaViewModel> ListarPessoas()
        {
            using (HttpClient client = new HttpClient())
            {
                ServiceBase(client);
                HttpResponseMessage response = client.GetAsync("ListarPessoas").Result;
                string stringData = response.Content.ReadAsStringAsync().Result;
                List<PessoaDTO> data = JsonConvert.DeserializeObject<List<PessoaDTO>>(stringData);

                var pessoasModel = _mapper.Map<List<PessoaViewModel>>(data);
                return pessoasModel;
            }

        }

        public List<PessoaViewModel> ListarPessoaByIdUnidade(int Id)
        {
            using (HttpClient client = new HttpClient())
            {
                ServiceBase(client);
                HttpResponseMessage response = client.GetAsync("ListarPessoaByIdUnidade/" + Id).Result;
                string stringData = response.Content.ReadAsStringAsync().Result;
                List<PessoaDTO> data = JsonConvert.DeserializeObject<List<PessoaDTO>>(stringData);

                var pessoaModel = _mapper.Map<List<PessoaViewModel>>(data);
                return pessoaModel;
            }
        }

        public PessoaViewModel ObterPessoa (int Id)
        {
            using (HttpClient client = new HttpClient())
            {
                ServiceBase(client);
                HttpResponseMessage response = client.GetAsync("ObterPessoa/" + Id).Result;
                string stringData = response.Content.ReadAsStringAsync().Result;
                PessoaDTO data = JsonConvert.DeserializeObject<PessoaDTO>(stringData);

                var pessoaModel = _mapper.Map<PessoaViewModel>(data);
                return pessoaModel;
            }
        }

        public void CadastrarPessoa(PessoaViewModel pessoa)
        {
            using (HttpClient client = new HttpClient())
            {
                var pessoaDTO = _mapper.Map<PessoaDTO>(pessoa);
                ServiceBase(client);
                string parametroJSON = JsonConvert.SerializeObject(pessoaDTO);
                StringContent conteudo = new StringContent(parametroJSON, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync("InserirPessoa", conteudo).Result;
                string stringData = response.Content.ReadAsStringAsync().Result;
                PessoaDTO data = JsonConvert.DeserializeObject<PessoaDTO>(stringData);
            }
        }

        public void AlterarPessoa(PessoaViewModel pessoa)
        {
            using (HttpClient client = new HttpClient())
            {
                var pessoaDTO = _mapper.Map<PessoaDTO>(pessoa);
                ServiceBase(client);
                string parametroJSON = JsonConvert.SerializeObject(pessoaDTO);
                StringContent conteudo = new StringContent(parametroJSON, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PutAsync("AlterarPessoa", conteudo).Result;
                string stringData = response.Content.ReadAsStringAsync().Result;
                PessoaDTO data = JsonConvert.DeserializeObject<PessoaDTO>(stringData);
            }
        }

        public void ServiceBase(HttpClient client)
        {
            client.BaseAddress = new Uri("http://localhost:52936/api/Pessoa/");
            //client.BaseAddress = new Uri("http://www.apimymonitor.com.br/api/Pessoa/");
            MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
        }
    }
}
