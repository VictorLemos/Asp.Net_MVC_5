using Code.Cadastro.UI.Web.DataAccess;
using Code.Cadastro.UI.Web.Models;
using Code.Cadastro.UI.Web.UnitsOfWorks;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Code.Cadastro.UI.Web.Controllers
{
    public class ProfessorController : Controller
    {
        FaculdadeContext context = new FaculdadeContext();

        UnitOfWorks unit = new UnitOfWorks();

        private void CarregaCargo()
        {
            var lista = context.Cargos.ToList();
            ViewBag.cargos = new SelectList(lista, "CargoId", "Titulo");
        }

        private void CarregaFormacao()
        {
            List<string> formacao = new List<string>();
            formacao.Add("Graduação");
            formacao.Add("Especialista");
            formacao.Add("Mestrado");
            formacao.Add("Doutorado");

            //Manda a lista para a view
            ViewBag.lista = new SelectList(formacao);
        }

        // GET: Professor
        [HttpGet] //Método para abrir a página de cadastro
        public ActionResult Cadastrar()
        {
            CarregaFormacao();
            CarregaCargo();
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Professor professor)
        {
            
                //Salva no banco
                unit.ProfessorRepository.Cadastrar(professor);
                unit.Salvar();

                //Mensagem de sucesso!
                TempData["msg"] = "Professor cadastrado!";
                
               //recarrego os campos novamente da view para inserir outro professor
                CarregaFormacao();
                CarregaCargo();

                ModelState.Clear(); //Limpa o Form
                return View();
        }

        [HttpGet]
        public ActionResult Listar()
        {
            //include -> carrega o relacionamento para busca
            var lista = unit.ProfessorRepository.BuscarTodos();
            //Passa a lista para a view
            return View(lista);
        }

        [HttpGet] //abre o formulário preenchido
        public ActionResult Editar(int id)
        {
            //Carrega as informações do select
            CarregaFormacao();
            CarregaCargo();
            //Buscar no banco o professor
            var prof = unit.ProfessorRepository.BuscarPorCodigo(id);
            //Passa o professor para a view
            return View(prof);
        }

        [HttpPost]//Atualiza as informações no banco de dados
        public ActionResult Editar(Professor prof)
        {

            //Atualiza no banco de dados
            unit.ProfessorRepository.Atualizar(prof);
            unit.Salvar();
            //Adiciona mensagem de sucesso
            TempData["msg"] = "Professor atualizado!";

           
            //Redireciona para o método Listar
            return RedirectToAction("Listar");
        }

        [HttpGet]
        public ActionResult Excluir(int id)
        {
            //Busca o prof no banco
            var prof = unit.ProfessorRepository.BuscarPorCodigo(id);
            //Manda  o professor para a página
            return View(prof);
        }

        [HttpPost]
        public ActionResult ExcluirConfirm(int professorId)
        {
            //Remove o professor do banco de dados
            unit.ProfessorRepository.Apagar(professorId);
            unit.Salvar();
            //Mensagem de sucesso
            TempData["msg"] = "Professor(a) Excluido!";
            //Redirecionar para a página de Listagem
            return RedirectToAction("Listar");
        }

    }
}