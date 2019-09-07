using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Data.Reositories;
using Data.Repositories.Base;
using Data.Repositories;
using JBD.MonitorCozinha.Application.Interfaces;
using JBD.MonitorCozinha.Application.Repositories;
using JBD.MonitorCozinha.Domain.Interfaces.Repository;
using JBD.MonitorCozinha.Domain.Interfaces.Repository.Base;
using JBD.MonitorCozinha.Domain.Interfaces.Service;
using JBD.MonitorCozinha.Domain.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using JBD.MonitorCozinha.WebAdmin.Models;

namespace JBD.MonitorCozinha.WebAdmin
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddAutoMapper(typeof(Startup));

            //services.Configure<CookiePolicyOptions>(options =>
            //{
            //    // This lambda determines whether user consent for non-essential cookies is needed for a given request.
            //    options.CheckConsentNeeded = context => true;
            //    options.MinimumSameSitePolicy = SameSiteMode.None;
            //});
            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSingleton(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));

            services.AddSingleton<IEmpresaApp, EmpresaRepositoryApp>();
            services.AddSingleton<INumeroPedidoApp, NumeroPedidoRepositoryApp>();
            services.AddSingleton<IPessoaApp, PessoaRepositoryApp>();
            services.AddSingleton<ITelefoneApp, TelefoneRepositoryApp>();
            services.AddSingleton<IUnidadeApp, UnidadeRepositoryApp>();
            services.AddSingleton<IUsuarioApp, UsuarioRepositoryApp>();

            services.AddSingleton<IEmpresaService, EmpresaService>();
            services.AddSingleton<INumeroPedidoService, NumeroPedidoService>();
            services.AddSingleton<IPessoaService, PessoaService>();
            services.AddSingleton<ITelefoneService, TelefoneService>();
            services.AddSingleton<IUnidadeService, UnidadeService>();
            services.AddSingleton<IUsuarioService, UsuarioService>();

            services.AddSingleton<IEmpresaRepository, EmpresaRepository>();
            services.AddSingleton<INumeroPedidoRepository, NumeroPedidoRepository>();
            services.AddSingleton<IPessoaRepository, PessoaRepository>();
            services.AddSingleton<ITelefoneRepository, TelefoneRepository>();
            services.AddSingleton<IUnidadeRepository, UnidadeRepository>();
            services.AddSingleton<IUsuarioRepository, UsuarioRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (!Controle.ValidarUsuarioLogado())
            {
                app.UseMvc(routes =>
                {
                    routes.MapRoute(
                        name: "default",
                        template: "{controller=Login}/{action=Index}/{id?}");
                });
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
