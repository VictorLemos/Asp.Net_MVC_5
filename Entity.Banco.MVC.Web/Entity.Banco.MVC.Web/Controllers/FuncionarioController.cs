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
    public class FuncionarioController : Controller
    {
        
        //Cria o context
        LavaRapidoContext context = new LavaRapidoContext();

        private void CarregaCargo()
        {
            //Recupera os cargos cadastrados
            var lista = context.Cargos.ToList();
            //Passa a lista para a página
            ViewBag.cargos = new SelectList(lista,
                "CargoId", "Descricao");
        }

        [HttpGet]//Abre a página de cadastro
        public ActionResult Cadastrar()
        {
            CarregaCargo();
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Funcionario funcionario)
        {
            //Salva no banco de dados
            context.Funcionarios.Add(funcionario);
            context.SaveChanges();

            //Mostrar uma mensagem de sucesso
            TempData["msg"] = "Funcionário Cadastrado!";

            CarregaCargo();

            return View();
        }

        public ActionResult Listar()
        {
            //Recuperar os funcionários no banco de dados
            //Include -> carrega o relacionamento faz um join...
            var lista = context.Funcionarios.Include("Cargo").ToList();
            return View(lista);
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            //Busca o funcionário no banco de dados
            var funcionario = context.Funcionarios.Find(id);
            //Tras o Cargo
            CarregaCargo();
            //Manda o funcionário para a view
            return View(funcionario);
        }

        [HttpPost]
        public ActionResult Editar(Funcionario func)
        {
            //Update do funcionário no banco de dados
            context.Entry(func).State = EntityState.Modified;
            context.SaveChanges();
            //Adicionar uma mensagem
            TempData["msg"] = "Funcionário Alterado com sucesso!";
            //Redireciona para a listagem
            return RedirectToAction("Listar");
        }

        [HttpGet]
        public ActionResult Excluir(int id)
        {
            //Buscar o funcionario no banco
            var func = context.Funcionarios.Find(id);
            //Passar o funcionário para a view
            return View(func);
        }

        [HttpPost]
        public ActionResult ExcluirConfirm(int funcionarioId)
        {
            //Buscar o funcionario
            var func = context.Funcionarios.Find(funcionarioId);
            //Excluir o funcionario
            context.Funcionarios.Remove(func);
            context.SaveChanges();
            //Mensagem de sucesso
            TempData["msg"] = "Funcionário Excluído!";
            //Redirecionar para o método de listar
            return RedirectToAction("Listar");
        }

    }
}