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
    public partial class frmConsultaVentas : Form
    {
        public frmConsultaVentas()
        {
            InitializeComponent();
        }

        private void frmConsultaVentas_Load(object sender, EventArgs e)
        {
            cmbUnidad.SelectedIndex = -1;
            dateTimePicker1.Value = DateTime.Now;
            btnNuevaBusqueda.Enabled = false;
            UnidadesDeNegocio unidades = new UnidadesDeNegocio();
            unidades.Listar(cmbUnidad);
        }

        private void btnNuevaBusqueda_Click(object sender, EventArgs e)
        {
            dgvDetalle.Rows.Clear();
            cmbUnidad.Enabled = true;
            dateTimePicker1.Enabled = true;
            btnBuscar.Enabled = true;
            cmbUnidad.SelectedIndex = -1;
            dateTimePicker1.Value = DateTime.Now;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Ventas ventas = new Ventas();
            ventas.IdUnidad = Convert.ToInt32(cmbUnidad.SelectedValue);
            ventas.Fecha = dateTimePicker1.Value;
            ventas.Buscar(dgvDetalle);
            lblTotal.Text = Convert.ToString(ventas.Total);
            cmbUnidad.Enabled = false;
            dateTimePicker1.Enabled = false;
            btnBuscar.Enabled = false;
            btnNuevaBusqueda.Enabled = true;
        }
    }
}
