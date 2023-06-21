using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Agregamos tres espacios de nombre
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;
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

        public void Buscar(DataGridView Grilla)
        {
            Conexion.ConnectionString = CadenaConexion;
            Conexion.Open();
            Comando.Connection = Conexion;
            Comando.CommandType = CommandType.TableDirect;
            Comando.CommandText = Tabla;
            OleDbDataReader DR = Comando.ExecuteReader();
            Clientes cli = new Clientes();
            UnidadesDeNegocio uni = new UnidadesDeNegocio();
            DetalleVenta detalleVenta = new DetalleVenta();


            String nombreCli = "";
            String nombreUni = "";
            Decimal T = 0;
            if (DR.HasRows)
            {
                while (DR.Read())
                {   
                    DetalleVenta detalle = new DetalleVenta();

                    DataTable tablaDetalle = detalleVenta.ObtenerDetalleVentas(DR.GetInt32(0));

                    if (DR.GetInt32(3) == IdUnidad && DR.GetDateTime(1).Date == Fecha.Date)
                    {
                        foreach (DataRow filaDetalle in tablaDetalle.Rows)
                        {
                            nombreCli = cli.Buscar(DR.GetInt32(2));
                            nombreUni = uni.Buscar(DR.GetInt32(3));
                            Decimal cantidad = Convert.ToDecimal(filaDetalle["Cantidad"]);
                            Decimal PrecioUnitario = Convert.ToDecimal(filaDetalle["Precio Unitario"]);
                            Decimal Precio = Convert.ToDecimal(filaDetalle["Precio"]);
                            Decimal IVA = Convert.ToDecimal(filaDetalle["IVA"]);
                            Decimal Subtotal = Convert.ToDecimal(filaDetalle["Subtotal"]);
                            Int32 idProducto = Convert.ToInt32(filaDetalle["Producto"]);

                            DataGridViewRow fila = Grilla.Rows[Grilla.Rows.Add()];
                            fila.Cells["IdVenta"].Value = DR.GetInt32(0);
                            fila.Cells["Fecha"].Value = DR.GetDateTime(1);
                            fila.Cells["Cliente"].Value = nombreCli;
                            fila.Cells["Unidad"].Value = nombreUni;

                            Productos pro = new Productos();
                            string nomPro = pro.Buscar(idProducto);

                            fila.Cells["Producto"].Value = nomPro;
                            fila.Cells["Cantidad"].Value = cantidad;
                            fila.Cells["PrecioUnitario"].Value = PrecioUnitario;
                            fila.Cells["Precio"].Value = Precio;
                            fila.Cells["IVA"].Value = IVA;
                            fila.Cells["Subtotal"].Value = Subtotal;
                            T = Subtotal;
                            total = total + T;
                        }


                    }
                }
            }
        }

        private DateTime ObtenerFechaMinima()
        {
            DateTime fechaMinima = DateTime.MinValue;
            try
            {
                Conexion.ConnectionString = CadenaConexion;
                Conexion.Open();

                Comando.Connection = Conexion;
                Comando.CommandType = CommandType.Text;
                Comando.CommandText = "SELECT MIN(Fecha) FROM Ventas";

                object result = Comando.ExecuteScalar();
                if ( result != null && result != DBNull.Value)
                {
                    fechaMinima = Convert.ToDateTime(result).Date;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                Conexion.Close();
            }
            return fechaMinima;
        }
        private DateTime ObtenerFechaMaxima()
        {
            DateTime fechaMaxima = DateTime.MinValue;
            try
            {
                Conexion.ConnectionString = CadenaConexion;
                Conexion.Open();

                Comando.Connection = Conexion;
                Comando.CommandType = CommandType.Text;
                Comando.CommandText = "SELECT MAX(Fecha) FROM Ventas";

                object result = Comando.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    fechaMaxima = Convert.ToDateTime(result).Date;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                Conexion.Close();
            }
            return fechaMaxima;
        }
    

        public void Graficar(PictureBox pictureBox)
        {
            try
            {
                // Obtener todas las ventas dentro del rango de fechas
                List<int> listaIdVentas = new List<int>();
                DateTime min = ObtenerFechaMinima().Date;
                DateTime max = ObtenerFechaMaxima().Date;
                Conexion.ConnectionString = CadenaConexion;
                Conexion.Open();

                Comando.Connection = Conexion;
                Comando.CommandType = CommandType.Text;
                Comando.CommandText = "SELECT IdVenta FROM Ventas";

                OleDbDataReader DRVentas = Comando.ExecuteReader();

                while (DRVentas.Read())
                {
                    int idVenta = DRVentas.GetInt32(0);
                    listaIdVentas.Add(idVenta);
                }

                Conexion.Close();

                // Obtener la fecha mínima y máxima para utilizar en el gráfico
                DateTime fechaMinima = min.Date;
                DateTime fechaMaxima = max.Date;

                // Crear una lista para almacenar las sumas de los subtotales por fecha
                List<decimal> listaSumasSubtotales = new List<decimal>();

                // Obtener la suma de los subtotales para cada fecha
                foreach (int idVenta in listaIdVentas)
                {
                    // Obtener los detalles de venta para el IdVenta actual
                    DetalleVenta detalleVenta = new DetalleVenta();
                    DataTable tablaDetalle = detalleVenta.ObtenerDetalleVentas(idVenta);

                    // Calcular la suma de los subtotales para la fecha actual
                    decimal sumaSubtotales = 0;
                    foreach (DataRow filaDetalle in tablaDetalle.Rows)
                    {
                        decimal subtotal = Convert.ToDecimal(filaDetalle["Subtotal"]);
                        sumaSubtotales += subtotal;
                    }

                    // Agregar la suma de los subtotales a la lista
                    listaSumasSubtotales.Add(sumaSubtotales);
                }

                // Crear el control de gráfico
                Chart chart = new Chart();
                chart.Size = pictureBox.Size;

                // Configurar el tipo de gráfico
                chart.Series.Clear();
                chart.Series.Add("Suma de Subtotales");
                chart.Series["Suma de Subtotales"].ChartType = SeriesChartType.Column;

                chart.ChartAreas.Add("Area1"); // Agrega un área de gráfico con el nombre "Area1"

                // Agregar los puntos de datos al gráfico
                if (listaSumasSubtotales.Any())
                {
                    // Agregar los puntos de datos al gráfico
                    for (int i = 0; i < listaSumasSubtotales.Count; i++)
                    {
                        chart.Series.Add("Serie" + i);
                        chart.Series["Serie" + i].ChartType = SeriesChartType.Line;
                        chart.Series["Suma de Subtotales"].Points.AddXY(i, listaSumasSubtotales[i]);

                    }
                }

                chart.ChartAreas[0].AxisY.LabelStyle.Format = "C";



                // Asociar el gráfico al PictureBox
                pictureBox.Controls.Clear();
                pictureBox.Controls.Add(chart);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

    }

}
