using Code.Cadastro.UI.Web.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Code.Cadastro.UI.Web.Repositories
{
    public class CargoRepository : ICargoRepository 
    {

        private FaculdadeContext context;

        //Contrutor
        public CargoRepository(FaculdadeContext context)
        {
            this.context = context;
        }

        public void Cadastrar(Models.Cargo cargo)
        {
            context.Cargos.Add(cargo);
        }

        public void Atualizar(Models.Cargo cargo)
        {
            context.Entry(cargo).State = EntityState.Modified;
        }

        public void Apagar(int codigo)
        {
            var cargo = context.Cargos.Find(codigo);
            context.Cargos.Remove(cargo);
        }

        public Models.Cargo BuscarPorCodigo(int codigo)
        {
            return context.Cargos.Find(codigo);
        }

        public ICollection<Models.Cargo> BuscarTodos()
        {
            return context.Cargos.ToList();
        }
    }
}