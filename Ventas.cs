using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using System.IO;

namespace ANINO_HNOS
{
    internal class Ventas
    {
        private OleDbConnection Conexion = new OleDbConnection();
        private OleDbCommand Comando = new OleDbCommand();
        private OleDbDataAdapter Adaptador = new OleDbDataAdapter();

        private string CadenaConexion = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = BD-Anino.mdb";
        private string Tabla = "Ventas";

        private DateTime fec;
        public DateTime Fecha
        {
            get { return fec; }
            set { fec = value; }
        }
        private DataGridView dataGridViewVentas; // Referencia al control DataGridView en tu formulario

        public Ventas(DataGridView dataGridView)
        {
            dataGridViewVentas = dataGridView;
        }

        public void AgregarFila(string cliente, string unidadNegocio, string producto, decimal cantidad, decimal precio, decimal subtotal)
        {
            try
            {
                Conexion.ConnectionString = CadenaConexion;
                Conexion.Open();

                Comando.Connection = Conexion;
                Comando.CommandType = CommandType.TableDirect;
                Comando.CommandText = Tabla;

                Adaptador = new OleDbDataAdapter(Comando);
                DataSet ds = new DataSet();
                Adaptador.Fill(ds, Tabla);

                DataTable tabla = ds.Tables[Tabla];

                // Agregar una nueva fila a la tabla
                DataRow filaNueva = tabla.NewRow();
                filaNueva["Cliente"] = cliente;
                filaNueva["UnidadNegocio"] = unidadNegocio;
                filaNueva["Producto"] = producto;
                filaNueva["Cantidad"] = cantidad;
                filaNueva["Precio"] = precio;
                filaNueva["Subtotal"] = subtotal;
                tabla.Rows.Add(filaNueva);

                // Actualizar el control DataGridView en tu formulario
                ActualizarDataGridView(tabla);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        private void ActualizarDataGridView(DataTable tabla)
        {
            dataGridViewVentas.DataSource = null;
            dataGridViewVentas.DataSource = tabla;
        }

    }
}
