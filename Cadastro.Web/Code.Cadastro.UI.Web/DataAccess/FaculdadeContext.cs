using Code.Cadastro.UI.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Code.Cadastro.UI.Web.DataAccess
{
    public class FaculdadeContext : DbContext
    {
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
    }
}