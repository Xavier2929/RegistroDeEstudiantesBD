using Data;
using LinqToDB;
using Logica.libreria;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logica
{
    public class LEstudiantes:librerias
    {
        //private librerias objLibrerias;

        private List<TextBox> listTextBox;
        private List<Label> listLabel;
        private PictureBox imagen;
        private Bitmap _imageBitmap;
        private DataGridView dtg;
        private NumericUpDown numericPaginas;
        private paginador<estudiante> _paginador;
        private String _accion = "insert ";
        

        //en esta clase tenemos metodos los cuales corresponderan a las acciones pedidas en el front end
        public LEstudiantes(List<TextBox> listTxtBX, List<Label> listLabel,object[] objetos)
        {
            this.listTextBox =  listTxtBX;
            this.listLabel = listLabel;
            this.imagen =(PictureBox)objetos[0];
            //objLibrerias = new librerias();
            _imageBitmap = (Bitmap)objetos[1];
            this.dtg =(DataGridView) objetos[2];
            this.numericPaginas =(NumericUpDown) objetos[3];
            Restablecer();
        }

        public void Registra()
        {
            //obtenemos el primer valor de esta posicion la cual es el txtID
            if (listTextBox[0].Text.Equals(""))
            {
                listLabel[0].Text = "El ID esta vacio";
                listLabel[0].ForeColor = Color.Red;
                listLabel[0].Focus();
            }


            if (listTextBox[1].Text.Equals(""))
            {
                listLabel[1].Text = "El Nombre esta vacio";
                listLabel[1].ForeColor = Color.Red;
                listLabel[1].Focus();
            }

            if (listTextBox[2].Text.Equals(""))
            {
                listLabel[2].Text = "El Apellido esta vacio";
                listLabel[2].ForeColor = Color.Red;
                listLabel[2].Focus();
            }

            if (listTextBox[3].Text.Equals(""))
            {
                listLabel[3].Text = "El Email esta vacio";
                listLabel[3].ForeColor = Color.Red;
                listLabel[3].Focus();
            }
            else
            {
                if (objEventosTextbox.comprobarFormatoEmail(listTextBox[3].Text))
                {
                    //aqui simplemente buscamos a un usuario , u siendo un objeto o usuario de la tabla donde tenga el mismo email
                    var user = _estudiante.Where(u => u.email.Equals(listTextBox[3].Text) ).ToList();
                    if (user.Count.Equals(0))
                    {
                        guardar();
                    }
                    else
                    {  
                        //actualizamos el email
                        if (user[0].ID.Equals(_idEstudiante))
                        {
                            guardar();
                        }
                        else
                        {
                            listLabel[3].Text = "Email ya registrado";
                            listLabel[3].ForeColor = Color.Red;
                        }

                      
                    }
                }
                else listLabel[3].Text = "Tu email no es valido";
            }

        }

        public void guardar()
        {
            BeginTransactionAsync();
            try
            {
                var imagenArray = objSubirImagen.imagenAByte(imagen.Image);
                
                //con la variable string _accion es de uso con su valor de update de default
                switch (_accion)
                {
                    case "insert":
                        _estudiante.Value(e => e.nid, listTextBox[0].Text)
                          .Value(e => e.nombre, listTextBox[1].Text)
                          .Value(e => e.apellido, listTextBox[2].Text)
                          .Value(e => e.email, listTextBox[3].Text)
                          .Value(e => e.foto, imagenArray)
                          .Insert();
                     
                        break;

                    case "update":
                        _estudiante.Where(u => u.ID.Equals(_idEstudiante))
                            .Set(e => e.nombre, listTextBox[1].Text)
                          .Set(e => e.apellido, listTextBox[2].Text)
                          .Set(e => e.email, listTextBox[3].Text)
                          .Set(e => e.foto, imagenArray)
                          .Update();
                        break;

                    default:
                        break;
                }
                CommitTransaction();
                Restablecer();


            }
            catch (Exception)
            {
               
                RollbackTransaction();
            }
        }

        private List<estudiante> listaEstudiante;

        public void Paginador(string metodo)
        {
            switch (metodo)
            {
                case "Primero":
                    _num_pagina = _paginador.primero();
                    break;
                case "Anterior":
                    _num_pagina = _paginador.anterior(); 
                    break;
                case "Siguiente":
                    _num_pagina = _paginador.siguiente();
                    break;
                case "Ultimo":
                    _num_pagina = _paginador.ultimo();
                    break;
            }
            buscarEstudiante("");
        }
        //esto es para eliminar algun registro
        public void Eliminar()
        {
            if (_idEstudiante.Equals(0))
            {
                MessageBox.Show("Seleccione algun estudidante");

            }
            else
            {
                if (MessageBox.Show("Esta seguro que quieres eliminar al estudiante?","Eliminar estudiante",MessageBoxButtons.YesNo)==DialogResult.Yes)
                {
                    _estudiante.Where(c => c.ID.Equals(_idEstudiante)).Delete();
                    Restablecer();
                }
            }
        }

        public void Restablecer()
        {
            //restablezco todos los controles del form
            _accion = "insert";
            _num_pagina = 1;
            _idEstudiante = 0;

            imagen.Image = _imageBitmap;
            listLabel[0].Text = "ID";
            listLabel[1].Text = "Nombre";
            listLabel[2].Text = "Apellido";
            listLabel[3].Text = "Email";

            listLabel[0].ForeColor = Color.LightSlateGray;
            listLabel[1].ForeColor = Color.LightSlateGray;
            listLabel[2].ForeColor = Color.LightSlateGray;
            listLabel[3].ForeColor = Color.LightSlateGray;

            listTextBox[0].Text = "";
            listTextBox[1].Text = "";
            listTextBox[2].Text = "";
            listTextBox[3].Text = "";
            listaEstudiante = _estudiante.ToList();
            if (0<listaEstudiante.Count)
            {
                _paginador = new paginador<estudiante>(listaEstudiante,listLabel[4],_reg_por_pagina);
            }
            buscarEstudiante("");
        }

        private int _idEstudiante = 0;

        public void GetEstudiante()
        {
            _accion = "update";
            _idEstudiante = Convert.ToInt32(dtg.CurrentRow.Cells[0].Value);
            listTextBox[0].Text = Convert.ToString(dtg.CurrentRow.Cells[1].Value);
            listTextBox[1].Text = Convert.ToString(dtg.CurrentRow.Cells[2].Value);
            listTextBox[2].Text = Convert.ToString(dtg.CurrentRow.Cells[3].Value);
            listTextBox[3].Text = Convert.ToString(dtg.CurrentRow.Cells[4].Value);
            //ahora obtendremos la imagen del estudiante
            try
            {
                byte[] arrayImagen = (byte[])dtg.CurrentRow.Cells[5].Value;
                imagen.Image = objSubirImagen.byteToArray(arrayImagen);
            }
            catch (Exception)
            {

                //si por alguna razon no se puede recuperar la imagen del estudiante (o si no tenia) restauraremos la de default
                imagen.Image = _imageBitmap;
            }

        }

        int _num_pagina = 1;
        int _reg_por_pagina = 2; //estos seran los registros mostrados por pagina en el datagridview

        public void buscarEstudiante(string campo)
        {
            List<estudiante> query = new List<estudiante>();
          
            int inicio = (_num_pagina - 1) * _reg_por_pagina;
            if (campo.Equals(""))
            {
                //para buscar algun estudiante que coincida
                query = _estudiante.ToList();
            }
            else
            {
                //esto es cuando si hay coincidencias
                //buscamod coincidencias, filtrando estudiantes con el campo que mandaron y convertimos el objeto a lista
                query = _estudiante.Where(c => c.nid.StartsWith(campo) || c.nombre.StartsWith(campo) || c.apellido.StartsWith(campo)).ToList();
            }
            if (0<query.Count)
            {
                dtg.DataSource = query.Select(c => new { 
                
                c.ID,
                c.nid,
                c.nombre,
                c.apellido,
                c.email,
                c.foto
                
                
                
                }).Skip(inicio).Take(_reg_por_pagina).ToList();
                //el skip sirve para omitir cierto numero de registros , la cantidad de registros sera _reg_por_pagina que sera cantidad que va a retornar al datagridview 
                //y asi crearemos un paginador

                //ahora ocultare a la columna ID
                dtg.Columns[0].Visible = false;
                dtg.Columns[5].Visible = false;

                dtg.Columns[1].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                dtg.Columns[2].DefaultCellStyle.BackColor = Color.WhiteSmoke;


            }
            else
            {
                dtg.DataSource = query.Select(c => new
                  {
                      c.nid,
                      c.nombre,
                      c.apellido,
                      c.email,

                  });
            }
        }

        public void Registro_Paginas()
        {
            _num_pagina = 1;
            _reg_por_pagina =(int)numericPaginas.Value;
            var list = _estudiante.ToList();
            if (0<list.Count)
            {
                _paginador = new paginador<estudiante>(listaEstudiante, listLabel[4], _reg_por_pagina);

            }
            buscarEstudiante("");
        }
    }
}
