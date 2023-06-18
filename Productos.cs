using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using System.IO;

namespace ANINO_HNOS
{
    internal class Productos
    {
        private OleDbConnection Conexion = new OleDbConnection();
        private OleDbCommand Comando = new OleDbCommand();
        private OleDbDataAdapter Adaptador = new OleDbDataAdapter();

        private string CadenaConexion = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = BD-Anino.mdb";
        private string Tabla = "Productos";

        public void Listar(ComboBox Combo)
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

                Combo.DataSource = DS.Tables[Tabla];
                Combo.DisplayMember = "Nombre";
                Combo.ValueMember = "IdProducto";
                Conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        public String Buscar(Int32 prod)
        {
            try
            {
                Conexion.ConnectionString = CadenaConexion;
                Conexion.Open();

                Comando.Connection = Conexion;
                Comando.CommandType = CommandType.TableDirect;
                Comando.CommandText = Tabla;
                OleDbDataReader DR = Comando.ExecuteReader();
                String Resultado = "";

                if (DR.HasRows)
                {
                    while (DR.Read())
                    {
                        if (DR.GetInt32(0) == prod)
                        {
                            Resultado = DR.GetString(1);
                        }
                    }
                }
                Conexion.Close();
                return Resultado;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return "";
            }
        }
    }
}
