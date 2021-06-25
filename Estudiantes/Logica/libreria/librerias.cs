using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.libreria
{
   public class librerias:Conexion

    {
        //en esta clase voy a importar objetos de las demas clases para tenerlas aqui
        //ya que no se puede tener herencia multiple
        public subirImagen objSubirImagen = new subirImagen();
        public EventosTextBox objEventosTextbox = new EventosTextBox();


    }
}
