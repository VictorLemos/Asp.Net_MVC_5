using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity.Banco.MVC.Web.Models
{
    public class Cargo
    {
        public int CargoId { get; set; }
        public string Descricao { get; set; }

        //mapping - Relacionamento Many-to-many
        public virtual ICollection<Funcionario> Funcionarios { get; set; }
    }
}