﻿using AutoMapper;
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
    public class EmpresaServiceWeb : ServiceBaseUrl
    {
        private readonly IMapper _mapper;

        public EmpresaServiceWeb(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<EmpresaViewModel> ListarEmpresas()
        {
            using (HttpClient client = new HttpClient())
            {
                ServiceBase(client);
                HttpResponseMessage response = client.GetAsync("empresa/listar").Result;
                string stringData = response.Content.ReadAsStringAsync().Result;
                List<EmpresaDTO> data = JsonConvert.DeserializeObject<List<EmpresaDTO>>(stringData);

                var empresasModel = _mapper.Map<List<EmpresaViewModel>>(data);
                return empresasModel;
            }
        }

        public EmpresaViewModel ObterEmpresa(int IdEmpresa)
        {
            using (HttpClient client = new HttpClient())
            {
                ServiceBase(client);
                HttpResponseMessage response = client.GetAsync("empresa/ObterEmpresa/" + IdEmpresa).Result;
                string stringData = response.Content.ReadAsStringAsync().Result;
                EmpresaDTO data = JsonConvert.DeserializeObject<EmpresaDTO>(stringData);

                var empresaModel = _mapper.Map<EmpresaViewModel>(data);
                return empresaModel;
            }
        }

        public bool VeficaDuplicidadeCnpjCpf(string cnpjcpf)
        {
            using (HttpClient client = new HttpClient())
            {
                ServiceBase(client);
                HttpResponseMessage response = client.GetAsync("empresa/GetVerificaDuplicidadeCPF/" + cnpjcpf).Result;
                string stringData = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<bool>(stringData);

                return data;
            }
        }

        public EmpresaViewModel CadastrarEmpresa(EmpresaViewModel empresa)
        {
            using (HttpClient client = new HttpClient())
            {
                var empresasDTO = _mapper.Map<EmpresaDTO>(empresa);
                ServiceBase(client);
                string parametroJSON = JsonConvert.SerializeObject(empresasDTO);
                StringContent conteudo = new StringContent(parametroJSON, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync("empresa/InserirEmpresa", conteudo).Result;
                string stringData = response.Content.ReadAsStringAsync().Result;
                EmpresaDTO data = JsonConvert.DeserializeObject<EmpresaDTO>(stringData);
                empresa = _mapper.Map<EmpresaViewModel>(data);
            }
            return empresa;
        }

        public void AlterarEmpresa(EmpresaViewModel empresa)
        {
            using (HttpClient client = new HttpClient())
            {
                var empresasDTO = _mapper.Map<EmpresaDTO>(empresa);
                ServiceBase(client);
                string parametroJSON = JsonConvert.SerializeObject(empresasDTO);
                StringContent conteudo = new StringContent(parametroJSON, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PutAsync("empresa/AlterarEmpresa", conteudo).Result;
                string stringData = response.Content.ReadAsStringAsync().Result;
                EmpresaDTO data = JsonConvert.DeserializeObject<EmpresaDTO>(stringData);
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
