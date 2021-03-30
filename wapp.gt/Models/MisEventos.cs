using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wapp.gt.Models
{
    public class MisEventos
    {
        public string Nombre;
        public string F_inicio;
        public DateTime F_fin;

        public MisEventos(string nombre, string f_ini, DateTime f_fin)
        {
            this.Nombre = nombre;
            this.F_inicio = f_ini;
            this.F_fin = f_fin;
        }
    }
}
