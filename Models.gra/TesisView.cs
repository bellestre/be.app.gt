using System;
using System.Collections.Generic;
using System.Text;

namespace Models.gra
{
    public class TesisView
    {
        public string Id { get; set; }
        public string Codigo { get; set; }
        public string Tema { get; set; }
        public string Rama { get; set; }    
        public string Autor { get; set; }
        public string Asesor { get; set; }
        public string Etapa { get; set; }
        public string Estado { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public TesisView(string id, string codigo, string tema, string rama, string etapa, string autor, string asesor, string estado, string latitud, string longitud)
        {
            Id = id;
            Codigo = codigo;
            Tema = tema;
            Rama = rama;
            Autor = autor;
            Asesor = asesor;
            Etapa = etapa;
            Estado = estado;
            Latitud = latitud;
            Longitud = longitud;
        }

        public TesisView()
        {
        }
    }
}

