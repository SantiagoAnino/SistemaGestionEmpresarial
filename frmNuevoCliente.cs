using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ANINO_HNOS
{
    public partial class frmNuevoCliente : Form
    {
        public frmNuevoCliente()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Clientes cli = new Clientes();
            cli.Nombre = txtNombre.Text;
            cli.Domicilio = txtDomicilio.Text;
            cli.Telefono = txtTelefono.Text;
            cli.Ciudad = txtCiudad.Text;
            cli.Provincia = txtProvincia.Text;
            cli.Email = txtEmail.Text;
            cli.CUIT = txtCUIT.Text;
            cli.Agregar();
            MessageBox.Show("Datos Grabados Correctamtene!");
            txtNombre.Text = "";
            txtCiudad.Text = "";
            txtTelefono.Text = "";
            txtCUIT.Text = "";
            txtDomicilio.Text = "";
            txtProvincia.Text = "";
            txtEmail.Text = "";
            txtNombre.Select();
        }
        private void ControlCajasDeTexto()
        {
            if (txtNombre.Text != "" & txtCiudad.Text != "" & txtTelefono.Text != "")
            {
                btnAgregar.Enabled = true;
            }
            else
            { 
                btnAgregar.Enabled = false;
            }
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            ControlCajasDeTexto();
        }

        private void txtDomicilio_TextChanged(object sender, EventArgs e)
        {
            ControlCajasDeTexto();
        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            ControlCajasDeTexto();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            Clientes cli = new Clientes();
            cli.Exportar();
        }

        private void txtCUIT_TextChanged(object sender, EventArgs e)
        {
            ControlCajasDeTexto();
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            ControlCajasDeTexto();
        }
    }
}
