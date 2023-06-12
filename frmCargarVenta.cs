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
    public partial class frmCargarVenta : Form
    {
        private Ventas ventas;
        public frmCargarVenta()
        {
            InitializeComponent();
            ventas = new Ventas(dgvDetalle); // Asigna la referencia del control DataGridView

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Obtener los datos de los controles correspondientes
            string cliente = cmbCliente.SelectedItem.ToString();
            string unidadNegocio = cmbUnidad.SelectedItem.ToString();
            string producto = cmbProducto.SelectedItem.ToString();
            decimal cantidad = decimal.Parse(txtCantidad.Text);
            decimal precio = decimal.Parse(txtPrecio.Text);
            decimal subtotal = cantidad * precio;

            // Agregar la fila en la grilla
            ventas.AgregarFila(cliente, unidadNegocio, producto, cantidad, precio, subtotal);

            // Limpiar los campos después de agregar
            LimpiarCampos();
        }
        private void LimpiarCampos()
        {
            cmbCliente.Items.Clear();
            cmbUnidad.Items.Clear();
            cmbProducto.Items.Clear();
            txtCantidad.Text = "";
            txtPrecio.Text = "";
            cmbCliente.Select();
        }

        private void frmCargarVenta_Load(object sender, EventArgs e)
        {
            Clientes cli = new Clientes();
            cli.Listar(cmbCliente);
        }
    }
}
