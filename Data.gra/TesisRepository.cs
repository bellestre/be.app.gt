using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Models.gra;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Data.gra
{
    public class TesisRepository
    {
        private readonly DBgt _context;
        public TesisRepository(DBgt context)
        {
            _context = context;
        }

        public void add(Tesis t)
        {
            _context.Tesis.Add(t);
            _context.SaveChanges();
        }

        public List<Tesis> ListaTesis()
        {
            List<Tesis> misTesis = new List<Tesis>();
            misTesis = _context.Tesis.ToList();

            return (misTesis);
        }

        /// <summary>
        /// este metodo obtiene una lista de objetos de tipo Tesis
        /// </summary>
        public List<Tesis> ListaTesis2()
        {
            List<Tesis> misTesis = new List<Tesis>();
            misTesis = _context.Tesis.Select(x => new Tesis {
                Id = x.Id,
                Codigo = x.Codigo,
                Tema = x.Tema,
                Rama = x.Rama,
                Autor = x.Autor,
                Asesor = x.Asesor,
                Etapa = x.Etapa
            }).ToList();

            return (misTesis);
        }

        public List<TesisView> MostrarTesis()
        {
            var ListadoDeTesis = from t in _context.Tesis
                        join r in _context.RamaInvestigacion on t.Rama equals r.Id
                        join aut in _context.Autor on t.Autor equals aut.Id
                        join ase in _context.Asesor on t.Asesor equals ase.Id
                        join eta in _context.EtapaDeTesis on t.Etapa equals eta.Id
                        join est in _context.EstadoDeEtapa on eta.Estado equals est.Id
                        select new
                        {
                            Id = t.Id,
                            Codigo = t.Codigo,
                            Tema = t.Tema,
                            RamaNombre = r.Nombre,
                            AutorNombre = aut.Nombres,
                            AutorApePaterno = aut.Paterno,
                            AutorApeMaterno = aut.Materno,
                            AsesorNombre = ase.Nombres,
                            AsesorApePaterno = ase.Paterno,
                            AsesorApeMaterno = ase.Materno,
                            EtapaNombre = eta.Nombre,   
                            EstadoNombre = est.Nombre,
                            Latitud = t.Latitud,
                            Longitud = t.Longitud
                        };
            _context.SaveChanges();
            List<TesisView> listTesis = new List<TesisView>();
            foreach (var item in ListadoDeTesis)
            {
                TesisView tesisView = new TesisView()
                {
                    Id = Convert.ToString(item.Id),
                    Codigo = item.Codigo,
                    Tema = item.Tema,
                    Rama = item.RamaNombre,
                    Autor = item.AutorNombre + " " + item.AutorApePaterno + " " + item.AutorApeMaterno,
                    Asesor = item.AsesorNombre + " " + item.AsesorApePaterno + " " + item.AsesorApeMaterno,
                    Etapa = item.EtapaNombre,
                    Estado = item.EstadoNombre,
                    Latitud = item.Latitud,
                    Longitud = item.Longitud

                };
                //TesisView misTesis = new TesisView(
                //    Convert.ToString(item.id),
                //    item.codigo, 
                //    item.tema, 
                //    item.RamaNombre, 
                //    item.AutorNombre +" "+ item.AutorApePaterno +" "+ item.AutorApeMaterno, 
                //    item.AsesorNombre +" "+ item.AsesorApePaterno +" "+ item.AsesorApeMaterno, 
                //    item.EtapaNombre
                //);
                listTesis.Add(tesisView);
            }
            return listTesis;
        }

        /// <summary>
        /// este metodo obtiene un solo objeto de tipo Tesis por su Id
        /// </summary>
        public Task<Tesis> BuscarPorID(int? id)
        {
            return Task.Run(() =>
            {
                if (id != null){
                    try{
                        var tesis = _context.Tesis
                        .Include(r => r.Rama)
                        .Include(aut => aut.Autor)
                        .Include(ase => ase.Asesor)
                        .Include(eta => eta.Etapa)
                        .Where(v => v.Id == id).First();
                        if (tesis != null){
                            return tesis;
                        }
                    }
                    catch (Exception exp){
                        Console.WriteLine($"Error: {exp}");
                    }
                }
                return null;
            });
        }

        /// <summary>
        /// este metodo actualiza los paramemtros de una tabla tesis de la BD 
        /// </summary>
        public bool Update(int id, string codigo, string tema)
        {
            try
            {
                var modificar = _context.Tesis.FirstOrDefault(t => t.Id == id);
                modificar.Codigo = codigo;
                modificar.Tema = tema;               

                _context.Tesis.Update(modificar);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<TesisView> ObtenerPorId(int? id)
        {
            var ListadoDeTesis = from t in _context.Tesis
                                 join r in _context.RamaInvestigacion on t.Rama equals r.Id
                                 join aut in _context.Autor on t.Autor equals aut.Id
                                 join ase in _context.Asesor on t.Asesor equals ase.Id
                                 join eta in _context.EtapaDeTesis on t.Etapa equals eta.Id
                                 join est in _context.EstadoDeEtapa on eta.Estado equals est.Id
                                 where t.Id.Equals(id)
                                 select new
                                 {
                                     Id = t.Id,
                                     Codigo = t.Codigo,
                                     Tema = t.Tema,
                                     RamaNombre = r.Nombre,
                                     AutorNombre = aut.Nombres,
                                     AutorApePaterno = aut.Paterno,
                                     AutorApeMaterno = aut.Materno,
                                     AsesorNombre = ase.Nombres,
                                     AsesorApePaterno = ase.Paterno,
                                     AsesorApeMaterno = ase.Materno,
                                     EtapaNombre = eta.Nombre,
                                     EstadoNombre = est.Nombre
                                 };
            _context.SaveChanges();
            List<TesisView> listTesis = new List<TesisView>();
            foreach (var item in ListadoDeTesis)
            {
                TesisView tesisView = new TesisView()
                {
                    Id = Convert.ToString(item.Id),
                    Codigo = item.Codigo,
                    Tema = item.Tema,
                    Rama = item.RamaNombre,
                    Autor = item.AutorNombre + " " + item.AutorApePaterno + " " + item.AutorApeMaterno,
                    Asesor = item.AsesorNombre + " " + item.AsesorApePaterno + " " + item.AsesorApeMaterno,
                    Etapa = item.EtapaNombre,
                    Estado = item.EstadoNombre

                };
                //TesisView misTesis = new TesisView(
                //    Convert.ToString(item.id),
                //    item.codigo, 
                //    item.tema, 
                //    item.RamaNombre, 
                //    item.AutorNombre +" "+ item.AutorApePaterno +" "+ item.AutorApeMaterno, 
                //    item.AsesorNombre +" "+ item.AsesorApePaterno +" "+ item.AsesorApeMaterno, 
                //    item.EtapaNombre
                //);
                listTesis.Add(tesisView);
            }
            return listTesis;
        }
    }
}
