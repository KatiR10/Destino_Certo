using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DestinoCerto.Models;


namespace DestinoCerto.Controllers
{
    public class PacotesTuristicosController : Controller
    {
        public IActionResult ListaPacotes()
        {
            if (HttpContext.Session.GetInt32("IdUsuario") == null)
                return RedirectToAction("Login", "Usuario");

            PacotesTuristicosRepository ptr = new PacotesTuristicosRepository();
            List<PacotesTuristicos> ListaPacotes = ptr.listar();
            return View(ListaPacotes);
        }
        public IActionResult CadastroPacotes()
        {
            if (HttpContext.Session.GetInt32("IdUsuario") == null)
                return RedirectToAction("Login", "Usuario");

            return View();
        }

        [HttpPost]
        public IActionResult CadastroPacotes(PacotesTuristicos pacotes)
        {

            if (HttpContext.Session.GetInt32("IdUsuario") == null)
                return RedirectToAction("Login", "Usuario");

            PacotesTuristicosRepository ptr = new PacotesTuristicosRepository();
            ptr.inserir(pacotes);
            ViewBag.Mensagem = "Cadastro do pacote turístico concluído!";

            return View();

        }

        public IActionResult RemoverPacotes(int Id)
        {
            if (HttpContext.Session.GetInt32("IdUsuario") == null)
                return RedirectToAction("Login", "Usuario");

            PacotesTuristicosRepository ptr = new PacotesTuristicosRepository();
            PacotesTuristicos PacotesBuscado = ptr.buscarPorId(Id);

            ptr.remover(PacotesBuscado);

            return RedirectToAction("ListaPacotes");

        }


        public IActionResult EditarPacotes(int Id)
        {
            if (HttpContext.Session.GetInt32("IdUsuario") == null)
                return RedirectToAction("Login", "Usuario");

            PacotesTuristicosRepository ptr = new PacotesTuristicosRepository();
            PacotesTuristicos PacotesBuscado = ptr.buscarPorId(Id);


            return View(PacotesBuscado);

        }


        [HttpPost]
        public IActionResult EditarPacotes(PacotesTuristicos pacotes)
        {
            if (HttpContext.Session.GetInt32("IdUsuario") == null)
                return RedirectToAction("Login", "Usuario");


            PacotesTuristicosRepository ptr = new PacotesTuristicosRepository();
            ptr.editar(pacotes);

            return RedirectToAction("ListaPacotes");

        }
    }
}