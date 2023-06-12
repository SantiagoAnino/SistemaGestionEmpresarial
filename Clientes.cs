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
    internal class Clientes
    {
        private OleDbConnection Conexion = new OleDbConnection();
        private OleDbCommand Comando = new OleDbCommand();
        private OleDbDataAdapter Adaptador = new OleDbDataAdapter();
        
        private string CadenaConexion = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = BD-Anino.mdb";
        private string Tabla = "Clientes";

        private String nom;
        private String dom;
        private String ciu;
        private String prov;
        private String tel;
        private String cuit;
        private String mail;

        public string Nombre
        {
            get { return nom; }
            set { nom = value; }
        }
        public string Domicilio
        {
            get { return dom; }
            set { dom = value; }
        }
        public string Ciudad
        {
            get { return ciu; }
            set { ciu = value; }
        }
        public string Provincia
        {
            get { return prov; }
            set { prov = value; }
        }
        public string Telefono
        {
            get { return tel; }
            set { tel = value; }
        }
        public string CUIT
        {
            get { return cuit; }
            set { cuit = value; }
        }
        public string Email
        {
            get { return mail; }
            set { mail = value; }
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

                Adaptador = new OleDbDataAdapter( Comando );
                DataSet ds = new DataSet();
                Adaptador.Fill( ds, Tabla );

                DataTable tabla = ds.Tables[Tabla];
                DataRow fila = tabla.NewRow();

                fila["Nombre"] = nom;
                fila["Domicilio"] = dom;
                fila["Ciudad"] = ciu;
                fila["Provincia"] = prov;
                fila["CUIT"] = cuit;
                fila["Telefono"] = tel;
                fila["Email"] = mail;

                tabla.Rows.Add( fila );
                OleDbCommandBuilder ConciliacionCambios = new OleDbCommandBuilder(Adaptador);
                Adaptador.Update(ds, Tabla);

                Conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        public void Exportar()
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

                StreamWriter Archivo = new StreamWriter("Clientes.txt", false, Encoding.UTF8);
                Archivo.WriteLine("Listado De Clientes");
                Archivo.WriteLine("");
                Archivo.WriteLine("IdCliente;Nombre;Domicilio;Ciudad;Provincia;CUIT;Telefono;Email");
                foreach (DataRow fila in ds.Tables[Tabla].Rows)
                {
                    Archivo.Write(fila["IdCliente"]);
                    Archivo.Write(";");
                    Archivo.Write(fila["Nombre"]);
                    Archivo.Write(";");
                    Archivo.Write(fila["Domicilio"]);
                    Archivo.Write(";");
                    Archivo.Write(fila["Ciudad"]);
                    Archivo.Write(";");
                    Archivo.Write(fila["Provincia"]);
                    Archivo.Write(";");
                    Archivo.Write(fila["CUIT"]);
                    Archivo.Write(";");
                    Archivo.Write(fila["Telefono"]);
                    Archivo.Write(";");
                    Archivo.WriteLine(fila["Email"]);
                }
                Archivo.Close();
                Conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
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
                Combo.ValueMember = "IdCliente";
                Conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
    }
}
