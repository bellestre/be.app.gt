using System;
using System.Collections.Generic;
using System.Text;
using Models.gra;
using Data.gra;

namespace Logic.gra
{
    public class LogicAsesor
    {
        private AsesorRepository asesor;
        public void AddAsesor(DBgt db, Asesor ase)
        {
            asesor = new AsesorRepository(db);
            asesor.add(ase);
        }

        public List<Asesor> ListaAsesores(DBgt db)
        {
            asesor = new AsesorRepository(db);
            List<Asesor> ase = asesor.ListaAsesores();
            return ase;
        }
    }
}
