using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models.gra;

namespace Data.gra
{
   public class RamaRepository
    {
        private readonly DBgt _context;
        public RamaRepository(DBgt context)
        {
            _context = context;
            
        }

        public void add(RamaInvestigacion rama) {
            _context.RamaInvestigacion.Add(rama);
            _context.SaveChanges();
        }

        public List<RamaInvestigacion> ListaRamas() {
            List<RamaInvestigacion> Ramas= new List<RamaInvestigacion>();
            Ramas = _context.RamaInvestigacion.ToList();

            return (Ramas);
        }
    }
}
