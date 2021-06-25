using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logica.libreria
{

   public class subirImagen
    {
        //en esta clase se usaran metodos los cuales serviran para subir una imagen a un picturebox

        private OpenFileDialog fd = new OpenFileDialog();

        public void cargarImagen(PictureBox pictureBox)
        {
            //Aqui establecemos la propiedad WaitOnLoad = true lo que hara que
            //que la imagen se cargue de forma sincrona
            pictureBox.WaitOnLoad = true;
            fd.Filter = "Imagenes|*.jpg;*.gif;*.png;*.bmp";
            fd.ShowDialog();
            if (fd.FileName != string.Empty)
            {
                pictureBox.ImageLocation = fd.FileName;
            }
            
        }
        public byte[] imagenAByte(Image img)
        {
            var converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }

      public Image byteToArray(byte[] arrayImagen)
        {
            MemoryStream ms = new MemoryStream(arrayImagen);
            Image returnImage = Image.FromStream(ms);
            return returnImage;

        }
    }
}
