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
    public partial class Form13 : Form
    {
        public Form1 f1;
        public int n;
        public int i;
        public Form13()
        {
            InitializeComponent();

            button1.Enabled = false;
            textBox2.Enabled = false;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.SoloNumeros(e);
        }

        private void Form13_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.SoloNumeros(e);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                button1.Enabled = true;
                textBox2.Enabled = true;
                button2.Enabled = false;
            }
            else 
            {
                button1.Enabled = false;
                textBox2.Enabled = false;
                button2.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Length != 0 && textBox2.Text.Length != 0)
            {

                int v = Convert.ToInt32(textBox1.Text);
                int t = Convert.ToInt32(textBox2.Text);
                f1.Dijkstra(v, true, t);
                this.Close();

            }
        }
    }
}
