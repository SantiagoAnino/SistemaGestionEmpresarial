using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing.Printing;

namespace ANINO_HNOS
{
    public partial class frmGraficoVentas : Form
    {
        public frmGraficoVentas()
        {
            InitializeComponent();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            Ventas ventas = new Ventas();
            ventas.Graficar(pctGrafico);
            btnImprimir.Enabled = true;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            prtVentana.ShowDialog();
            prtDocumento.PrinterSettings = prtVentana.PrinterSettings;
            prtDocumento.Print();
            MessageBox.Show("Grafico impreso exitosamete!");
        }


        private void prtDocumento_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bmp = new Bitmap(pctGrafico.Width, pctGrafico.Height);
            pctGrafico.DrawToBitmap(bmp, new Rectangle(0, 0, pctGrafico.Width, pctGrafico.Height));


            Size originalSize = pctGrafico.Size;

            // Calcula las dimensiones reducidas para que no sea mas grande el grafico que la hoja
            float reduccionFactor = 0.6f;
            Size reducidaSize = new Size((int)(originalSize.Width * reduccionFactor), (int)(originalSize.Height * reduccionFactor));

            // Calcula la posición de inicio para dibujar el gráfico en el centro de la página
            int x = (e.PageBounds.Width - reducidaSize.Width) / 2;
            int y = (e.PageBounds.Height - reducidaSize.Height) / 2;

            // Dibuja el Bitmap en la posición calculada con las dimensiones reducidas
            e.Graphics.DrawImage(bmp, x, y, reducidaSize.Width, reducidaSize.Height);


        }
    }
}
