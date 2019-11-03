using AutoMapper;
using JBD.MonitorCozinha.Domain.DTOS;
using JBD.MonitorCozinha.WebAdmin.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace JBD.MonitorCozinha.WebAdmin.Services
{
    public class LembreteSenhaServiceWeb : ServiceBaseUrl
    {
        private readonly IMapper _mapper;

        public LembreteSenhaServiceWeb(IMapper mapper)
        {
            _mapper = mapper;
        }

        #region Lembrete de senha
        public void CadastrarLembreteSenha(LembreteSenhaViewModel lembreteSenhaView)
        {
            using (HttpClient client = new HttpClient())
            {
                var lembreteSenhaDTO = _mapper.Map<LembreteSenhaDTO>(lembreteSenhaView);
                ServiceBase(client);
                string parametroJSON = JsonConvert.SerializeObject(lembreteSenhaDTO);
                StringContent conteudo = new StringContent(parametroJSON, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync("InserirLembreteSenha", conteudo).Result;
                string stringData = response.Content.ReadAsStringAsync().Result;
                LembreteSenhaDTO data = JsonConvert.DeserializeObject<LembreteSenhaDTO>(stringData);
                lembreteSenhaView = _mapper.Map<LembreteSenhaViewModel>(data);
            }
        }

        public void AlterarLembreteSenha(LembreteSenhaViewModel lembreteSenhaView)
        {
            using (HttpClient client = new HttpClient())
            {
                var lembreteSenhaDTO = _mapper.Map<LembreteSenhaDTO>(lembreteSenhaView);
                ServiceBase(client);
                string parametroJSON = JsonConvert.SerializeObject(lembreteSenhaDTO);
                StringContent conteudo = new StringContent(parametroJSON, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PutAsync("AlterarLembreteSenha", conteudo).Result;
                string stringData = response.Content.ReadAsStringAsync().Result;
                LembreteSenhaDTO data = JsonConvert.DeserializeObject<LembreteSenhaDTO>(stringData);
            }
        }

        public LembreteSenhaViewModel ObterLembreteSenha(Guid chave)
        {
            using (HttpClient client = new HttpClient())
            {
                ServiceBase(client);
                HttpResponseMessage response = client.GetAsync("ObterLembreteSenhaByChave/" + chave).Result;
                string stringData = response.Content.ReadAsStringAsync().Result;
                LembreteSenhaDTO data = JsonConvert.DeserializeObject<LembreteSenhaDTO>(stringData);

                var LembreteSenhaModel = _mapper.Map<LembreteSenhaViewModel>(data);
                return LembreteSenhaModel;
            }
        }
        #endregion

        public void ServiceBase(HttpClient client)
        {
            client.BaseAddress = new Uri(Url);

            MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
        }
    }
}
