using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

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
        private Int32 ven;
        private Int32 uni;
        private Int32 cli;
        private Decimal total;
        public DateTime Fecha
        {
            get { return fec; }
            set { fec = value; }
        }
        public Int32 IdVenta
        {
            get { return ven; }
            set { ven = value; }
        }
        public Int32 IdUnidad
        {
            get { return uni; }
            set { uni = value; }
        }
        public Int32 IdCliente
        {
            get { return cli; }
            set { cli = value; }
        }
        public Decimal Total
        {
            get { return total; }
            set { total = value; }
        }
        public void Agregar()
        {

            try
            {

                Conexion.ConnectionString = CadenaConexion;
                Conexion.Open();
                Comando.Connection = Conexion;
                Comando.CommandType = CommandType.TableDirect;
                Comando.CommandText = Tabla;
                Adaptador = new OleDbDataAdapter(Comando);
                DataSet DS = new DataSet();
                Adaptador.Fill(DS, Tabla);
                DataTable tabla = DS.Tables[Tabla];
                DataRow fila = tabla.NewRow();

                fila["Fecha"] = fec; 
                fila["IdCliente"] = cli;
                fila["IdUnidad"] = uni;

                tabla.Rows.Add(fila);

                OleDbCommandBuilder constructorComandos = new OleDbCommandBuilder(Adaptador);
                Adaptador.UpdateCommand = constructorComandos.GetUpdateCommand();
                Adaptador.Update(DS, Tabla);

                Comando.CommandText = "SELECT @@IDENTITY";
                Int32 idVenta = Convert.ToInt32(Comando.ExecuteScalar());
                Conexion.Close();
                IdVenta = idVenta;
                MessageBox.Show("Venta generada correctamente.");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        public int ObtenerUltimoIdVenta()
        {
            int ultimoId = 0;

            try
            {
                Conexion.ConnectionString = CadenaConexion;
                Conexion.Open();

                Comando.Connection = Conexion;
                Comando.CommandType = CommandType.Text;
                Comando.CommandText = "SELECT MAX(IdVenta) FROM Ventas";

                // Ejecutar el comando y obtener el último ID de venta
                object result = Comando.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    ultimoId = Convert.ToInt32(result);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al obtener el último ID de venta: " + e.ToString());
            }
            finally
            {
                Conexion.Close();
            }

            return ultimoId;
        }

        public void Listar(DataGridView Grilla, Int32 idVenta)
        {

            try
            {
                Conexion.ConnectionString = CadenaConexion;
                Conexion.Open();

                Comando.Connection = Conexion;
                Comando.CommandType = CommandType.Text;
                Comando.CommandText = "SELECT * FROM Ventas WHERE IdVenta = ?";
                Comando.Parameters.AddWithValue("@IdVenta", idVenta);
                OleDbDataReader DRVentas = Comando.ExecuteReader();

                Grilla.Rows.Clear();
                Clientes cli = new Clientes();
                UnidadesDeNegocio uni = new UnidadesDeNegocio();
                DetalleVenta detalleVenta = new DetalleVenta();


                String nombreCli = "";
                String nombreUni = "";

                if (DRVentas.HasRows)
                {
                    Decimal T = 0;
                    while (DRVentas.Read())
                    {
                        nombreCli = cli.Buscar(DRVentas.GetInt32(2));
                        nombreUni = uni.Buscar(DRVentas.GetInt32(3));

                        DataTable tablaDetalle = detalleVenta.ObtenerDetalleVentas(idVenta);

                        foreach (DataRow filaDetalle in tablaDetalle.Rows)
                        {

                            Decimal cantidad = Convert.ToDecimal(filaDetalle["Cantidad"]);
                            Decimal PrecioUnitario = Convert.ToDecimal(filaDetalle["Precio Unitario"]);
                            Decimal Precio = Convert.ToDecimal(filaDetalle["Precio"]);
                            Decimal IVA = Convert.ToDecimal(filaDetalle["IVA"]);
                            Decimal Subtotal = Convert.ToDecimal(filaDetalle["Subtotal"]);
                            Int32 idProducto = Convert.ToInt32(filaDetalle["Producto"]);

                            Productos pro = new Productos();
                            string nomPro = pro.Buscar(idProducto);


                            DataGridViewRow fila = Grilla.Rows[Grilla.Rows.Add()];
                            fila.Cells["IdVenta"].Value = idVenta;
                            fila.Cells["Fecha"].Value = DRVentas.GetDateTime(1);
                            fila.Cells["Cliente"].Value = nombreCli;
                            fila.Cells["Unidad"].Value = nombreUni;
                            fila.Cells["Producto"].Value = nomPro;
                            fila.Cells["Cantidad"].Value = cantidad;
                            fila.Cells["PrecioUnitario"].Value = PrecioUnitario;
                            fila.Cells["Precio"].Value = Precio;
                            fila.Cells["IVA"].Value = IVA;
                            fila.Cells["Subtotal"].Value = Subtotal;

                            T = Subtotal;
                        }
                        total = total + T;
                    }
                }
                
                DRVentas.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al listar las ventas: " + ex.Message);
            }
            finally
            {
                Conexion.Close();
            }
        }

    }

}
