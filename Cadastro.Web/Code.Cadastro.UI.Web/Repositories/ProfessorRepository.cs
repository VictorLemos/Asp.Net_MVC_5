using Code.Cadastro.UI.Web.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Code.Cadastro.UI.Web.Repositories
{
    public class ProfessorRepository : IProfessorRepository
    {

        private FaculdadeContext context;

        //contrutor
        public ProfessorRepository(FaculdadeContext context)
        {
            this.context = context;
        }

        public void Cadastrar(Models.Professor prof)
        {
            context.Professores.Add(prof);
        }

        public void Atualizar(Models.Professor prof)
        {
            context.Entry(prof).State = EntityState.Modified;
        }

        public void Apagar(int codigo)
        {
            var prof = context.Professores.Find(codigo);
            context.Professores.Remove(prof);
        }

        public Models.Professor BuscarPorCodigo(int codigo)
        {
            return context.Professores.Find(codigo);
        }

        public ICollection<Models.Professor> BuscarTodos()
        {
            return context.Professores.Include("Cargo").ToList();
        }
    }
}