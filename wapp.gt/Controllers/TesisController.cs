using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models.gra;
using Data.gra;
using Logic.gra;
using Wapp.gt.Models;

namespace Wapp.gt.Controllers
{
    public class TesisController : Controller
    {
        private readonly DBgt _con;
        private LogicTesis _logTesis;
        private LogicRama _logRama;
        private LogicAutor _logAutor;
        private LogicAsesor _logAsesor;
        private LogicEtapaDeTesis _logEtapa;
        public static string credentialsPath = "credentials.json";
        GoogleCalendar MyCalendar = new GoogleCalendar(credentialsPath);
        Tesis miTes;
        public TesisController(DBgt con)
        {
            _con = con;
        }

        [HttpPost]
        public IActionResult Crear(string Codigo, string Tema, int Rama, int Autor, int Asesor, string F_inicio, string F_fin,string Email)
        {
            _logTesis = new LogicTesis();
            
            DateTime FInicio = Convert.ToDateTime(F_inicio);
            DateTime FFinal = Convert.ToDateTime(F_fin);
            MyCalendar.CrearEvento(FInicio,FFinal,Tema,Email);
            Tesis tesis = new Tesis
            {
                Codigo = Codigo,
                Tema = Tema,
                Rama = Rama,
                Autor = Autor,
                Asesor = Asesor,
                F_inicio = FInicio,
                F_fin = FFinal,

            };
            _logTesis.AddTesis(_con, tesis);
            return RedirectToAction("Index", "Tesis");

        }

        [HttpPost]
        public IActionResult Create(string Codigo, string Tema, int Rama, int Autor, int Asesor, string F_inicio, string F_fin, string Email, string Latitud, string Longitud)
        {
            _logTesis = new LogicTesis();

            DateTime FInicio = Convert.ToDateTime(F_inicio);
            DateTime FFinal = Convert.ToDateTime(F_fin);
            MyCalendar.CrearEvento(FInicio, FFinal, Tema, Email);
            Tesis tesis = new Tesis
            {
                Codigo = Codigo,
                Tema = Tema,
                Rama = Rama,
                Autor = Autor,
                Asesor = Asesor,
                F_inicio = FInicio,
                F_fin = FFinal,
                Latitud = Latitud,
                Longitud = Longitud,

            };
            _logTesis.AddTesis(_con, tesis);
            return RedirectToAction("Index", "Tesis");

        }
        [HttpGet] 
        public ActionResult Create()
        {
            _logRama = new LogicRama();
            _logAutor = new LogicAutor();
            _logEtapa = new LogicEtapaDeTesis();
            _logAsesor = new LogicAsesor();

            List<RamaInvestigacion> Ramas = _logRama.ListaRamas(_con);
            ViewBag.Ramas = Ramas;
            List<Autor> Tesistas = _logAutor.ListaAutores(_con);
            ViewBag.Autores = Tesistas;
            List<Asesor> Asesores = _logAsesor.ListaAsesores(_con);
            ViewBag.Asesores = Asesores;
            List<EtapaDeTesis> Etapas = _logEtapa.ListaEtapas(_con);
            ViewBag.Etapas = Etapas;

            return View();
        }

        [HttpGet]
        public IActionResult Crear() {
            _logRama = new LogicRama();
            _logAutor = new LogicAutor();
            _logEtapa = new LogicEtapaDeTesis();
            _logAsesor = new LogicAsesor();

            List<RamaInvestigacion> Ramas = _logRama.ListaRamas(_con);
            ViewBag.Ramas = Ramas;
            List<Autor> Tesistas = _logAutor.ListaAutores(_con);
            ViewBag.Autores = Tesistas;
            List<Asesor> Asesores = _logAsesor.ListaAsesores(_con);
            ViewBag.Asesores = Asesores;
            List<EtapaDeTesis> Etapas = _logEtapa.ListaEtapas(_con);
            ViewBag.Etapas = Etapas;
           
            return View();
        }

        public IActionResult Index(){
           _logTesis = new LogicTesis();
            List<TesisView> tesis = _logTesis.MiListaTesis(_con);

            ViewBag.Tesis = tesis;
            return View(tesis);
        }

        public IActionResult Evaluate(int? id) {
            //_logTesis = new LogicTesis();
            //Tesis miTesis = _logTesis.BuscarPorId(_con, id);

            //ViewBag.MiTesis = miTesis;
            //return PartialView("Evaluate", miTesis);
            _logTesis = new LogicTesis();
            List<TesisView> miTesis = _logTesis.MiTesis(_con, id);

            ViewBag.UnicaTesis = miTesis;
            return PartialView("Evaluate", miTesis);

        }

        public ActionResult Edit(int id) {
            _logTesis = new LogicTesis();
            Tesis laTesis = new Tesis();
            if (id > 0) {
                laTesis = _logTesis.BuscarPorId(_con, id);
            }
            return PartialView("Complemento", laTesis);
        
        }

        public IActionResult Update(int? id)
        {
            if (id != null)
            {
                _logTesis = new LogicTesis();
                _logAsesor = new LogicAsesor();
                List<TesisView> miTesis = _logTesis.MiTesis(_con, id);
               
                ViewBag.UnaTesis = miTesis;
                List<Asesor> Asesores = _logAsesor.ListaAsesores(_con);
                ViewBag.Asesor = Asesores;
                
                return View(miTesis);
            }

            return RedirectToAction(nameof(Index));
        }

        
        public IActionResult Update2(int? id)
        {
            if (id != null)
            {
                _logTesis = new LogicTesis();
                Tesis miTesis = _logTesis.BuscarPorId(_con, id);

                return View(miTesis);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Update(string Id, string codigo, string tema)
        {
            _logTesis = new LogicTesis();
            var valor = _logTesis.UpdateTes(_con, Convert.ToInt32(Id), codigo, tema);

            return RedirectToAction("Index");
        }
        //public IActionResult MiMapa() {
        //    return View();
        //}

        public ActionResult MiMapa()
        {
            _logTesis = new LogicTesis();
            List<TesisView> tesis = _logTesis.MiListaTesis(_con);
            string marcador = "[";

            var lista = tesis;
            foreach (var item in lista)
            {
                marcador += "{";
                marcador += string.Format("'title': '{0}',", item.Autor);
                marcador += string.Format("'lat': '{0}',", Convert.ToDouble(item.Latitud));
                marcador += string.Format("'lng': '{0}',", Convert.ToDouble(item.Longitud));
                marcador += "},";
            }
            marcador += "];";
            ViewBag.mar = marcador;
            return View();
        }

    }
}
