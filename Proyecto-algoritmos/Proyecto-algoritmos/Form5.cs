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
    public partial class Form5 : Form
    {
        public int n;
        public Form1 f1;
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.SoloNumeros(e);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.SoloNumeros(e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 0 && textBox2.Text.Length != 0)
            {
                int o = Convert.ToInt32(textBox1.Text);
                int d = Convert.ToInt32(textBox2.Text);

                if (n >= d && d > 0 && n >= o && o > 0)
                {
                    if (f1.detecta_arista(o, d))
                    {
                        f1.elimina_arista(o, d);
                        this.Close();
                    }
                    else
                        MessageBox.Show("La arista no existe");
                }
                else
                    MessageBox.Show("El rango de los campos va:\nVértice origen y Vértce destino entre 1 y " + n);
            }
            else
                MessageBox.Show("Tiene que escribir en los campos");
        }
    }
}
