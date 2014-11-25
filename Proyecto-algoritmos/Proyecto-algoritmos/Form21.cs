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
    public partial class Form21 : Form
    {
        List<List<Label>> leibols = new List<List<Label>>();
        List<Label> y = new List<Label>();
        List<Label> x = new List<Label>();
        public List<List<int>> matix = new List<List<int>>();
        public Form21()
        {
            InitializeComponent();
        }

        private void inicia_label()
        {
            for (int i = 0; i < matix.Count; i++)
            {
                List<Label> aux = new List<Label>();
                for (int j = 0; j < matix.Count; j++)
                {
                    Label l = new Label();
                    aux.Add(l);
                }
                leibols.Add(aux);
                Label ly = new Label();
                Label lx = new Label();
                y.Add(ly);
                x.Add(lx);
            }
        }

        private void Form21_Load(object sender, EventArgs e)
        {
            inicia_label();

            for (int i = 0; i < matix.Count; i++)
            {
                y[i].AutoSize = true;
                y[i].Location = new Point(label1.Location.X, label1.Location.Y + ((i + 1) * 20));
                y[i].Font = new Font(y[i].Font, FontStyle.Regular);
                y[i].Text = Convert.ToString(i + 1);

                this.Controls.Add(y[i]);

                x[i].AutoSize = true;
                x[i].Location = new Point(label1.Location.X + ((i + 1) * 60), label1.Location.Y);
                x[i].Font = new Font(y[i].Font, FontStyle.Regular);
                x[i].Text = Convert.ToString(i + 1);

                this.Controls.Add(x[i]);
            }

            for (int i = 0; i < matix.Count; i++)
            {
                for (int j = 0; j < matix.Count; j++)
                {
                    leibols[i][j].AutoSize = true;
                    leibols[i][j].Location = new Point(label1.Location.X + ((j + 1) * 65), label1.Location.Y + ((i + 1) * 20));
                    leibols[i][j].Font = new Font(leibols[i][j].Font, FontStyle.Regular);
                    leibols[i][j].Text = Convert.ToString(matix[i][j]);
                    this.Controls.Add(leibols[i][j]);
                }
            }
        }

        public void carga()
        {
            for (int i = 0; i < matix.Count; i++)
            {
                for (int j = 0; j < matix.Count; j++)
                {
                    leibols[i][j].AutoSize = true;
                    leibols[i][j].Location = new Point(label1.Location.X + ((j + 1) * 65), label1.Location.Y + ((i + 1) * 20));
                    leibols[i][j].Font = new Font(leibols[i][j].Font, FontStyle.Regular);
                    leibols[i][j].Text = Convert.ToString(matix[i][j]);
                    this.Controls.Add(leibols[i][j]);
                }
            }
        }
    }
}
