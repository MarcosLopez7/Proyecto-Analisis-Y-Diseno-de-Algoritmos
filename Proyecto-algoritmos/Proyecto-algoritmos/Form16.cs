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
    public partial class Form16 : Form
    {
        public Form1 f1;
        public int i;
        public int n;
        public Form16()
        {
            InitializeComponent();
            button1.Enabled = false;
            textBox1.Enabled = false;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.SoloNumeros(e);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                button1.Enabled = true;
                textBox1.Enabled = true;
                button2.Enabled = false;
            }
            else
            {
                button1.Enabled = false;
                textBox1.Enabled = false;
                button2.Enabled = true;
            } 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Length != 0)
            {
                int t = Convert.ToInt32(textBox1.Text);
                f1.floyd(true, t);
                this.Close();
            }
        }
    }
}
