using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.nf
{
    public class AutorModel: EntityTypeConfiguration<Autor>
    {
        public AutorModel()
        {
            this.ToTable("Autor");
        }
    }
}
