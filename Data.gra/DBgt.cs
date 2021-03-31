using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Models.gra;
using Wapp.gt.Models;

namespace Data.gra
{
    public class DBgt : DbContext
    {
        public DBgt(DbContextOptions<DBgt> options) : base(options) { }
        public DbSet<RamaInvestigacion> RamaInvestigacion { get; set; }
        public DbSet<Tesis> Tesis { get; set; }
        public DbSet<Autor> Autor { get; set; }
        public DbSet<EtapaDeTesis> EtapaDeTesis { get; set; }
        public DbSet<EstadoDeEtapa> EstadoDeEtapa { get; set; }
        public DbSet<Asesor> Asesor { get; set; }

        public DbSet<Inmueble> Inmueble { get;set }

    }
}
