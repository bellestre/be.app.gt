using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.nf
{
    public class MangerAutor
    {
        public List<Autor> GetAutors()
        {
            using (GlobalDB dbContext = new GlobalDB())
            {
                return dbContext.Autores().ToList();
            }
        }
    }
}
