using LinqToDB.Mapping;
using NHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class estudiante
    {

        [PrimaryKey,Identity]
        public int ID { get; set; }
        public string nid { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string email { get; set; }

        public byte[] foto { get; set; }


    }
}
