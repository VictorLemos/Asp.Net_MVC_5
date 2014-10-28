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
    public class CarroController : Controller
    {
        LavaRapidoContext context = new LavaRapidoContext();

        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Carro carro)
        {
            context.Carros.Add(carro);
            context.SaveChanges();
            TempData["msg"] = "Carro cadastrado!";
            return View();
        }

        public ActionResult Listar()
        {
            var lista = context.Carros.ToList();
            return View(lista);
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            var carro = context.Carros.Find(id);
            return View(carro);
        }

        [HttpPost]
        public ActionResult Editar(Carro carro)
        {
            context.Entry(carro).State = EntityState.Modified;
            context.SaveChanges();
            TempData["msg"] = "Carro Alterado com sucesso!";
            return RedirectToAction("Listar");
            
        }

        [HttpGet]
        public ActionResult Excluir(int id)
        {
            var carro = context.Carros.Find(id);
            return View(carro);
        }

        [HttpPost]
        public ActionResult ExcluirConfirm(int carroId)
        {
            var carro = context.Carros.Find(carroId);
            context.Carros.Remove(carro);
            context.SaveChanges();
            TempData["msg"] = "Carro Excluído!";
            return RedirectToAction("Listar");
        }
    }
}