using Entity.Banco.MVC.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Entity.Banco.MVC.Web.DataAccess
{
    public class LavaRapidoContext : DbContext
    {
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Lavagem> Lavagens { get; set; }
        public DbSet<Carro> Carros { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
    }
}