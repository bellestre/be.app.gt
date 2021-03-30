using System;
using System.Collections.Generic;
using System.Text;
using Data.gra;
using Models.gra;

namespace Logic.gra
{
    public class LogicEstadoDeEtapa
    {
        EstadoDeEtapaRepository estado;

        public void AddEstado(DBgt db, EstadoDeEtapa est) {
            estado = new EstadoDeEtapaRepository(db);
            estado.Add(est);
        
        }

        public List<EstadoDeEtapa> ListaEstado(DBgt db)
        {
            estado = new EstadoDeEtapaRepository(db);
            List<EstadoDeEtapa> est= estado.ListaEstados();
            return est;
        }
    }
}
