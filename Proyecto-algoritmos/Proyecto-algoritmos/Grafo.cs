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
       private int num_nodos;
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

       public int Num_Nodos
       {
           get { return num_nodos; }
           set { num_nodos = value; }
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
           num_nodos++;
           trazo.MidPointCircle(x, y, 25, Color.White);
           num.crea_numero(x, y, posicion_vertice(v) + 1, Color.White);

       }

       public void insertar_aritsta(Vertice<V, A> o, Vertice<V, A> d, A peso)
       {
           if(o != null && d != null)
           {
               Arista<V, A> nueva = new Arista<V, A>(peso, d);
               o.insertar_arista(nueva);

               bool noEsta = false;
               Arista<V, A> a = d.getArista();

               while(a != null)
               {
                   //if(!EqualityComparer<V>.Default.Equals(temp.getInfo(), info))
                   if(a.getDestino() == o)
                   {
                       noEsta = true;
                       break;
                   }
                   a = a.getNext();
               }

               if(!noEsta)
                    pinta_arista(o, d, nueva, peso,0, Color.White, Color.Blue);
               else
               {
                   pinta_arista(d, o, nueva, a.getPeso(),0, Color.Black, Color.Black);

                   if (o.X > d.X)
                   {
                       if (o.Y > d.Y)
                       {
                           pinta_arista(d, o, nueva, a.getPeso(), 5, Color.White, Color.Green);
                           pinta_arista(o, d, nueva, peso, -5, Color.White, Color.Yellow);
                       }
                       else
                       {
                           pinta_arista(d, o, nueva, a.getPeso(), -5, Color.White, Color.Green);
                           pinta_arista(o, d, nueva, peso, 5, Color.White, Color.Yellow);
                       }
                   }
                   else
                   {
                       if (o.Y > d.Y)
                       {
                           pinta_arista(d, o, nueva, a.getPeso(), -5, Color.White, Color.Green);
                           pinta_arista(o, d, nueva, peso, 5, Color.White, Color.Yellow);
                       }
                       else
                       {
                           pinta_arista(d, o, nueva, a.getPeso(), 5, Color.White, Color.Green);
                           pinta_arista(o, d, nueva, peso, -5, Color.White, Color.Yellow);
                       }
                   }
               }
           }


       }

       private void pinta_arista(Vertice<V, A> o, Vertice<V, A> d, Arista<V, A> nueva, A peso,int desviacion, Color pinta, Color color_flecha)
       {
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
               double xx = Math.Sin(angulo) * 32;
               double yy = Math.Cos(angulo) * 32;
               double desvX = Math.Cos(angulo) * desviacion;
               double desvY = Math.Sin(angulo) * desviacion;
               nueva.Angulo = angulo;
               if (o.Y < d.Y)
               {
                   trazo.BresenhamLine(o.X + Convert.ToInt32(x) + Convert.ToInt32(desvX), o.Y + Convert.ToInt32(y) - Convert.ToInt32(desvY), d.X - Convert.ToInt32(x) + Convert.ToInt32(desvX), d.Y - Convert.ToInt32(y) - Convert.ToInt32(desvY), pinta);
                   num.crea_numero(px + Convert.ToInt32(pmx) + Convert.ToInt32(desvX), py - Convert.ToInt32(pmy) - Convert.ToInt32(desvY), Convert.ToInt32(peso), color_flecha);
                   nueva.OX = o.X + Convert.ToInt32(x) + Convert.ToInt32(desvX);
                   nueva.OY = o.Y + Convert.ToInt32(y) - Convert.ToInt32(desvY);
                   nueva.DX = d.X - Convert.ToInt32(x) + Convert.ToInt32(desvX);
                   nueva.DY = d.Y - Convert.ToInt32(y) - Convert.ToInt32(desvY);
                   trazo.circulo_relleno(d.X - Convert.ToInt32(xx) + Convert.ToInt32(desvX), d.Y - Convert.ToInt32(yy) - Convert.ToInt32(desvY), 7, color_flecha);
               }
               else
               {
                   trazo.BresenhamLine(o.X - Convert.ToInt32(x) + Convert.ToInt32(desvX), o.Y - Convert.ToInt32(y) - Convert.ToInt32(desvY), d.X + Convert.ToInt32(x) + Convert.ToInt32(desvX), d.Y + Convert.ToInt32(y) - Convert.ToInt32(desvY), pinta);
                   num.crea_numero(px - Convert.ToInt32(pmx) + Convert.ToInt32(desvX), py + Convert.ToInt32(pmy) - Convert.ToInt32(desvY), Convert.ToInt32(peso), color_flecha);
                   nueva.OX = o.X - Convert.ToInt32(x) + Convert.ToInt32(desvX);
                   nueva.OY = o.Y - Convert.ToInt32(y) - Convert.ToInt32(desvY);
                   nueva.DX = d.X + Convert.ToInt32(x) + Convert.ToInt32(desvX);
                   nueva.DY = d.Y + Convert.ToInt32(y) - Convert.ToInt32(desvY);
                   trazo.circulo_relleno(d.X + Convert.ToInt32(xx) + Convert.ToInt32(desvX), d.Y + Convert.ToInt32(yy) - Convert.ToInt32(desvY), 7, color_flecha);
               }


           }
           else if (d.X > o.X)
           {
               trazo.BresenhamLine(o.X + 25, o.Y+desviacion, d.X - 25, d.Y+desviacion, pinta);

               num.crea_numero(px, py - 20 + desviacion, Convert.ToInt32(peso), color_flecha);

               nueva.OX = o.X + 25;
               nueva.OY = o.Y;
               nueva.DX = d.X - 25;
               nueva.DY = d.Y;
               nueva.Angulo = -Math.PI;
               trazo.circulo_relleno(d.X - 32, d.Y+desviacion, 7, color_flecha);
           }
           else
           {
               trazo.BresenhamLine(o.X - 25, o.Y+desviacion, d.X + 25, d.Y+desviacion, pinta);
               num.crea_numero(px, py + 20+desviacion, Convert.ToInt32(peso), color_flecha);

               nueva.OX = o.X - 25;
               nueva.OY = o.Y;
               nueva.DX = d.X + 25;
               nueva.DY = d.Y;
               nueva.Angulo = 0.0;
               trazo.circulo_relleno(d.X + 32, d.Y+desviacion, 7, color_flecha);
           }
       }

        public void pinta_arista(Arista<V, A> a, Color color, Color flecha)
       {
           trazo.BresenhamLine(a.OX, a.OY, a.DX, a.DY, color);
           num.crea_numero((a.OX + a.DX) / 2, (a.OY + a.DY) / 2, Convert.ToInt32(a.getPeso()), flecha);
           double xx = Math.Sin(a.Angulo) * 32;
           double yy = Math.Cos(a.Angulo) * 32;
           trazo.circulo_relleno(a.DX + Convert.ToInt32(xx), a.DY + Convert.ToInt32(yy), 7, flecha);
       }

       public void cambiar_posicion_vertice(int xt, int yt, Vertice<V, A> ver)
       {
           Vertice<V, A> v = ver;

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

        public  bool busqueda_arista(Vertice<V, A> o, Vertice<V, A> d)
        {
            Arista<V, A> a = o.getArista();
            bool esta = false;

            while(a != null)
            {
                if(a.getDestino() == d)
                {
                    esta = true;
                    break;    
                }

                a = a.getNext();
            }

            return esta;
        }

       public void cargarImagen()
       {
           trazo.setImage();
       }

        public void elimina_arista(Vertice<V, A> o, Vertice<V, A> d)
       {
           Arista<V, A> a = o.getArista();
           Arista<V, A> previo = null;
           bool esta = false;

           while (a != null && a.getDestino() != d)
           {
               previo = a;
               a = a.getNext();
           }
           
            if(a != null)
            {
                Arista<V, A> tempA = d.getArista();

                while (tempA != null)
               {
                   //if(!EqualityComparer<V>.Default.Equals(temp.getInfo(), info))
                   if (tempA.getDestino() == o)
                   {
                       esta = true;
                       break;
                   }
                   tempA = tempA.getNext();
               }

               if(!esta)
                    pinta_arista(o, d, a, a.getPeso(),0, Color.Black, Color.Black);
               else
               {
                   //pinta_arista(d, o, nueva, a.getPeso(),0, Color.Black, Color.Black);

                   if (o.X > d.X)
                   {
                       if (o.Y > d.Y)
                       {
                           pinta_arista(d, o, tempA, tempA.getPeso(), 5, Color.Black, Color.Black);
                           
                           pinta_arista(o, d, a, a.getPeso(), -5, Color.Black, Color.Black);
                           pinta_arista(d, o, tempA, tempA.getPeso(), 0, Color.White, Color.Blue);
                       }
                       else
                       {
                           pinta_arista(d, o, tempA, tempA.getPeso(), -5, Color.Black, Color.Black);
                           
                           pinta_arista(o, d, a, a.getPeso(), 5, Color.Black, Color.Black);
                           pinta_arista(d, o, tempA, tempA.getPeso(), 0, Color.White, Color.Blue);
                       }
                   }
                   else
                   {
                       if (o.Y > d.Y)
                       {
                           pinta_arista(d, o, tempA, tempA.getPeso(), -5, Color.Black, Color.Black);
                           
                           pinta_arista(o, d, a, a.getPeso(), 5, Color.Black, Color.Black);
                           pinta_arista(d, o, tempA, tempA.getPeso(), 0, Color.White, Color.Blue);
                       }
                       else
                       {
                           pinta_arista(d, o, tempA, tempA.getPeso(), 5, Color.Black, Color.Black);
                           
                           pinta_arista(o, d, a, a.getPeso(), -5, Color.Black, Color.Black);
                           pinta_arista(d, o, tempA, tempA.getPeso(), 0, Color.White, Color.Blue);
                       }
                   }
               }

               if (previo == null)
                   o.setAristas(a.getNext());
               else
               {
                   previo.setNext(a.getNext());
                   a.setNext(null);
               }

               //a = null;
           }

            
       }

       
    }
}
