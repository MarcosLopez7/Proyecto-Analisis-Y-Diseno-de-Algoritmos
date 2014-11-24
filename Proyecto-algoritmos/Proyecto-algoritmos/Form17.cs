using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ExcelLibrary.CompoundDocumentFormat;
using ExcelLibrary.SpreadSheet;

using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

using System.Windows.Forms.DataVisualization.Charting;

namespace Proyecto_algoritmos
{
    public partial class Form17 : Form
    {
        public List<int> tiempos = new List<int>();
        public int i;
        public Form17()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form17_Load(object sender, EventArgs e)
        {
            this.chart1.Series["Tiempos"].Points.AddXY("BFS", tiempos[0]);
            this.chart1.Series["Tiempos"].Points.AddXY("DFS", tiempos[1]);
            this.chart1.Series["Tiempos"].Points.AddXY("Prim", tiempos[2]);
            this.chart1.Series["Tiempos"].Points.AddXY("Krus", tiempos[3]);
            this.chart1.Series["Tiempos"].Points.AddXY("Dj", tiempos[4]);
            this.chart1.Series["Tiempos"].Points.AddXY("F-W", tiempos[5]);
            this.chart1.Series["Tiempos"].Points.AddXY("I V", tiempos[6]);
            this.chart1.Series["Tiempos"].Points.AddXY("I A", tiempos[7]);
            this.chart1.Series["Tiempos"].Points.AddXY("E A", tiempos[8]);
            this.chart1.Series["Tiempos"].Points.AddXY("E V", tiempos[9]);
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string palabras = "algoritmo                tiempo\n";
            palabras += "BFS                " + Convert.ToString(tiempos[0]) + "\n";
            palabras += "DFS                " + Convert.ToString(tiempos[1]) + "\n";
            palabras += "Prim               " + Convert.ToString(tiempos[2]) + "\n";
            palabras += "Kruskal            " + Convert.ToString(tiempos[3]) + "\n";
            palabras += "Dijkstra           " + Convert.ToString(tiempos[4]) + "\n";
            palabras += "Floyd-Warshall     " + Convert.ToString(tiempos[5]) + "\n";
            palabras += "Insertar Vértice   " + Convert.ToString(tiempos[6]) + "\n";
            palabras += "Insertar Arista    " + Convert.ToString(tiempos[7]) + "\n";
            palabras += "Eliminar Arista    " + Convert.ToString(tiempos[8]) + "\n";
            palabras += "Eliminar Vertice   " + Convert.ToString(tiempos[9]) + "\n";

            string nombre = "Grafica" + i + ".pdf";
            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(nombre, FileMode.Create));
            doc.Open();
            var chartimage = new MemoryStream();
            
            chart1.SaveImage(chartimage, System.Drawing.Imaging.ImageFormat.Png);
            iTextSharp.text.Image Chart_image = iTextSharp.text.Image.GetInstance(chartimage.GetBuffer());
            doc.Add(Chart_image);

            Paragraph para = new Paragraph(palabras);
            doc.Add(para);

            doc.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string file = "Tiempos" + i + ".xlsx";
            Workbook workbook = new Workbook();
            Worksheet worksheet = new Worksheet("First Sheet");
            worksheet.Cells[0, 0] = new Cell("BFS");
            worksheet.Cells[1, 0] = new Cell("DFS");
            worksheet.Cells[2, 0] = new Cell("Prim");
            worksheet.Cells[3, 0] = new Cell("Kruskal");
            worksheet.Cells[4, 0] = new Cell("Dijkstra");
            worksheet.Cells[5, 0] = new Cell("Floyd-Warshall");
            worksheet.Cells[6, 0] = new Cell("Inserta Vértice");
            worksheet.Cells[7, 0] = new Cell("Inserta Arista");
            worksheet.Cells[8, 0] = new Cell("Elimina Arista");
            worksheet.Cells[9, 0] = new Cell("Eliminar Vértice");
            worksheet.Cells[0, 1] = new Cell(tiempos[0]);
            worksheet.Cells[1, 1] = new Cell(tiempos[1]);
            worksheet.Cells[2, 1] = new Cell(tiempos[2]);
            worksheet.Cells[3, 1] = new Cell(tiempos[3]);
            worksheet.Cells[4, 1] = new Cell(tiempos[4]);
            worksheet.Cells[5, 1] = new Cell(tiempos[5]);
            worksheet.Cells[6, 1] = new Cell(tiempos[6]);
            worksheet.Cells[7, 1] = new Cell(tiempos[7]);
            worksheet.Cells[8, 1] = new Cell(tiempos[8]);
            worksheet.Cells[9, 1] = new Cell(tiempos[9]);
            worksheet.Cells.ColumnWidth[0, 1] = 3000;
            workbook.Worksheets.Add(worksheet);
            workbook.Save(file);

            Workbook book = Workbook.Load(file);
            Worksheet sheet = book.Worksheets[0];

            

        }
    }
}
