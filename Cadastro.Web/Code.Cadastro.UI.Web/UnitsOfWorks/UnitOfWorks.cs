using Code.Cadastro.UI.Web.DataAccess;
using Code.Cadastro.UI.Web.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Code.Cadastro.UI.Web.UnitsOfWorks
{
    public class UnitOfWorks : IDisposable //Para liberar recurso... conexão
    {

        private FaculdadeContext context = new FaculdadeContext();

        private IProfessorRepository _professorRepository;

        private ICargoRepository _cargoRepository;

        public ICargoRepository CargoRepository
        {
            get
            {
                if (_cargoRepository == null)
                {
                    _cargoRepository =
                        new CargoRepository(context);
                }
                return _cargoRepository;
            }
        }
          

        public IProfessorRepository ProfessorRepository
        {
            get
            {
                if (_professorRepository == null)
                {
                    _professorRepository =
                        new ProfessorRepository(context);
                }
                return _professorRepository;
            }
        }


        public void Salvar()
        {
            context.SaveChanges();
        }

        //Para liberar a conexão...
        private bool disposed = false;
        public void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

      
    }
}