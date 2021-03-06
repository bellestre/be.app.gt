using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.gra
{
    public class Asesor
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

    }
}
