using System;
using System.Collections.Generic;
using System.Text;
using Models.gra;
using System.Linq;

namespace Data.gra
{
    public class EstadoDeEtapaRepository
    {
        private readonly DBgt _context;
        public EstadoDeEtapaRepository(DBgt context)
        {
            _context = context;
        }

        public void Add(EstadoDeEtapa Estado)
        {
            _context.EstadoDeEtapa.Add(Estado);
            _context.SaveChanges();
        }

        public List<EstadoDeEtapa> ListaEstados()
        {
            List<EstadoDeEtapa> est = new List<EstadoDeEtapa>();
            est = _context.EstadoDeEtapa.ToList();

            return (est);
        }
    }
}
