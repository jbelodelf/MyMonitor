using AutoMapper;
using Data.Reositories;
using Data.Repositories;
using Data.Repositories.Base;
using JBD.MonitorCozinha.Application.Interfaces;
using JBD.MonitorCozinha.Application.Repositories;
using JBD.MonitorCozinha.Domain.Interfaces.Repository;
using JBD.MonitorCozinha.Domain.Interfaces.Repository.Base;
using JBD.MonitorCozinha.Domain.Interfaces.Service;
using JBD.MonitorCozinha.Domain.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace JBD.MonitorCozinha.WebApiAdmin
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
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddAutoMapper(typeof(Startup));

            services.AddSingleton(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));

            services.AddSingleton<IEmpresaApp, EmpresaRepositoryApp>();
            services.AddSingleton<INumeroPedidoApp, NumeroPedidoRepositoryApp>();
            services.AddSingleton<IUnidadeApp, UnidadeRepositoryApp>();
            services.AddSingleton<IUsuarioApp, UsuarioRepositoryApp>();
            services.AddSingleton<IPessoaApp, PessoaRepositoryApp>();

            services.AddSingleton<IEmpresaService, EmpresaService>();
            services.AddSingleton<INumeroPedidoService, NumeroPedidoService>();
            services.AddSingleton<IUnidadeService, UnidadeService>();
            services.AddSingleton<IUsuarioService, UsuarioService>();
            services.AddSingleton<IPessoaService, PessoaService>();

            services.AddSingleton<IEmpresaRepository, EmpresaRepository>();
            services.AddSingleton<INumeroPedidoRepository, NumeroPedidoRepository>();
            services.AddSingleton<IUnidadeRepository, UnidadeRepository>();
            services.AddSingleton<IUsuarioRepository, UsuarioRepository>();
            services.AddSingleton<IPessoaRepository, PessoaRepository>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(option => option
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());

            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}
