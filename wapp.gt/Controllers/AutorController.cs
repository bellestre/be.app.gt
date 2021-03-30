using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.gra;
using Logic.gra;
using Models.gra;

namespace Wapp.gt.Controllers
{
    public class AutorController: Controller
    {
        private readonly DBgt _con;
        private LogicAutor _logAutor;
        public AutorController(DBgt con)
        {
            _con = con;
        }

        [HttpPost]
        public IActionResult Create(string Codigo, string Nombres, string Paterno, string Materno, 
            string Correo, int CreditosAprobados, string GradoAcademico)
        {
            _logAutor = new LogicAutor();
            Autor autor = new Autor
            {
                Codigo = Codigo,
                Nombres = Nombres,
                Paterno = Paterno,
                Materno = Materno,
                Correo = Correo,
                CreditosAprobados = CreditosAprobados,
                GradoAcademico=GradoAcademico,
                
            };
            _logAutor.AddAutor(_con, autor);
            return RedirectToAction("Index","Autor");

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Index()
        {
            _logAutor = new LogicAutor();
            List<Autor> Aut = _logAutor.ListaAutores(_con);

            return View(Aut);
        }

        public IActionResult Mapita() {
            return View();
        }

        public IActionResult ModalMap() {
            return View();
        }
    }
}
