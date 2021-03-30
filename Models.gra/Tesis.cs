using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.gra
{
   public class Tesis
   {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Codigo { get; set; }
        [Required]
        public string Tema { get; set; }
        [Required]
        public int Rama { get; set; }
        [Required]
        public int Autor { get; set; }
        [Required]
        public int Asesor { get; set; }
        [Required]
        public int Etapa { get; set; }
        [Required]
        public DateTime F_inicio { get; set; }
        [Required]
        public DateTime F_fin { get; set; }
        [Required]
        public string Latitud { get; set; }
        [Required]
        public string Longitud { get; set; }

    }
}
