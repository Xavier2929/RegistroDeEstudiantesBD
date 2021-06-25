using Logica;
using Logica.libreria;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estudiantes
{


    public partial class FrmPrincipal : Form
    {

        //private librerias lib;
        private LEstudiantes estudiante;
        public FrmPrincipal()
        {
            InitializeComponent();
            //lib = new librerias();

            var listTextBox = new List<TextBox>();
            listTextBox.Add(txtID);
            listTextBox.Add(txtNombre);
            listTextBox.Add(txtApellido);
            listTextBox.Add(txtEmail);
            

            var listLabel = new List<Label>();
            listLabel.Add(lblID);
            listLabel.Add(lblNombre);
            listLabel.Add(lblApellido);
            listLabel.Add(lblEmail);
            listLabel.Add(lblPaginas);
        

            Object[] objeto = {pbImagen,Properties.Resources.fotoDefault,dataGridView1, numericPaginas };
            estudiante = new LEstudiantes(listTextBox, listLabel,objeto);
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void pbImagen_Click(object sender, EventArgs e)
        {
            estudiante.objSubirImagen.cargarImagen(pbImagen);
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            estudiante.buscarEstudiante(txtBuscar.Text);
        }

        private void groupBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            estudiante.objEventosTextbox.textKeyPress(e);
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            if (txtID.Text.Equals(""))
            {
                lblID.ForeColor = Color.LightSlateGray;
            }
            else
            {
                lblID.ForeColor = Color.Green;
            }
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            if (txtNombre.Text.Equals(""))
            {
                lblNombre.ForeColor = Color.LightSlateGray;
            }
            else
            {
                lblNombre.ForeColor = Color.Green;
            }
        }

        private void txtApellido_TextChanged(object sender, EventArgs e)
        {
            if (txtApellido.Text.Equals(""))
            {
                lblApellido.ForeColor = Color.LightSlateGray;
            }
            else
            {
                lblApellido.ForeColor = Color.Green;
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            if (txtEmail.Text.Equals(""))
            {
                lblEmail.ForeColor = Color.LightSlateGray;
            }
            else
            {
                lblEmail.ForeColor = Color.Green;
            }
        }

        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            estudiante.objEventosTextbox.numberKeyPress(e);
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            estudiante.objEventosTextbox.textKeyPress(e);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            estudiante.Registra();
        }

        private void txtNombre_TabStopChanged(object sender, EventArgs e)
        {
           
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            estudiante.Paginador("Primero");
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            estudiante.Paginador("Anterior");
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            estudiante.Paginador("Siguiente");
        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            estudiante.Paginador("Ultimo");
        }
     
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void numericPaginas_ValueChanged(object sender, EventArgs e)
        {
            estudiante.Registro_Paginas();
        }

        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {
            if (dataGridView1.Rows.Count != 0)
            {
                estudiante.GetEstudiante();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count !=0)
            {
                estudiante.GetEstudiante();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            estudiante.Restablecer();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            estudiante.Eliminar();
           
        }
    }
}
