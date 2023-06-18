using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Windows.Forms;

namespace ANINO_HNOS
{
    internal class DetalleVenta
    {
        private OleDbConnection Conexion = new OleDbConnection();
        private OleDbCommand Comando = new OleDbCommand();
        private OleDbDataAdapter Adaptador = new OleDbDataAdapter();

        private string CadenaConexion = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = BD-Anino.mdb";
        private string Tabla = "DetalleVenta";
        private Int32 detVen;
        private Int32 ven;
        private Int32 pro;
        private Decimal cant;
        private Decimal preun;
        private Decimal pre;  
        private Decimal iva;
        private Decimal sub;
        
        public Int32 IdDetalleVenta
        {
            get { return detVen; }
            set { detVen = value; }
        }
        public Int32 IdVenta
        {
            get { return ven; }
            set { ven = value; }
        }
        public Int32 IdProducto
        {
            get { return pro; }
            set { pro = value; }
        }
        public Decimal Cantidad
        {
            get { return cant; }
            set { cant = value;  } 
        }
        public Decimal Precio
        {
            get { return pre; }
            set { pre = value; }
        }
        public Decimal PrecioUnitario
        {
            get { return preun; }
            set { preun = value; } 
        }
        public Decimal IVA
        {
            get { return iva; }
            set { iva = value; }
        }
        public Decimal Subtotal
        {
            get { return sub; }
            set { sub = value; }
        }
        public void Agregar()
        {
            try
            {
                Ventas ventas = new Ventas();
                int ultimoIdVenta = ventas.ObtenerUltimoIdVenta(); // Obtener el último ID de venta desde la clase Ventas

                string sql = "INSERT INTO DetalleVenta (IdVenta, Producto, Cantidad, [Precio Unitario], Precio, IVA, Subtotal) ";
                sql += "VALUES (?, ?, ?, ?, ?, ?, ?)";

                Conexion.ConnectionString = CadenaConexion;
                Conexion.Open();

                Comando.Connection = Conexion;
                Comando.CommandType = CommandType.Text;
                Comando.CommandText = sql;

                Comando.Parameters.AddWithValue("@IdVenta", ultimoIdVenta); // Usar el último ID de venta obtenido
                Comando.Parameters.AddWithValue("@Producto", pro);
                Comando.Parameters.AddWithValue("@Cantidad", cant);
                Comando.Parameters.AddWithValue("@PrecioUnitario", preun);
                Comando.Parameters.AddWithValue("@Precio", pre);
                Comando.Parameters.AddWithValue("@IVA", iva);
                Comando.Parameters.AddWithValue("@Subtotal", sub);

                Comando.ExecuteNonQuery();

                Conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public DataTable ObtenerDetalleVentas(Int32 venta)
        {
            DataTable tablaDetalle = new DataTable();
            try
            {
                Conexion.ConnectionString = CadenaConexion;
                Conexion.Open();

                Comando.Connection = Conexion;
                Comando.CommandType = CommandType.TableDirect;
                Comando.CommandText = "DetalleVenta";
                OleDbDataReader DR = Comando.ExecuteReader();

                tablaDetalle.Load(DR);

                Conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

            // Filtrar la tabla por el campo IdVenta
            DataRow[] filas = tablaDetalle.Select("IdVenta = " + venta);
            DataTable tablaFiltrada = tablaDetalle.Clone();

            foreach (DataRow fila in filas)
            {
                tablaFiltrada.ImportRow(fila);
            }

            return tablaFiltrada;
        }
    }

}
