using Code.Cadastro.UI.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Cadastro.UI.Web.Repositories
{
    public interface ICargoRepository
    {
        void Cadastrar(Cargo cargo);
        void Atualizar(Cargo cargo);
        void Apagar(int codigo);
        Cargo BuscarPorCodigo(int codigo);
        ICollection<Cargo> BuscarTodos();
    }
}
