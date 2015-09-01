using Code.Cadastro.UI.Web.DataAccess;
using Code.Cadastro.UI.Web.Models;
using Code.Cadastro.UI.Web.UnitsOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Code.Cadastro.UI.Web.Controllers
{
    public class CargoController : Controller
    {
        FaculdadeContext context = new FaculdadeContext();

        UnitOfWorks unit = new UnitOfWorks();

        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Cargo cargo)
        {
            //Salva no banco
            unit.CargoRepository.Cadastrar(cargo);
            unit.Salvar();
            //Mensagem de sucesso!
            TempData["msg"] = "Cargo Cadastrado!";
            //Limpa o Form
            ModelState.Clear();
            return View();
        }

        [HttpGet]
        public ActionResult Listar()
        {
            //carrego a lista
            var lista = unit.CargoRepository.BuscarTodos();
            //Passo para a view
            return View(lista);
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            //Buscar no banco o cargo
            var cargo = unit.CargoRepository.BuscarPorCodigo(id);
            //Passa o cargo para a view
            return View(cargo);
        }

        [HttpPost]
        public ActionResult Editar(Cargo cargo)
        {
            //Atualiza no Banco de dados
            unit.CargoRepository.Atualizar(cargo);
            unit.Salvar();

            //Adiciona mensagem de sucesso
            TempData["msg"] = "Cargo atualizado!";

            //Redireciona para o método Listar
            return RedirectToAction("Listar");
        }

        [HttpGet]
        public ActionResult Excluir(int id)
        {
            //Busca o cargo no banco
            var cargo = unit.CargoRepository.BuscarPorCodigo(id);
            //Manda o cargo para a página("VIEW")
            return View(cargo);
        }

        [HttpPost]
        public ActionResult ExcluirConfirm(int cargoId)
        {
            //Remove o cargo do banco
            unit.CargoRepository.Apagar(cargoId);
            unit.Salvar();
            //Mensagem de sucesso
            TempData["msg"] = "Cargo Excluido!";
            //Redirecionar para a página de Listagem
            return RedirectToAction("Listar");
        }
	}
}