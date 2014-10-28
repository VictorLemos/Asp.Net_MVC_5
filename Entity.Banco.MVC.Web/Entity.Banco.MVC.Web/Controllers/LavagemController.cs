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
    public class LavagemController : Controller
    {

        LavaRapidoContext context = new LavaRapidoContext();
        private void CarregaCarro()
        {
            //Recupera os cargos cadastrados
            var lista = context.Carros.ToList();
            //Passa a lista para a página
            ViewBag.carros = new SelectList(lista,
                "CarroId", "Modelo");
        }

        [HttpGet]
        public ActionResult Cadastrar()
        {
            CarregaCarro();
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Lavagem lavagem)
        {
            context.Lavagens.Add(lavagem);
            context.SaveChanges();
            TempData["msg"] = "Lavagem Cadastrada!";
            CarregaCarro();
            return View();
        }

        public ActionResult Listar()
        {
            //Recuperar os funcionários no banco de dados
            //Include -> carrega o relacionamento faz um join...
            var lista = context.Lavagens.Include("Carro").ToList();
            return View(lista);
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            var lav = context.Lavagens.Find(id);
            CarregaCarro();
            return View(lav);
        }

        [HttpPost]
        public ActionResult Editar(Lavagem lav)
        {
            context.Entry(lav).State = EntityState.Modified;
            context.SaveChanges();
            TempData["msg"] = "Lavagem Alterada com sucesso!";
            return RedirectToAction("Listar");
        }

        [HttpGet]
        public ActionResult Excluir(int id)
        {
            var lav = context.Lavagens.Find(id);
            return View(lav);
        }

        [HttpPost]
        public ActionResult ExcluirConfirm(int lavagemId)
        {
            var lav = context.Lavagens.Find(lavagemId);
            context.Lavagens.Remove(lav);
            context.SaveChanges();
            TempData["msg"] = "Lavagem Excluída!";
            return RedirectToAction("Listar");
        }
    }
}