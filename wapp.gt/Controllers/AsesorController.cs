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
    public class AsesorController : Controller
    {
        private readonly DBgt _con;
        private LogicAsesor _logAsesor;
        private LogicRama _logRama;

        public AsesorController(DBgt con)
        {
            _con = con;
        }

        [HttpPost]
        public IActionResult Create(string Codigo, string Nombres, string Paterno, string Materno,
            string Correo)
        {
            _logAsesor = new LogicAsesor();
            Asesor asesor = new Asesor
            {
                Codigo = Codigo,
                Nombres = Nombres,
                Paterno = Paterno,
                Materno = Materno,
                Correo = Correo,                
            };
            _logAsesor.AddAsesor(_con, asesor);
            return RedirectToAction("Index", "Asesor");

        }

        [HttpGet]
        public IActionResult Create()
        {
            _logRama = new LogicRama();
            List<RamaInvestigacion> Ramas = _logRama.ListaRamas(_con);

            ViewBag.Ramas = Ramas;
            return View(Ramas);
            
        }

        public IActionResult Index()
        {
            _logAsesor = new LogicAsesor();
            List<Asesor> Ases = _logAsesor.ListaAsesores(_con);

            return View(Ases);
        }

        public IActionResult Modal()
        {

            return PartialView();
        }
    }
}
