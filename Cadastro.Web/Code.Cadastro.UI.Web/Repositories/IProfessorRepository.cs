using Code.Cadastro.UI.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Cadastro.UI.Web.Repositories
{
    public interface IProfessorRepository
    {
        void Cadastrar(Professor prof);
        void Atualizar(Professor prof);
        void Apagar(int codigo);
        Professor BuscarPorCodigo(int codigo);
        ICollection<Professor> BuscarTodos();
    }
}
