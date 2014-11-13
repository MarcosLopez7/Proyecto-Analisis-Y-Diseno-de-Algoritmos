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
    public partial class Form4 : Form
    {
        public Form1 f1;
        public int n;
        public int i;
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            if (n == 0)
            {
                MessageBox.Show("No hay vertices insertados");
                this.Close();
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 0 && textBox2.Text.Length != 0 && textBox3.Text.Length != 0)
            {
                int o = Convert.ToInt32(textBox1.Text);
                int d = Convert.ToInt32(textBox2.Text);
                int p = Convert.ToInt32(textBox3.Text);

                if (100 > p && p >= 1 && i >= d && d > 0 && i >= o && o > 0)
                {
                    if(!f1.detecta_arista(o, d))
                    {
                        f1.inserta_arista(o, d, p);
                        this.Close();
                    }
                    else
                        MessageBox.Show("La arista ya existe");
                }
                else
                    MessageBox.Show("El rango de los campos va:\nVértice origen y Vértce destino entre 1 y " + i + "\nPeso entre 1 y 99");
            }
            else
                MessageBox.Show("Tiene que escribir en los campos");
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.SoloNumeros(e);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.SoloNumeros(e);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.SoloNumeros(e);
        }

        
    }
}
