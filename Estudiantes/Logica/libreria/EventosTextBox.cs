using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Logica
{
   public class EventosTextBox
    {

        public void textKeyPress(System.Windows.Forms.KeyPressEventArgs e)
        {
            //condicion para permiter que solo se ingrese texto
            if (char.IsLetter(e.KeyChar)) { e.Handled = false; }
           // condicion que no de un salto de linea con el enter
            else if (e.KeyChar == Convert.ToChar(Keys.Enter)) { e.Handled = true; }

            //esto es para controles como backspace
            else if (char.IsControl(e.KeyChar)) { e.Handled = false; }

            //condicion que permite poder ver si es la tecla espacio
            else if (char.IsSeparator(e.KeyChar)) { e.Handled = false; }

            else { e.Handled = true; }
        }


        public void numberKeyPress(System.Windows.Forms.KeyPressEventArgs e)
        {
            //condicion para permiter que solo se ingrese texto
            if (char.IsDigit(e.KeyChar)) { e.Handled = false; }
            // condicion que no de un salto de linea con el enter
            else if (e.KeyChar == Convert.ToChar(Keys.Enter)) { e.Handled = true; }

            //esto es para controles como backspace
            else if (char.IsControl(e.KeyChar)) { e.Handled = false; }

            //condicion que permite poder ver si es la tecla espacio
            else if (char.IsSeparator(e.KeyChar)) { e.Handled = false; }

            else { e.Handled = true; }
        }

        public bool comprobarFormatoEmail(string email)
        {
            return new EmailAddressAttribute().IsValid(email);
        }

    }
}
