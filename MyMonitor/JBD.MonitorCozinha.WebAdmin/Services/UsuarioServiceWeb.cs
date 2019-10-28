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
    public class UsuarioServiceWeb
    {
        private readonly IMapper _mapper;

        public UsuarioServiceWeb(IMapper mapper)
        {
            _mapper = mapper;
        }

        #region Usuário
        public List<UsuarioViewModel> ListarUsuarios()
        {
            using (HttpClient client = new HttpClient())
            {
                ServiceBase(client);
                HttpResponseMessage response = client.GetAsync("ListarUsuarios").Result;
                string stringData = response.Content.ReadAsStringAsync().Result;
                List<UsuarioDTO> data = JsonConvert.DeserializeObject<List<UsuarioDTO>>(stringData);

                var usuariosModel = _mapper.Map<List<UsuarioViewModel>>(data);
                return usuariosModel;
            }
        }

        public UsuarioViewModel ObterUsuario(int IdUsuario)
        {
            using (HttpClient client = new HttpClient())
            {
                ServiceBase(client);
                HttpResponseMessage response = client.GetAsync("ObterUsuario/" + IdUsuario).Result;
                string stringData = response.Content.ReadAsStringAsync().Result;
                UsuarioDTO data = JsonConvert.DeserializeObject<UsuarioDTO>(stringData);

                var usuarioModel = _mapper.Map<UsuarioViewModel>(data);
                return usuarioModel;
            }
        }

        public UsuarioViewModel CadastrarUsuario(UsuarioViewModel usuario)
        {
            using (HttpClient client = new HttpClient())
            {
                var usuarioDTO = _mapper.Map<UsuarioDTO>(usuario);
                ServiceBase(client);
                string parametroJSON = JsonConvert.SerializeObject(usuarioDTO);
                StringContent conteudo = new StringContent(parametroJSON, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync("InserirUsuario", conteudo).Result;
                string stringData = response.Content.ReadAsStringAsync().Result;
                UsuarioDTO data = JsonConvert.DeserializeObject<UsuarioDTO>(stringData);
                usuario = _mapper.Map<UsuarioViewModel>(data);
            }
            return usuario;
        }

        public void AlterarUsuario(UsuarioViewModel usuario)
        {
            using (HttpClient client = new HttpClient())
            {
                var usuarioDTO = _mapper.Map<UsuarioDTO>(usuario);
                ServiceBase(client);
                string parametroJSON = JsonConvert.SerializeObject(usuarioDTO);
                StringContent conteudo = new StringContent(parametroJSON, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PutAsync("AlterarUsuario", conteudo).Result;
                string stringData = response.Content.ReadAsStringAsync().Result;
                UsuarioDTO data = JsonConvert.DeserializeObject<UsuarioDTO>(stringData);
            }
        }

        public UsuarioViewModel UsuarioLogar(string userName, string senha)
        {
            using (HttpClient client = new HttpClient())
            {
                ///api/Usuario/UsuarioLogar/{userName}/{senha}
                ServiceBase(client);
                HttpResponseMessage response = client.GetAsync("UsuarioLogar/" + userName + "/" + senha).Result;
                string stringData = response.Content.ReadAsStringAsync().Result;
                UsuarioDTO data = JsonConvert.DeserializeObject<UsuarioDTO>(stringData);

                var usuarioModel = _mapper.Map<UsuarioViewModel>(data);
                return usuarioModel;
            }
        }

        public UsuarioViewModel UsuarioByUsuerName(string userName)
        {
            using (HttpClient client = new HttpClient())
            {
                ///api/Usuario/UsuarioByUsuerName/{userName}/{senha}
                ServiceBase(client);
                HttpResponseMessage response = client.GetAsync("UsuarioByUsuerName/" + userName ).Result;
                string stringData = response.Content.ReadAsStringAsync().Result;
                UsuarioDTO data = JsonConvert.DeserializeObject<UsuarioDTO>(stringData);

                var usuarioModel = _mapper.Map<UsuarioViewModel>(data);
                return usuarioModel;
            }
        }
        #endregion

        public void ServiceBase(HttpClient client)
        {
            client.BaseAddress = new Uri("http://localhost:52936/api/Usuario/");
            //client.BaseAddress = new Uri("http://www.apimymonitor.com.br/api/Usuario/"); 
            MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
        }
    }
}
