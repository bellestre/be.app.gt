using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServ.BD;

namespace WebServ
{
    public class ManagerAutor
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