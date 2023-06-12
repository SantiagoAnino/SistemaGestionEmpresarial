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
    public partial class frmSistemaGestion : Form
    {
        public frmSistemaGestion()
        {
            InitializeComponent();
        }

        private void cargarNuevoClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNuevoCliente Ventana = new frmNuevoCliente();
            Ventana.ShowDialog();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void acercaDelDesarrolladorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAcercaDelDesarrollador Ventana = new frmAcercaDelDesarrollador();
            Ventana.ShowDialog();
        }

        private void frmSistemaGestion_Load(object sender, EventArgs e)
        {
        }

        private void cargarVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCargarVenta Ventana = new frmCargarVenta();
            Ventana.ShowDialog();
        }
    }
}
