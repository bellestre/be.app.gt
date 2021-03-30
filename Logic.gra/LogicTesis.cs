using System;
using System.Collections.Generic;
using System.Text;
using Models.gra;
using Data.gra;
using System.Threading.Tasks;

namespace Logic.gra
{
    public class LogicTesis
    {
        TesisRepository tesis;
        public void AddTesis(DBgt db, Tesis tes)
        {
            tesis = new TesisRepository(db);
            tes.Etapa = 1;
            tesis.add(tes);
        }

        public List<Tesis> ListaParaViewBag(DBgt db)
        {
            tesis = new TesisRepository(db);
            List<Tesis> Tes = tesis.ListaTesis2();
            return Tes;
        }

        public List<TesisView> MiListaTesis(DBgt db)
        {
            tesis = new TesisRepository(db);
            List<TesisView> MiLista= tesis.MostrarTesis();
            return MiLista;
        }

        public List<TesisView> MiTesis(DBgt db, int? id) {
            tesis = new TesisRepository(db);
            List<TesisView> miTesis = tesis.ObtenerPorId(id);

            return miTesis;       
        }

        public Tesis BuscarPorId(DBgt db, int? id) {         
            tesis = new TesisRepository(db);
            Tesis miTesis = tesis.BuscarPorID(id).Result;
            return miTesis;
        }

        public bool UpdateTes(DBgt db, int id, string codigo, string tema) {
            tesis = new TesisRepository(db);
            var valor = tesis.Update(Convert.ToInt32(id), codigo, tema);

            return valor;
        }
    }

}
