using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Entity.Banco.MVC.Web.Models
{
    public class Lavagem
    {
        public int LavagemId { get; set; }

        [Display(Name = "Data da Lavagem")]
        public DateTime Data { get; set; }

        public decimal Valor { get; set; }

        [MaxLength(10)]
        [Required]
        public string Tipo { get; set; }

        //mapping - Many-to-many
        public virtual ICollection<Funcionario> Funcionarios { get; set; }

        //One to Many , bi-direcional
        public Carro Carro { get; set; }
        //Mapeamento da chave estrangeira
        public int CarroId { get; set; }

    }
}