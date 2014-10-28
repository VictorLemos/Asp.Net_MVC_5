using Entity.Banco.MVC.Web.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Entity.Banco.MVC.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //Configuração da estratégia de criação de tabela
            Database.SetInitializer(
                new DropCreateDatabaseIfModelChanges<LavaRapidoContext>());

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
