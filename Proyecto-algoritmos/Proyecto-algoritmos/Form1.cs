﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Proyecto_algoritmos
{
    public partial class Form1 : Form
    {
        private Grafo<int, int> grafo = new Grafo<int,int>();
        private int i = 0;
        public bool aceptado;
        int n = 0;
        public Form1()
        {
            InitializeComponent();
         //   grafo = new Grafo<int, int>(pictureBox1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            grafo.setImagen(pictureBox1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 formulon = new Form2();
            formulon.f1 = this;
            formulon.Show();
            
        }

        /*Método que se ejecuta desde el botón 1*/
        public void insertaVertice(int x, int y)
        {
            i++;
            Vertice<int, int> nodulon = new Vertice<int, int>(i, x, y);
            grafo.insertar_vertice(nodulon, x, y);
            grafo.cargarImagen();
        }

        /*Método que se ejecuta desde el botón 9*/
        public void cambiarVertice(int x, int y, int i, bool slow, int tiempo)
        {

            grafo.cambiar_posicion_vertice(x, y, grafo.busqueda_vertice(i), slow, tiempo);
            grafo.cargarImagen();
        }

        /*Método para validar la posición de un vértice*/
        public bool detecta_posicion(int x, int y)
        {
            return grafo.detecta_posicion(x, y);
        }

        public bool detecta_arista(int o, int d) 
        {
            return grafo.busqueda_arista(grafo.busqueda_vertice(o), grafo.busqueda_vertice(d));
        }

        private void button9_Click(object sender, EventArgs e)
        {
          Form3 formulon = new Form3();
          formulon.n = i;
          formulon.f1 = this;
          formulon.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 formulon = new Form4();
            formulon.f1 = this;
            formulon.n = grafo.Num_Nodos;
            formulon.i = i;
            formulon.Show();
        }

        /*Método que se ejecuta desde el botón 2*/
        public void inserta_arista(int o, int d, int peso)
        {

            grafo.insertar_aritsta(grafo.busqueda_vertice(o), grafo.busqueda_vertice(d), peso);
            grafo.cargarImagen();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form5 formulon = new Form5();
            formulon.f1 = this;
            formulon.n = grafo.Num_Nodos;
            formulon.Show();
        }

        /*Método que se ejecuta desde el botón 6*/
        public void elimina_arista(int o, int d)
        {
            grafo.elimina_arista(grafo.busqueda_vertice(o), grafo.busqueda_vertice(d));
            grafo.cargarImagen();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form6 formulon = new Form6();
            formulon.f1 = this;
            formulon.n = grafo.Num_Nodos;
            formulon.i = i;
            formulon.Show();
        }

        /*Método que se ejecuta en el botón 7*/
        public void elimina_vertice(int v, bool slow, int tiempo)
        {
            grafo.elimina_vertice(grafo.busqueda_vertice(v), slow, tiempo);
            grafo.cargarImagen();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form7 formulon = new Form7();
            formulon.f1 = this;
            formulon.n = grafo.Num_Nodos;
            formulon.i = i;
            formulon.Show();
        }

        /*Método que se ejecuta en el botón 3*/
        public void bfs(int v, bool slow, int tiempo)
        {
            grafo.BFS(grafo.busqueda_vertice(v), slow, tiempo);
            grafo.cargarImagen();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form8 formulon = new Form8();
            formulon.f1 = this;
            formulon.n = grafo.Num_Nodos;
            formulon.i = i;
            formulon.Show();
        }

        /* Método que se ejecuta en el botón 4 */
        public void dfs(int v, bool slow, int tiempo)
        {
            grafo.DFS(grafo.busqueda_vertice(v), slow, tiempo);
            grafo.cargarImagen();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form9 formulon = new Form9();
            formulon.f1 = this;
            formulon.n = grafo.Num_Nodos;
            formulon.i = i;
            formulon.Show();
        }

        /*Método que se ejecuta en el botón 5*/
        public void PRIM(bool slow, int tiempo)
        {
            List<List<int>> matrix;
            matrix = grafo.prim(slow, tiempo);
            grafo.cargarImagen();
            Form10 formulon = new Form10();
            formulon.matix = matrix;
            formulon.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form11 formulon = new Form11();
            formulon.f1 = this;
            formulon.n = grafo.Num_Nodos;
            formulon.i = i;
            formulon.Show();
        }

        /*Método que se ejecuta en el botón 8*/
        public void KRUSKAL(bool slow, int tiempo)
        {
            List<List<int>> matrix;
            matrix = grafo.kruskal(slow, tiempo);
            grafo.cargarImagen();
            Form12 formulon = new Form12();
            formulon.matix = matrix;
            formulon.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form13 formulon = new Form13();
            formulon.f1 = this;
            formulon.n = grafo.Num_Nodos;
            formulon.i = i;
            formulon.Show();
        }

        /*Método que se ejecuta en el botón 10*/
        public void Dijkstra(int v, bool slow, int tiempo)
        {
            List<int> matrix;
            matrix = grafo.dijkstra(grafo.busqueda_vertice(v),slow, tiempo);
            grafo.cargarImagen();
            Form14 formulon = new Form14();
            formulon.matix = matrix;
            formulon.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Form16 formulon = new Form16();
            formulon.f1 = this;
            formulon.n = grafo.Num_Nodos;
            formulon.i = i;
            formulon.Show();
        }

        /* Método que se ejecuta en el botón 11*/
        public void floyd(bool slow, int tiempo)
        {
            List<List<int>> matrix;
            matrix = grafo.floyd_warshall(slow, tiempo);
            grafo.cargarImagen();
            Form15 formulon = new Form15();
            formulon.matix = matrix;
            formulon.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            n++;
            List<int> tiempos = new List<int>();
            Vertice<int, int> nodulon = new Vertice<int, int>(0, 1100, 700);
            Stopwatch sw = new Stopwatch();

            sw.Start();
            grafo.BFS(grafo.getInicio(), false, 0);
            sw.Stop();
            tiempos.Add(Convert.ToInt32(sw.ElapsedMilliseconds));
            sw.Reset();

            sw.Start();
            grafo.DFS(grafo.getInicio(), false, 0);
            sw.Stop();
            tiempos.Add(Convert.ToInt32(sw.ElapsedMilliseconds));
            sw.Reset();

            sw.Start();
            grafo.prim(false, 0);
            sw.Stop();
            tiempos.Add(Convert.ToInt32(sw.ElapsedMilliseconds));
            sw.Reset();

            sw.Start();
            grafo.kruskal(false, 0);
            sw.Stop();
            tiempos.Add(Convert.ToInt32(sw.ElapsedMilliseconds));
            sw.Reset();

            sw.Start();
            grafo.dijkstra(grafo.getInicio(), false, 0);
            sw.Stop();
            tiempos.Add(Convert.ToInt32(sw.ElapsedMilliseconds));
            sw.Reset();

            sw.Start();
            grafo.floyd_warshall(false, 0);
            sw.Stop();
            tiempos.Add(Convert.ToInt32(sw.ElapsedMilliseconds));
            sw.Reset();

            sw.Start();
            grafo.insertar_vertice(nodulon, 1100, 700);
            sw.Stop();
            tiempos.Add(Convert.ToInt32(sw.ElapsedMilliseconds));
            sw.Reset();

            sw.Start();
            grafo.insertar_aritsta(grafo.getInicio(), nodulon, 1);
            sw.Stop();
            tiempos.Add(Convert.ToInt32(sw.ElapsedMilliseconds));
            sw.Reset();

            sw.Start();
            grafo.elimina_arista(grafo.getInicio(), nodulon);
            sw.Stop();
            tiempos.Add(Convert.ToInt32(sw.ElapsedMilliseconds));
            sw.Reset();

            sw.Start();
            grafo.elimina_vertice(nodulon, false, 0);
            sw.Stop();
            tiempos.Add(Convert.ToInt32(sw.ElapsedMilliseconds));
            sw.Reset();

            Form17 formulon = new Form17();
            formulon.tiempos = tiempos;
            formulon.i = n;
            formulon.Show();
        }
    }
}
