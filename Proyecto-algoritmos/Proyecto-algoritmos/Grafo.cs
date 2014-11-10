using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace Proyecto_algoritmos
{
    class Grafo<V, A>
    {
       private Vertice<V, A> inicio;
       private int num_nodos { get; set; }
       private List<int> distancia;
       private List<int> visitados;
       private List<Vertice<V, A>> lista;
       private List<int> previo;
       public Computacional_Geometry trazo;
       private PictureBox imagen;
       private Numeros num;

       public Grafo()
       {
           inicio = null;
       }

       public  Grafo(PictureBox i)
       {
           inicio = null;
           imagen = i;
           trazo = new Computacional_Geometry(imagen,1170,730);
           num = new Numeros(trazo);
       }

        public void setImagen(PictureBox i)
       {
           imagen = i;
            trazo = new Computacional_Geometry(imagen, 1170, 730);
            num = new Numeros(trazo);
       }
        

       public void insertar_vertice(Vertice<V, A> v, int x, int y)
       {

           if (inicio == null)
               inicio = v;
           else 
           {
               Vertice<V, A> temp = inicio;
               while (temp.getNext() != null)
                   temp = temp.getNext();

               temp.setNext(v);
           }

           trazo.MidPointCircle(x, y, 25, Color.White);
           num.crea_numero(x, y, posicion_vertice(v) + 1, Color.White);

       }

       public void insertar_aritsta(Vertice<V, A> o, Vertice<V, A> d, A peso)
       {
           if(o != null && d != null)
           {
               Arista<V, A> nueva = new Arista<V, A>(peso, d);
               o.insertar_arista(nueva);
           }

           int dx = d.X - o.X;
           int dy = d.Y - o.Y;
           int px = (o.X + d.X) / 2;
           int py = (o.Y + d.Y) / 2;

           if (dy != 0)
           {
               double angulo = Math.Atan((dx) / (dy));
               double x = Math.Sin(angulo) * 25;
               double y = Math.Cos(angulo) * 25;
               double pmy = Math.Sin(angulo) * 25;
               double pmx = Math.Cos(angulo) * 36;
               if (o.Y < d.Y)
               {
                   trazo.BresenhamLine(o.X + Convert.ToInt32(x), o.Y + Convert.ToInt32(y), d.X - Convert.ToInt32(x), d.Y - Convert.ToInt32(y), Color.White);
                   num.crea_numero(px + Convert.ToInt32(pmx), py - Convert.ToInt32(pmy), Convert.ToInt32(peso), Color.Blue);
                   
                   
               }
               else
               {
                   trazo.BresenhamLine(o.X - Convert.ToInt32(x), o.Y - Convert.ToInt32(y), d.X + Convert.ToInt32(x), d.Y + Convert.ToInt32(y), Color.White);
                   num.crea_numero(px - Convert.ToInt32(pmx), py + Convert.ToInt32(pmy), Convert.ToInt32(peso), Color.Blue);
                   double tx = Math.Sin(angulo) * 10;
                   double ty = Math.Cos(angulo) * 10;
                   double otroX = Math.Sin(angulo) * 30;
                   double otroY = Math.Cos(angulo) * 30;
                   trazo.BresenhamLine(d.X + Convert.ToInt32(x) - Convert.ToInt32(tx), d.Y + Convert.ToInt32(y) + Convert.ToInt32(ty), d.X + Convert.ToInt32(x), d.Y + Convert.ToInt32(y), Color.Blue);
                   trazo.BresenhamLine(d.X + Convert.ToInt32(x) + Convert.ToInt32(tx), d.Y + Convert.ToInt32(y) + Convert.ToInt32(ty), d.X + Convert.ToInt32(x) - Convert.ToInt32(tx)*3, d.Y + Convert.ToInt32(y) + Convert.ToInt32(ty)*3, Color.Red);
               }

               
           }
           else if (d.X > o.X)
           {
               trazo.BresenhamLine(o.X + 25, o.Y, d.X - 25, d.Y, Color.White);

               num.crea_numero(px, py - 20, Convert.ToInt32(peso), Color.Blue);
           }
           else
           {
               trazo.BresenhamLine(o.X - 25, o.Y, d.X + 25, d.Y, Color.White);
               num.crea_numero(px, py + 20, Convert.ToInt32(peso), Color.Blue);
           }

           

       }

       public void cambiar_posicion_vertice(int xt, int yt, int i)
       {
           Vertice<V, A> v = vertice_en(i-1);

           trazo.MidPointCircle(v.X, v.Y, 25, Color.Black);
           num.crea_numero(v.X, v.Y, posicion_vertice(v) + 1, Color.Black);

           v.X = xt;
           v.Y = yt;

           trazo.MidPointCircle(v.X, v.Y, 25, Color.White);
           num.crea_numero(v.X, v.Y, posicion_vertice(v) + 1, Color.White);
       }

       public Vertice<V, A> vertice_en(int i)
       {
           int pos = 0;
           Vertice<V, A> temp = inicio;

           while(pos < i)
           {
               temp = temp.getNext();
               pos++;
           }

           return temp;
       }

       public int posicion_vertice(Vertice<V, A> v)
       {
           Vertice<V, A> temp = inicio;
           int cont = 0;

            while(temp != null && temp != v)
            {
                cont++;
                temp = temp.getNext();
            }

            return cont;
       }

       public bool detecta_posicion(int x, int y)
       {
           Vertice<V, A> temp = inicio;
           bool noEsta = true;

           while(temp != null)
           {
               if(((x+25 >= temp.X -25 && temp.X + 25 >= x+25) || (x-25 >= temp.X -25 && temp.X + 25 >= x-25)) &&  ((y+25 >= temp.Y-25 && temp.Y + 25 >= y+25) || (y-25 >= temp.Y-25 && temp.Y + 25 >= y-25)))
               {
                   noEsta = false;
                   break;
               }
               temp = temp.getNext();
           }

           return noEsta;
       }

        public Vertice<V, A> busqueda_vertice(V info)
       {
           Vertice<V, A> temp = inicio;

           while (!EqualityComparer<V>.Default.Equals(temp.getInfo(), info))
               temp = temp.getNext();

           return temp;
       }

       public void cargarImagen()
       {
           trazo.setImage();
       }
    }
}
