using Entity.Banco.MVC.Web.DataAccess;
using Entity.Banco.MVC.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Entity.Banco.MVC.Web.Controllers
{
    public class CargoController : Controller
    {
        LavaRapidoContext context = new LavaRapidoContext();

        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Cargo cargo)
        {
            //Salva no BD
            context.Cargos.Add(cargo);
            context.SaveChanges();
            //Mensagem de sucesso
            TempData["msg"] = "Cargo cadastrado!";
            return View();
        }

        public ActionResult Listar()
        {
            var lista = context.Cargos.ToList();
            return View(lista);
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            var cargo = context.Cargos.Find(id);
            return View(cargo);
        }

        [HttpPost]
        public ActionResult Editar(Cargo cargo)
        {
            context.Entry(cargo).State = EntityState.Modified;
            context.SaveChanges();
            TempData["msg"] = "Cargo Alterado com sucesso!";
            return RedirectToAction("Listar");
        }

        [HttpGet]
        public ActionResult Excluir(int id)
        {
            var cargo = context.Cargos.Find(id);
            return View(cargo);
        }

        [HttpPost]
        public ActionResult ExcluirConfirm(int cargoId)
        {
            var cargo = context.Cargos.Find(cargoId);

            context.Cargos.Remove(cargo);
            context.SaveChanges();
            TempData["msg"] = "Cargo Excluído!";
            return RedirectToAction("Listar");
        }
    }
}