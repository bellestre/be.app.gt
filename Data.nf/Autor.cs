using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.nf
{
    public class Autor
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public string Codigo { get; set; }
        [Required]
        public string Nombres { get; set; }
        [Required]
        public string Paterno { get; set; }
        [Required]
        public string Materno { get; set; }
        [Required]
        public string Correo { get; set; }
        [Required]
        public int CreditosAprobados { get; set; }
        [Required]
        public string GradoAcademico { get; set; }
        [Required]
        public string Estado { get; set; }
    }
}
