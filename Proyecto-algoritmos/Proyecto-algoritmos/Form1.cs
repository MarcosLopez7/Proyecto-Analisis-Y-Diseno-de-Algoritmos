using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_algoritmos
{
    public partial class Form1 : Form
    {
        private Grafo<int, int> grafo = new Grafo<int,int>();
        private int i = 0;
        public bool aceptado;
        public Form1()
        {
            InitializeComponent();
         //   grafo = new Grafo<int, int>(pictureBox1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            grafo.setImagen(pictureBox1);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 formulon = new Form2();
            formulon.f1 = this;
            formulon.Show();
            
        }

        public void insertaVertice(int x, int y)
        {
            i++;
            Vertice<int, int> nodulon = new Vertice<int, int>(i, x, y);
            grafo.insertar_vertice(nodulon, x, y);
            //grafo.trazo.DDALine(200, 200, 300, 300);
            grafo.cargarImagen();
        }

        public void cambiarVertice(int x, int y, int i)
        {
            grafo.cambiar_posicion_vertice(x, y, i);
            grafo.cargarImagen();
        }

        private void button9_Click(object sender, EventArgs e)
        {
          Form3 formulon = new Form3();
          formulon.n = i;
          formulon.f1 = this;
          formulon.Show();
        }
    }
}
