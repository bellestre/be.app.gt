using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;

namespace WebServ.BD
{
    public class AutorModel : EntityTypeConfiguration<Autor>
    {
        public AutorModel()
        {
            this.ToTable("Autor");
        }
    }
}