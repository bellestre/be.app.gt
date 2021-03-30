using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.nf
{
    public class GlobalDB : DbContext
    {

        public GlobalDB() : base("dbGT")
        {
        
        
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AutorModel());
        }
        public DbSet<Autor> Autores()
        {
            return this.Set<Autor>();
        }
    }
}
