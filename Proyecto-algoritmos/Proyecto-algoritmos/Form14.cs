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
    public partial class Form14 : Form
    {
        List<Label> leibols = new List<Label>();
        List<Label> x = new List<Label>();
        public List<int> matix = new List<int>();
        public Form14()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form14_Load(object sender, EventArgs e)
        {
            inicia_labels();

            for(int i = 0; i < matix.Count; i++)
            {
                x[i].AutoSize = true;
                x[i].Location = new Point(label1.Location.X + ((i + 1) * 60), label1.Location.Y);
                x[i].Font = new Font(x[i].Font, FontStyle.Regular);
                x[i].Text = Convert.ToString(i + 1);

                this.Controls.Add(x[i]);

                leibols[i].AutoSize = true;
                leibols[i].Location = new Point(label2.Location.X + ((i + 1) * 60), label2.Location.Y);
                leibols[i].Font = new Font(leibols[i].Font, FontStyle.Regular);
                leibols[i].Text = Convert.ToString(matix[i]);

                this.Controls.Add(leibols[i]);
            }
        }

        private void inicia_labels()
        {
            for(int i = 0; i < matix.Count; i++)
            {
                Label l1 = new Label();
                Label l2 = new Label();
                leibols.Add(l1);
                x.Add(l2);
            }
        }
    }
}
