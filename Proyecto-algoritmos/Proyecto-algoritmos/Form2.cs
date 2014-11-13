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
    public partial class Form2 : Form
    {

        public int x;
        public int y;
        public bool aceptado = true;
        public Form1 f1;
        public int n;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.SoloNumeros(e);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.SoloNumeros(e);
        }

        public void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 0 && textBox2.Text.Length != 0)
            {

                x = Convert.ToInt32(textBox2.Text);
                y = Convert.ToInt32(textBox1.Text);

                if (1145 >= x && x >= 25 && 705 >= y && y >= 25)
                {
                    if(f1.detecta_posicion(x, y))
                    {
                        f1.insertaVertice(x, y);
                        this.Close();
                    }
                    else
                        MessageBox.Show("La posición insertada se interpone con otro vértice\n");
                }
                else
                    MessageBox.Show("El rango de la posición va:\nx entre 25 y 1145\ny entre 25 y 705");
            }
            else
                MessageBox.Show("Tiene que escribir en los campos");

        }
    }
}
