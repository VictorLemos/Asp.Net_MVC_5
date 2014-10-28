using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity.Banco.MVC.Web.Models
{
    public class Carro
    {
        public int CarroId { get; set; }

        public string Modelo { get; set; }

        //mapping - Relacionamento One to Many

        public virtual ICollection<Lavagem> Lavagens { get; set; }
    }
}