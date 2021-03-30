using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.gra
{
    public class EstadoDeEtapa
    {
        [Key]
        public int Id { get; set; }
        [Required]      
        public string Nombre { get; set; }
        
    }
}
