using System;
using System.Collections.Generic;
using System.Text;
using Data.gra;
using Models.gra;

namespace Logic.gra
{
    public class LogicRama
    { 
        private RamaRepository rama;
        public void AddRama(DBgt db, RamaInvestigacion ra ) {
            rama = new RamaRepository(db);
            rama.add(ra);
        }

        public List<RamaInvestigacion> ListaRamas(DBgt db) {
            rama = new RamaRepository(db);
            List<RamaInvestigacion> Ram = rama.ListaRamas();
            return Ram;
        }

    }
}
