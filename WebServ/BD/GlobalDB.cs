using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebServ.BD
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