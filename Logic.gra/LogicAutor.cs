using System;
using System.Collections.Generic;
using System.Text;
using Models.gra;
using Data.gra;

namespace Logic.gra
{
    public class LogicAutor
    {
        private AutorRepository autor;
        public void AddAutor(DBgt db, Autor aut)
        {
            autor = new AutorRepository(db);
            
            bool f = RulesForAdd(aut);
            if (f == true) {
                if (aut.GradoAcademico == "Pregrado")
                {
                    aut.Estado = "Inhabilitado";
                    autor.add(aut);
                }
                else if (aut.GradoAcademico == "Bachiller")
                {
                    aut.Estado = "Habilitado";
                    autor.add(aut);
                }

            }
            
        }

        public List<Autor> ListaAutores(DBgt db)
        {
            autor = new AutorRepository(db);
            List<Autor> Aut = autor.ListaAutores();
            return Aut;
        }

        public bool RulesForAdd(Autor autor) {
            var valido = false;
            if (autor.CreditosAprobados >= 160 && autor.CreditosAprobados <= 280)
            {
                if (autor.GradoAcademico == "Pregrado" || autor.GradoAcademico == "Bachiller")
                {
                    valido = true;
                }
                                
            }
            return valido;

        }
    }
}
