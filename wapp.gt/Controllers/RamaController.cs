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
    public class RamaController : Controller
    {
        private readonly DBgt _con;
        private LogicRama _logRama;
        public RamaController(DBgt con)
        {
            _con = con;
        }

        [HttpPost]
        public IActionResult Create(String Nombre)
        {
            _logRama = new LogicRama();
            RamaInvestigacion rama = new RamaInvestigacion
            {
                Nombre = Nombre,
            };
            _logRama.AddRama(_con, rama);
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Index()
        {
            _logRama = new LogicRama();
            List<RamaInvestigacion> Ram = _logRama.ListaRamas(_con);
            
            return View(Ram);
        }

        public IActionResult Coll() {
            return View();
        
        }
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    RamaInvestigacion result = await TesisRepository.FindByID(id);
        //    if (result != null)
        //    {
        //        P_Tesis tesisDeleted = await TesisRepository.Remove(result);
        //        if (tesisDeleted != null)
        //        {
        //            return RedirectToAction(nameof(Index), new { Message = "Tesis Eliminada " });
        //        }
        //    }
        //    return RedirectToAction(nameof(Index));
        //}


    }
}
