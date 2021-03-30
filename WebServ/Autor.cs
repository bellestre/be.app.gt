using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServ
{
    public class Autor
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombres { get; set; }
        public string Paterno { get; set; }
        public string Materno { get; set; }
        public string Correo { get; set; }
        public int CreditosAprobados { get; set; }
        public string GradoAcademico { get; set; }
        public string Estado { get; set; }
    }
}