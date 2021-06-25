using LinqToDB;
using LinqToDB.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Conexion:DataConnection
    {
        //a continuacion creamos el metodo constructor
        public Conexion() : base("bd") { }

        public ITable<estudiante> _estudiante{ get { return GetTable<estudiante>(); } }
    }
}
