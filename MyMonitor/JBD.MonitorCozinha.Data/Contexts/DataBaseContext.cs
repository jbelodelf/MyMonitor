using JBD.MonitorCozinha.Domain.Entitys;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Contexts
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(StringConectionConfig());
            }
        }

        public DbSet<EmpresaEntity> Empresa { get; set; }
        public DbSet<NumeroPedidoEntity> NumeroPedido { get; set; }
        public DbSet<PessoaEntity> Pessoa { get; set; }
        public DbSet<TelefoneEntity> Telefone { get; set; }
        public DbSet<UnidadeEntity> Unidade { get; set; }
        public DbSet<UsuarioEntity> Usuario { get; set; }
        public DbSet<ControleAcessoEntity> ControleAcesso { get; set; }
        public DbSet<StatusEntity> Status { get; set; }
        public DbSet<StatusPedidoEntity> StatusPedido { get; set; }
        public DbSet<TipoContatoEntity> TipoContato { get; set; }
        public DbSet<TipoUsuarioEntity> TipoUsuario { get; set; }
        public DbSet<LembreteSenhaEntity> LembreteSenha { get; set; }


        private string StringConectionConfig()
        {
            //Produção
            //return "Server=mssql.mymonitor.com.br;Database=mymonitor;User Id=mymonitor;Password=sqlserver2016;MultipleActiveResultSets=true;Encrypt=YES;TrustServerCertificate=YES";

            //Local
            return "Server=DESKTOP-IANDO4A;Database=DB_MONITOR_COZINHA;User Id=sa;Password=sqlserver2016;MultipleActiveResultSets=true;Encrypt=YES;TrustServerCertificate=YES";

            //Michel
            //return "Server=DESKTOP-24V97RI;Database=DB_MONITOR_COZINHA;User Id=sa;Password=mbelo;MultipleActiveResultSets=true;Encrypt=YES;TrustServerCertificate=YES";
        }
    }
}
