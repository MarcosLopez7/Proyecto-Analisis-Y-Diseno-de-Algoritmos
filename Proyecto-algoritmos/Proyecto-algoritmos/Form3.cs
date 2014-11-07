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
    public partial class Form3 : Form
    {
        public Form1 f1;
        public int n;
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            if (n == 0)
            {
                MessageBox.Show("No hay vertices insertados");
                this.Close();
            }

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.SoloNumeros(e);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.SoloNumeros(e);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.SoloNumeros(e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 0 && textBox2.Text.Length != 0 && textBox3.Text.Length != 0)
            {
                int i = Convert.ToInt32(textBox3.Text);
                int x = Convert.ToInt32(textBox1.Text);
                int y = Convert.ToInt32(textBox2.Text);

                if (n >= i && i >= 1 && 1145 >= x && x >= 25 && 705 >= y && y >= 25)
                {
                    f1.cambiarVertice(x, y, i);
                    this.Close();
                }
                else
                    MessageBox.Show("El rango de los campos son los siguientes\nel vertice va de 1 a" + n + "\nx de 25 a 1145\ny de 25 a 705");

            }
            else
                MessageBox.Show("Los campos tienen que estar llenos");
        }
    }
}
