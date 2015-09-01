using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Code.Cadastro.UI.Web.Models
{
    public class Cargo
    {
        public Int32 CargoId { get; set; }
        public String Titulo { get; set; }
        public Decimal Salario { get; set; }

        //Relacionamento Muitos para Um
        public virtual ICollection<Professor> Professores { get; set; }
    }
}