using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Models.gra;

namespace Data.gra
{
    public class AsesorRepository
    {
        private readonly DBgt _context;
        public AsesorRepository(DBgt context)
        {
            _context = context;
        }

        public void add(Asesor asesor)
        {
            _context.Asesor.Add(asesor);
            _context.SaveChanges();
        }

        public List<Asesor> ListaAsesores()
        {
            List<Asesor> Asesores = new List<Asesor>();
            Asesores = _context.Asesor.ToList();

            return (Asesores);
        }
    }
}
