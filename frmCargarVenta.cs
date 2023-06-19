using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ANINO_HNOS
{
    public partial class frmCargarVenta : Form
    {
        private Ventas ventas;
        private DetalleVenta detalleventa;
        public frmCargarVenta()
        {
            InitializeComponent();
            ventas = new Ventas();
        }

        private void btnGenerarVenta_Click(object sender, EventArgs e)
        {
            // Obtener los valores de cliente, unidad de negocio y fecha desde los controles en el formulario
            Ventas ventas = new Ventas();
            ventas.IdCliente = Convert.ToInt32(cmbCliente.SelectedValue);
            ventas.IdUnidad = Convert.ToInt32(cmbUnidad.SelectedValue);
            ventas.Fecha = dateTimePicker1.Value;
            ventas.Agregar();
            int idventa = ventas.IdVenta;
            // Restablecer los campos para agregar una nueva venta
            cmbCliente.SelectedIndex = -1;
            cmbCliente.Enabled = false;
            cmbUnidad.SelectedIndex = -1;
            cmbUnidad.Enabled = false;
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker1.Enabled = false;
            lblIdVenta.Text = idventa.ToString();
            btnGenerarVenta.Enabled = false;
            txtCantidad.Enabled = true;
            txtPrecio.Enabled = true;
            cmbIva.Enabled = true;
            cmbProducto.Enabled = true;
            btnNuevaVenta.Enabled = true;
        }

        private void frmCargarVenta_Load(object sender, EventArgs e)
        {
            cmbCliente.SelectedIndex = -1;
            cmbUnidad.SelectedIndex = -1;
            cmbIva.Items.Add("Excento");
            cmbIva.Items.Add("10.5%");
            cmbIva.Items.Add("21%");
            cmbIva.SelectedIndex = -1;
            cmbProducto.SelectedItem = -1;
            dateTimePicker1.Value = DateTime.Now;
            Productos pro = new Productos();
            UnidadesDeNegocio uni = new UnidadesDeNegocio();
            Clientes cli = new Clientes();
            pro.Listar(cmbProducto);
            uni.Listar(cmbUnidad);
            cli.Listar(cmbCliente);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            detalleventa = new DetalleVenta(); // Cambio aquí

            detalleventa.IdProducto = Convert.ToInt32(cmbProducto.SelectedValue);
            detalleventa.Cantidad = Convert.ToDouble(txtCantidad.Text);
            detalleventa.PrecioUnitario = Convert.ToDouble(txtPrecio.Text);
            detalleventa.Precio = detalleventa.PrecioUnitario * detalleventa.Cantidad; 
            if (cmbIva.SelectedIndex == 2)
            {
                detalleventa.IVA = Convert.ToDouble(txtCantidad.Text)* Convert.ToDouble(txtPrecio.Text) / 100*21 ;
            }
            else if (cmbIva.SelectedIndex == 1)
            {
                detalleventa.IVA = Convert.ToDouble(txtCantidad.Text) * Convert.ToDouble(txtPrecio.Text) / 1000*105;
            }

            detalleventa.Subtotal = detalleventa.Precio + detalleventa.IVA;
            detalleventa.Agregar();


            ventas.Listar(dgvDetalle, Convert.ToInt32(lblIdVenta.Text));
            lblTotal.Text = ventas.Total.ToString("C");
            cmbProducto.SelectedIndex = -1;
            txtCantidad.Text = "";
            txtPrecio.Text = "";
            btnAgregar.Enabled = false;
        }
        private void Controlar()
        {
            if (txtCantidad.Text != "" && txtPrecio.Text != "" &&  cmbProducto.SelectedIndex != -1 && cmbIva.SelectedIndex != -1)
            {
                btnAgregar.Enabled = true;
            }
        }

        private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            Controlar();
        }

        private void cmbIva_SelectedIndexChanged(object sender, EventArgs e)
        {
            Controlar();
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            Controlar();
        }

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {
            Controlar();
        }

        private void btnNuevaVenta_Click(object sender, EventArgs e)
        {
            btnGenerarVenta.Enabled = true;
            cmbCliente.Enabled = true;
            cmbUnidad.Enabled = true;
            dateTimePicker1.Enabled = true;
            cmbProducto.Enabled = false;
            cmbIva.Enabled = false;
            txtCantidad.Enabled = false;
            txtPrecio.Enabled = false;
            btnAgregar.Enabled=false;
            dgvDetalle.Rows.Clear();
            lblTotal.Text = "";
            ventas.Total = 0;
            btnNuevaVenta.Enabled = false;
        }
    }
}
