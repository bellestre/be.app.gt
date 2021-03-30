using System;
using System.Collections.Generic;
using System.Text;
using Models.gra;
using Data.gra;

namespace Logic.gra
{
    public class LogicEtapaDeTesis
    {
        EtapaDeTesisRepository etapa;
        public void AddEtapa(DBgt db, EtapaDeTesis eta)
        {
            etapa = new EtapaDeTesisRepository(db);
            etapa.Add(eta);
        }

        public List<EtapaDeTesis> ListaEtapas(DBgt db)
        {
            etapa = new EtapaDeTesisRepository(db);
            List<EtapaDeTesis> etap = etapa.ListaEtapas();
            return etap;
        }

    }
}
