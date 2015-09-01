using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Code.Cadastro.UI.Web.Models
{
    public class Professor
    {
        public Int32 ProfessorId { get; set; }

        [Required(ErrorMessage = "Digite um nome para seu amigo.")]
        [MaxLength(70, ErrorMessage = "O nome está muito longo")]
        [MinLength(5, ErrorMessage = "O nome está muito curto")]
        public String Nome { get; set; }

        [Display(Name = "Data de Admissao")]
        public String DataAdmissao { get; set; }
        public string Formacao { get; set; }

        [Display(Name = "Data de Nascimento")]
        public String DataNascimento { get; set; }
        
        [Display(Name = "Hora Aula")]
        public Decimal HoraAula { get; set; }

        public String Telefone { get; set; }

        [Required(ErrorMessage = "Digite um e-mail.")]
        [MaxLength(70, ErrorMessage = "O E-Mail está muito longo")]
        [MinLength(5, ErrorMessage = "O E-Mail está muito curto")]
        [EmailAddress(ErrorMessage = "Digite um E-Mail válido")]
        [Display(Name = "E-Mail")]
        public String Email { get; set; }
       
        //Relacionamento One-To-Many
        public Cargo Cargo { get; set; }
        //FK
        public Int32 CargoId { get; set; }
    }
}