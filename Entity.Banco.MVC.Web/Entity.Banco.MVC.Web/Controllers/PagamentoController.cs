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
    public class PagamentoController : Controller
    {
        LavaRapidoContext context = new LavaRapidoContext();

        private void CarregaLavagem()
        {
            var lista = context.Lavagens.ToList();
            ViewBag.lavagens = new SelectList(lista, "LavagemId", "Tipo");
        }

        [HttpGet]
        public ActionResult Cadastrar()
        {
            CarregaLavagem();
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Pagamento pagamento)
        {
            context.Pagamentos.Add(pagamento);
            context.SaveChanges();
            TempData["msg"] = "Pagamento Cadastrado!";
            CarregaLavagem();
            return View();
        }

        public ActionResult Listar()
        {
            var lista = context.Pagamentos.Include("Lavagem").ToList();
            return View(lista);
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            var pagamento = context.Pagamentos.Find(id);
            CarregaLavagem();
            return View(pagamento);
        }

        [HttpPost]
        public ActionResult Editar(Pagamento pagamento)
        {
            context.Entry(pagamento).State = EntityState.Modified;
            context.SaveChanges();
            TempData["msg"] = "Pagamento Alterado com sucesso!";
            return RedirectToAction("Listar");
        }

        [HttpGet]
        public ActionResult Excluir(int id)
        {
            var pag = context.Pagamentos.Find(id);
            return View(pag);
        }

        [HttpPost]
        public ActionResult ExcluirConfirm(int pagamentoId)
        {
            var pag = context.Pagamentos.Find(pagamentoId);
            context.Pagamentos.Remove(pag);
            context.SaveChanges();
            TempData["msg"] = "Pagamento Excluído!";
            return RedirectToAction("Listar");
        }


    }
}