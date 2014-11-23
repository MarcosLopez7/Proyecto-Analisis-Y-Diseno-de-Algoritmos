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
    public partial class Form10 : Form
    {
        List<List<Label>> leibols = new List<List<Label>>();
        public List<List<int>> matix = new List<List<int>>();
        public Form10()
        {
            InitializeComponent();

            
        }

        private void inicia_label()
        {
            for (int i = 0; i < matix.Count; i++)
            {
                List<Label> aux = new List<Label>();   
                Label leibol1 = new Label();
                aux.Add(leibol1);
                Label leibol2 = new Label();
                aux.Add(leibol2);
                Label leibol3 = new Label();
                aux.Add(leibol3);
                leibols.Add(aux);
            }
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            inicia_label();

            for (int i = 0; i < matix.Count; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    leibols[i][j].AutoSize = true;
                    leibols[i][j].Location = new Point(label1.Location.X + (j * 65), label1.Location.Y + ((i + 1) * 20));
                    leibols[i][j].Font = new Font(leibols[i][j].Font, FontStyle.Regular);
                    leibols[i][j].Text = Convert.ToString(matix[i][j]);
                    this.Controls.Add(leibols[i][j]);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
