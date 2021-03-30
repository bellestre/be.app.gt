using System;
using System.Collections.Generic;
using System.Linq;
using Models.gra;

namespace Data.gra
{
    public class AutorRepository
    {
        private readonly DBgt _context;
        public AutorRepository(DBgt context)
        {
            _context = context;

        }

        public void add(Autor autor)
        {
            _context.Autor.Add(autor);
            _context.SaveChanges();
        }

        public List<Autor> ListaAutores()
        {
            List<Autor> Aut = new List<Autor>();
            Aut = _context.Autor.ToList();

            return (Aut);
        }
    }
}
