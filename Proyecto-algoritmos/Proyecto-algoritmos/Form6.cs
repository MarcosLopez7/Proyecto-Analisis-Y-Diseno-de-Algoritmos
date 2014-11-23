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
    public partial class Form6 : Form
    {
        public Form1 f1;
        public int n;
        public int i;
        public Form6()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.SoloNumeros(e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Length != 0)
            {
                int v = Convert.ToInt32(textBox1.Text);
                if(i >= v && v > 0)
                {
                    f1.elimina_vertice(v, false, 0);
                    this.Close();
                }
                else
                    MessageBox.Show("El rango de los campos son los siguientes\nel vertice va de 1 a" + n);
            }
            else
                MessageBox.Show("Tiene que escribir en los campos");
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            if (n == 0)
            {
                MessageBox.Show("No hay vertices insertados");
                this.Close();
            }
            button3.Enabled = false;
            textBox2.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 0 && textBox2.Text.Length != 0)
            {
                int v = Convert.ToInt32(textBox1.Text);
                int t = Convert.ToInt32(textBox2.Text);
                if (i >= v && v > 0)
                {
                    f1.elimina_vertice(v, true, t);
                    this.Close();
                }
                else
                    MessageBox.Show("El rango de los campos son los siguientes\nel vertice va de 1 a" + n);
            }
            else
                MessageBox.Show("Tiene que escribir en los campos");
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.SoloNumeros(e);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                button1.Enabled = false;
                button4.Enabled = false;
                button3.Enabled = true;
                textBox2.Enabled = true;
            }
            else
            {
                button1.Enabled = true;
                button4.Enabled = true;
                button3.Enabled = false;
                textBox2.Enabled = false;
            }
        }
    }
}
