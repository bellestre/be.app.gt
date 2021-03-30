using System;
using System.Collections.Generic;
using System.Text;
using Models.gra;
using System.Linq;

namespace Data.gra
{
    public class EtapaDeTesisRepository
    {
        private readonly DBgt _context;
        public EtapaDeTesisRepository(DBgt context)
        {
            _context = context;
        }

        public void Add(EtapaDeTesis Etapa)
        {
            _context.EtapaDeTesis.Add(Etapa);
            _context.SaveChanges();
        }

        public List<EtapaDeTesis> ListaEtapas()
        {
            List<EtapaDeTesis> etapas = new List<EtapaDeTesis>();
            etapas = _context.EtapaDeTesis.ToList();

            return (etapas);
        }
    }
}
