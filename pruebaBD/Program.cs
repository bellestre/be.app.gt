using Data.nf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebaBD
{
    class Program
    {
        static void Main(string[] args)
        {
            MangerAutor Mautores = new MangerAutor();
            List<Autor> auotores = Mautores.GetAutors();
            Console.WriteLine(auotores);
            Console.ReadLine();
        }
    }
}
