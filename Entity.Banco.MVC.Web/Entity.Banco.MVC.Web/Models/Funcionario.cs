using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Entity.Banco.MVC.Web.Models
{
    public class Funcionario
    {
        public int FuncionarioId { get; set; }

        public string Nome { get; set; }

        public decimal Salario { get; set; }

        [Display(Name = "Data de Nascimento")]
        public DateTime DataNascimento { get; set; }

        public bool Ativo { get; set; }

        //mapping - One to Many bi-direcional
        public Cargo Cargo { get; set; }
        //Mapeamento da chave estrangeira
        public int CargoId { get; set; }

        //Relacionamento Many-to-many
        public ICollection<Lavagem> Lavagens { get; set; }
    }
}