using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity.Banco.MVC.Web.Models
{
    public class Pagamento
    {
        public int PagamentoId { get; set; }

        public decimal Valor { get; set; }

        //mapping - Relacionamento one to one
        public Lavagem Lavagem { get; set; }

        //Mapeamento da chave estrangeira 
        public int LavagemId { get; set; }
    }
}