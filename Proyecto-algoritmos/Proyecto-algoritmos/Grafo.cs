using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Threading;

namespace Proyecto_algoritmos
{
    class Grafo<V, A>
    {
       private Vertice<V, A> inicio;
       private int num_nodos;
       private List<int> distancia;
       private List<bool> visitados;
       private List<Vertice<int, int>> lista;
       private List<int> cola; 
       private List<int> previo;
       public Computacional_Geometry trazo;
       private PictureBox imagen;
       private Numeros num;
       private List<bool> visitadoDFS;
       private List<bool> visitadoPrim;

       public Grafo()
       {
           inicio = null;
           visitadoDFS = new List<bool>();
           visitadoPrim = new List<bool>();
           distancia = new List<int>();
           visitados = new List<bool>();
           previo = new List<int>();
           cola = new List<int>();
       }

       public Vertice<V, A> getInicio()
       {
           return inicio;
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
           visitadoDFS = new List<bool>();
           visitadoPrim = new List<bool>();
           distancia = new List<int>();
           visitados = new List<bool>();
           previo = new List<int>();
           cola = new List<int>();
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
           num.crea_numero(x, y, Convert.ToInt32(v.getInfo()), Color.White);

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

               if (!noEsta)
               {
                   nueva.Primero = true;
                   pinta_arista(o, d, nueva, peso, 0, Color.White, Color.Blue);
               }
               else
               {
                   pinta_arista(d, o, nueva, a.getPeso(), 0, Color.Black, Color.Black);

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

       public void pinta_arista(Vertice<V, A> o, Vertice<V, A> d, Color w, Color b, Color g, Color y)
       {
           Arista<V, A> a = o.getArista();
           bool esta = false;

           while (a != null && a.getDestino() != d)
               a = a.getNext();
           

           if (a != null)
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

               if (!esta)
               {
                   a.Primero = true;
                   pinta_arista(o, d, a, a.getPeso(), 0, w, b);
               }
               else
               {
                   //pinta_arista(d, o, tempA, tempA.getPeso(),0, Color.Black, Color.Black);

                   if (o.X > d.X)
                   {
                       if (o.Y > d.Y)
                       {
                           if (!a.Primero)
                           {
                               pinta_arista(d, o, tempA, tempA.getPeso(), 5, w, g);

                               pinta_arista(o, d, a, a.getPeso(), -5, w, y);
                           }
                           else
                           {
                               pinta_arista(d, o, tempA, tempA.getPeso(), -5, w, g);

                               pinta_arista(o, d, a, a.getPeso(), 5, w, y);
                           }
                       }
                       else
                       {
                           if (!a.Primero || (o.Y - d.Y == 0))
                           {
                               pinta_arista(d, o, tempA, tempA.getPeso(), -5, w, g);
                               pinta_arista(o, d, a, a.getPeso(), 5, w, y);
                           }
                           else
                           {
                               pinta_arista(d, o, tempA, tempA.getPeso(), 5, w, g);
                               pinta_arista(o, d, a, a.getPeso(), -5, w, y);
                           }


                       }
                   }
                   else
                   {
                       if (o.Y > d.Y)
                       {
                           if (!a.Primero|| (o.X - d.X == 0))
                           {
                               pinta_arista(d, o, tempA, tempA.getPeso(), -5, w, g);
                               pinta_arista(o, d, a, a.getPeso(), 5, w, y);
                           }
                           else
                           {
                               pinta_arista(d, o, tempA, tempA.getPeso(), 5, w, g);
                               pinta_arista(o, d, a, a.getPeso(), -5, w, y);
                           }



                       }
                       else
                       {
                           if (!a.Primero || (o.Y - d.Y == 0)|| (o.X - d.X == 0))
                           {
                               pinta_arista(d, o, tempA, tempA.getPeso(), 5, w, g);
                               pinta_arista(o, d, a, a.getPeso(), -5, w, y);
                           }
                           else
                           {
                               pinta_arista(d, o, tempA, tempA.getPeso(), -5, w, g);
                               pinta_arista(o, d, a, a.getPeso(), 5, w, y);
                           }

                       }
                   }
               }

           }
       }

       public void pinta_arista(Vertice<V, A> o, Vertice<V, A> d, Color w, Color b, Color g, Color y, bool soloUno)
       {
           Arista<V, A> a = o.getArista();
           bool esta = false;

           while (a != null && a.getDestino() != d)
               a = a.getNext();


           if (a != null)
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

               if (!esta)
                   pinta_arista(o, d, a, a.getPeso(), 0, w, b);
               else
               {
                   //pinta_arista(d, o, tempA, tempA.getPeso(),0, Color.Black, Color.Black);

                   if (o.X > d.X)
                   {
                       if (o.Y > d.Y)
                       {
                           if (!a.Primero)
                           {
                               if(soloUno)
                               pinta_arista(d, o, tempA, tempA.getPeso(), 5, w, g);

                               pinta_arista(o, d, a, a.getPeso(), -5, w, y);
                           }
                           else
                           {
                               if (soloUno)
                               pinta_arista(d, o, tempA, tempA.getPeso(), -5, w, g);

                               pinta_arista(o, d, a, a.getPeso(), 5, w, y);
                           }
                       }
                       else
                       {
                           if (!a.Primero || (o.Y - d.Y == 0))
                           {
                               if (soloUno)
                               pinta_arista(d, o, tempA, tempA.getPeso(), -5, w, g);
                               pinta_arista(o, d, a, a.getPeso(), 5, w, y);
                           }
                           else
                           {
                               if (soloUno)
                               pinta_arista(d, o, tempA, tempA.getPeso(), 5, w, g);
                               pinta_arista(o, d, a, a.getPeso(), -5, w, y);
                           }


                       }
                   }
                   else
                   {
                       if (o.Y > d.Y)
                       {
                           if (!a.Primero || (o.X - d.X == 0))
                           {
                               if (soloUno)
                               pinta_arista(d, o, tempA, tempA.getPeso(), -5, w, g);
                               pinta_arista(o, d, a, a.getPeso(), 5, w, y);
                           }
                           else
                           {
                               if (soloUno)
                               pinta_arista(d, o, tempA, tempA.getPeso(), 5, w, g);
                               pinta_arista(o, d, a, a.getPeso(), -5, w, y);
                           }



                       }
                       else
                       {
                           if (!a.Primero || (o.Y - d.Y == 0) || (o.X - d.X == 0))
                           {
                               if (soloUno)
                               pinta_arista(d, o, tempA, tempA.getPeso(), 5, w, g);
                               pinta_arista(o, d, a, a.getPeso(), -5, w, y);
                           }
                           else
                           {
                               if (soloUno)
                               pinta_arista(d, o, tempA, tempA.getPeso(), -5, w, g);
                               pinta_arista(o, d, a, a.getPeso(), 5, w, y);
                           }

                       }
                   }
               }

           }
       }

       public void cambiar_posicion_vertice(int xt, int yt, Vertice<V, A> ver, bool slow, int tiempo)
       {

           Vertice<V, A> temp = inicio;
           Vertice<V, A> v = ver;
           Arista<V, A> a;

           while (temp != null)
           {
               a = temp.getArista();
               if (temp == v)
               {
                   if (a != null)
                   {

                       while (a != null)
                       {
                           pinta_arista(temp, a.getDestino(), Color.Black, Color.Black, Color.Black, Color.Black);
                           a = a.getNext();
                           slow_motion(slow, tiempo);
                       }
                   }
               }
               else
               {
                   if (a != null)
                   {

                       while (a != null)
                       {
                           if (a.getDestino() == v)
                           {
                               pinta_arista(temp, a.getDestino(), Color.Black, Color.Black, Color.Black, Color.Black);
                               slow_motion(slow, tiempo);
                           }
                           a = a.getNext();
                       }
                   }
               }

               temp = temp.getNext();
           }

           trazo.MidPointCircle(v.X, v.Y, 25, Color.Black);
           num.crea_numero(v.X, v.Y, Convert.ToInt32(v.getInfo()), Color.Black);

           v.X = xt;
           v.Y = yt;

           trazo.MidPointCircle(v.X, v.Y, 25, Color.White);
           num.crea_numero(v.X, v.Y, Convert.ToInt32(v.getInfo()), Color.White);

            temp = inicio;

           while (temp != null)
           {
               a = temp.getArista();
               if (temp == v)
               {
                   if (a != null)
                   {

                       while (a != null)
                       {
                           pinta_arista(temp, a.getDestino(), Color.White, Color.Blue, Color.Green, Color.Yellow);
                           a = a.getNext();
                           slow_motion(slow, tiempo);
                       }
                   }
               }
               else
               {
                   if (a != null)
                   {

                       while (a != null)
                       {
                           if (a.getDestino() == v)
                           {
                               pinta_arista(temp, a.getDestino(), Color.White, Color.Blue, Color.Green, Color.Yellow);
                               slow_motion(slow, tiempo);
                           }
                           a = a.getNext();
                       }
                   }
               }

               temp = temp.getNext();
           }
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
                           if (!a.Primero)
                           {
                               pinta_arista(d, o, tempA, tempA.getPeso(), 5, Color.Black, Color.Black);

                               pinta_arista(o, d, a, a.getPeso(), -5, Color.Black, Color.Black);
                           }
                           else
                           {
                               pinta_arista(d, o, tempA, tempA.getPeso(), -5, Color.Black, Color.Black);

                               pinta_arista(o, d, a, a.getPeso(), 5, Color.Black, Color.Black);
                           }
                           pinta_arista(d, o, tempA, tempA.getPeso(), 0, Color.White, Color.Blue);
                           tempA.Primero = true;
                       }
                       else
                       {
                           if (!a.Primero || (o.Y - d.Y == 0))
                           {
                               pinta_arista(d, o, tempA, tempA.getPeso(), -5, Color.Black, Color.Black);
                               pinta_arista(o, d, a, a.getPeso(), 5, Color.Black, Color.Black);
                           }
                           else
                           {
                               pinta_arista(d, o, tempA, tempA.getPeso(), 5, Color.Black, Color.Black);
                               pinta_arista(o, d, a, a.getPeso(), -5, Color.Black, Color.Black);
                           }

                           pinta_arista(d, o, tempA, tempA.getPeso(), 0, Color.White, Color.Blue);
                           tempA.Primero = true;
                       }
                   }
                   else
                   {
                       if (o.Y > d.Y )
                       {
                           if (!a.Primero || (o.X - d.X == 0))
                           {
                               pinta_arista(d, o, tempA, tempA.getPeso(), -5, Color.Black, Color.Black);
                               pinta_arista(o, d, a, a.getPeso(), 5, Color.Black, Color.Black);
                           }
                           else
                           {
                               pinta_arista(d, o, tempA, tempA.getPeso(), 5, Color.Black, Color.Black);
                               pinta_arista(o, d, a, a.getPeso(), -5, Color.Black, Color.Black);
                           }
                           

                           pinta_arista(d, o, tempA, tempA.getPeso(), 0, Color.White, Color.Blue);
                           tempA.Primero = true;
                       }
                       else
                       {
                           if (!a.Primero || (o.Y - d.Y == 0) || (o.X - d.X == 0))
                           {
                               pinta_arista(d, o, tempA, tempA.getPeso(), 5, Color.Black, Color.Black);
                               pinta_arista(o, d, a, a.getPeso(), -5, Color.Black, Color.Black);
                           }
                           else
                           {
                               pinta_arista(d, o, tempA, tempA.getPeso(), -5, Color.Black, Color.Black);
                               pinta_arista(o, d, a, a.getPeso(), 5, Color.Black, Color.Black);
                           }

                           pinta_arista(d, o, tempA, tempA.getPeso(), 0, Color.White, Color.Blue);
                           tempA.Primero = true;
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

               a = null;
           }

       }

        public void elimina_vertice(Vertice<V, A> v, bool slow, int tiempo)
        {
            Vertice<V, A> temp = inicio;
            Vertice<V, A> previo = null;
            Arista<V, A> a;

            while(temp != null)
            {
                a = temp.getArista();
                if(temp == v)
                {
                    if(a != null)
                    {
                        Arista<V, A> tempA = a;

                        while(tempA != null)
                        {
                            a = a.getNext();
                            elimina_arista(temp, tempA.getDestino());
                            tempA = null;
                            tempA = a;
                            slow_motion(slow, tiempo);
                        }
                    }
                }
                else
                {
                    if (a != null)
                    {
                        Arista<V, A> tempA = a;

                        while (tempA != null)
                        {
                            a = a.getNext();
                            if(tempA.getDestino() == v)
                            {
                                elimina_arista(temp, tempA.getDestino());
                                tempA = null;
                                slow_motion(slow, tiempo);
                            }
                            tempA = a;
                        }
                    }
                }

                temp = temp.getNext();
            }

            trazo.MidPointCircle(v.X, v.Y, 25, Color.Black);
            num.crea_numero(v.X, v.Y, Convert.ToInt32(v.getInfo()), Color.Black);

            temp = inicio;

            while(temp.getNext() != null && temp != v)
            {
                previo = temp;
                temp = temp.getNext();
            }

            if (previo == null)
                inicio = temp.getNext();
            else
            {
                previo.setNext(temp.getNext());
                temp.setNext(null);
                temp = null;
            }
            num_nodos--;
        }

        public void BFS(Vertice<V, A> v, bool slow, int tiempo)
        {

            List<bool> visitado = new List<bool>();
            Queue<Vertice<V, A>> q = new Queue<Vertice<V,A>>();
            Vertice<V, A> u;
            Arista<V, A> a;
            Vertice<V, A> n;

            for (int i = 0; i < num_nodos; i++)
                visitado.Add(false);

            visitado[posicion_vertice(v)] = true;
            q.Enqueue(v);

            while(q.Count != 0)
            {
                u = q.Dequeue();
                a = u.getArista();
                trazo.MidPointCircle(u.X, u.Y, 25, Color.Yellow);
                slow_motion(slow, tiempo);

                while (a != null)
                {
                    n = a.getDestino();
                    if (visitado[posicion_vertice(n)] == false)
                    {
                        visitado[posicion_vertice(n)] = true;
                        pinta_arista(u, n, Color.Red, Color.White, Color.White, Color.White, false);
                        trazo.MidPointCircle(n.X, n.Y, 25, Color.Red);
                        q.Enqueue(n);
                    }
                    else
                        pinta_arista(u, n, Color.Gray, Color.Gray, Color.Gray, Color.Gray, false);

                        slow_motion(slow, tiempo);
                        a = a.getNext();
                }
                trazo.MidPointCircle(u.X, u.Y, 25, Color.Red);

            }

            if(slow)
                Thread.Sleep(2000);

            restaura_arista();

        }



        public void DFS(Vertice<V, A> v, bool slow, int tiempo)
        {

            visitadoDFS.Clear();
           
            for (int i = 0; i < num_nodos; i++)
                visitadoDFS.Add(false);
           

            dfs(v, slow, tiempo);

            if(slow)
            Thread.Sleep(3000);
            restaura_arista();
        }

        private void dfs(Vertice<V, A> v, bool slow, int tiempo)
        {

            visitadoDFS[posicion_vertice(v)] = true;
            Arista<V, A> a = v.getArista();
            Vertice<V, A> w;
            trazo.MidPointCircle(v.X, v.Y, 25, Color.Yellow);
            slow_motion(slow, tiempo);
            while(a != null)
            {
                w = a.getDestino();
                if (!visitadoDFS[posicion_vertice(w)])
                {
                    pinta_arista(v, w, Color.Red, Color.White, Color.White, Color.White, false);
                    trazo.MidPointCircle(v.X, v.Y, 25, Color.Red);
                    slow_motion(slow, tiempo);
                    dfs(w, slow, tiempo);
                    trazo.MidPointCircle(v.X, v.Y, 25, Color.Yellow);
                    slow_motion(slow, tiempo);
                }
                else
                {
                    pinta_arista(v, w, Color.Gray, Color.Gray, Color.Gray, Color.Gray, false);
                    slow_motion(slow, tiempo);
                }

                a = a.getNext();
            }
            trazo.MidPointCircle(v.X, v.Y, 25, Color.Red);
            slow_motion(slow, tiempo);
        }

        public void restaura_arista()
        {

            Vertice<V, A> temp = inicio;
           Arista<V, A> a;

           while (temp != null)
           {
               a = temp.getArista();

              while (a != null)
              {
                  pinta_arista(temp, a.getDestino(), Color.White, Color.Blue, Color.Green, Color.Yellow);
                  a = a.getNext();
              }
              trazo.MidPointCircle(temp.X, temp.Y, 25, Color.White);
              temp = temp.getNext();
           }

           cargarImagen();

        }

        public List<List<int>> prim(bool slow, int tiempo)
        {
            Form18 f = new Form18();

            List<List<int>> matrix = new List<List<int>>();
            Vertice<V, A> v;
            Arista<V, A> a;

            for(int i = 0; i < num_nodos; i++)
            {
                List<int> aux = new List<int>();
                aux.Add(i + 1);
                aux.Add(10000);
                aux.Add(-1);
                matrix.Add(aux);
            }

            visitadoPrim.Clear();

                for (int i = 0; i < num_nodos; i++)
                    visitadoPrim.Add(false);
            

            matrix[0][1] = 0;
            f.matix = matrix;
            f.Show();
            f.Refresh();

            for(int i = 1; i < num_nodos + 1; i++)
            {

                int pos = minimoPrim(matrix, slow, tiempo);
                v = vertice_en(pos);

                if (pos != 0)
                {
                    pinta_arista(vertice_en(matrix[pos][2] - 1), vertice_en(pos), Color.Red, Color.White, Color.White, Color.White, false);
                    slow_motion(slow, tiempo);
                }

                trazo.MidPointCircle(v.X, v.Y, 25, Color.Yellow);
                slow_motion(slow, tiempo);
                a = v.getArista();

                Arista<V, A> tempA = a;

                while(tempA != null)
                {
                    pinta_arista(v, tempA.getDestino(), Color.Gray, Color.Gray, Color.Gray, Color.Gray, false);
                    tempA = tempA.getNext();
                }
                int minimo = 0;
                while(a != null)
                {

                    if(!visitadoPrim[posicion_vertice(a.getDestino())] && Convert.ToInt32(a.getPeso()) < matrix[posicion_vertice(a.getDestino())][1])
                    {
                        
                        matrix[posicion_vertice(a.getDestino())][2] = pos + 1;
                        matrix[posicion_vertice(a.getDestino())][1] = Convert.ToInt32(a.getPeso());
                        minimo = Convert.ToInt32(a.getPeso());
                    }
                    /*else
                    {
                        if(visitadoPrim[posicion_vertice(a.getDestino())])
                        {
                            pinta_arista(v, a.getDestino(), Color.Gray, Color.Gray, Color.Gray, Color.Gray, false);
                            slow_motion(slow, tiempo);
                        }
                    }*/
                    f.matix = matrix;
                    f.carga();
                    f.Refresh();
                    slow_motion(slow, tiempo);
                    a = a.getNext();
                }
                trazo.MidPointCircle(v.X, v.Y, 25, Color.Red);
                slow_motion(slow, tiempo);
            }

            f.Close();
            if(slow)
            Thread.Sleep(5000);
            restaura_arista();
            return matrix;

        }

        private int minimoPrim(List<List<int>> l, bool slow, int tiempo)
        {

            int minimo = 10000;
            int pos = 0;

            for(int i = 0; i < num_nodos; i++)
            {
                if(!visitadoPrim[i] && l[i][1] < minimo)
                {
                    minimo = l[i][1];
                    pos = i;
                }
            }

           
            visitadoPrim[pos] = true;
            return pos;
        }

        public List<List<int>> kruskal(bool slow, int tiempo)
        {
            Vertice<V, A> tempv = inicio;
            Arista<V, A> av;

            while (tempv != null)
            {
                av = tempv.getArista();

                while (av != null)
                {
                    pinta_arista(tempv, av.getDestino(), Color.Gray, Color.Gray, Color.Gray, Color.Gray);
                    av = av.getNext();
                }
                tempv = tempv.getNext();
            }

            cargarImagen();

            List<List<int>> arbol = new List<List<int>>();
            List<int> pertenece = new List<int>();

            for(int i = 0; i < num_nodos; i++)
            {
                List<int> aux = new List<int>();
                for (int j = 0; j < num_nodos; j++)
                    aux.Add(0);
                arbol.Add(aux);
                pertenece.Add(i);
            }

            Vertice<V, A> vA = null;
            Vertice<V, A> vB = null;
            Vertice<V, A> temp;
            Arista<V, A> a;
            int arcos = 1;

            Form19 f = new Form19();
            f.matix = arbol;
            f.Show();
            f.Refresh();

            while(arcos < num_nodos)
            {
                int min = 10000;
                temp = inicio;

                while(temp != null)
                {
                    a = temp.getArista();
                    while(a != null)
                    {
                        if(min > Convert.ToInt32(a.getPeso()) && pertenece[posicion_vertice(temp)] != pertenece[posicion_vertice(a.getDestino())])
                        {
                            min = Convert.ToInt32(a.getPeso());
                            vA = temp;
                            vB = a.getDestino();
                        }

                        a = a.getNext();
                    }

                    temp = temp.getNext();
                }

                pinta_arista(vA, vB, Color.Red, Color.White, Color.White, Color.White, false);
                trazo.MidPointCircle(vA.X, vA.Y, 25, Color.Red);
                trazo.MidPointCircle(vB.X, vB.Y, 25, Color.Red);
                f.matix = arbol;
                f.carga();
                f.Refresh();
                slow_motion(slow, tiempo);

                if(pertenece[posicion_vertice(vA)] != pertenece[posicion_vertice(vB)])
                {
                    arbol[posicion_vertice(vA)][posicion_vertice(vB)] = min;
                    arbol[posicion_vertice(vB)][posicion_vertice(vA)] = min;

                    int it = pertenece[posicion_vertice(vB)];
                    pertenece[posicion_vertice(vB)] = pertenece[posicion_vertice(vA)];
                    
                    for(int i = 0; i < num_nodos; i++)
                    {
                        if (pertenece[i] == it)
                            pertenece[i] = pertenece[posicion_vertice(vA)];
                    }

                    arcos++;
                }

            }

            f.Close();
            if(slow)
            Thread.Sleep(5000);
            restaura_arista();
            return arbol;
        }

        /*public List<int> dijkstra(Vertice<V, A> i, Grafo<int, int> grafito)
        {
            iniciar();
            Vertice<int, int> vertice = new Vertice<int, int>(posicion_vertice(i), 0, i.X, i.Y);
            lista.Add(vertice);

            distancia[posicion_vertice(i)] = 0;

            int actual, adyacente, peso;
            Vertice<int, int> temp;

            while(lista.Count != 0)
            {
                lista.Sort();
                actual = lista[0].getInfo();
                temp = lista[0];
                lista.RemoveAt(0);
                grafito.trazo.MidPointCircle(vertice_en(temp).X, vertice_en(temp).Y, 25, Color.Red);


                if (visitados[actual])
                    continue;
                visitados[actual] = true;
                Arista<int, int> tempA = temp.getArista();

                for(int j = 0; j < temp.numeroAristas(temp); j++)
                {
                    adyacente = grafito.posicion_vertice(tempA.getDestino());
                    peso = tempA.getPeso();
                    if (!visitados[adyacente])
                        relajacion(actual, adyacente, peso);
                    tempA = tempA.getNext();
                }
            }

            return distancia;

        }*/

        public List<int> dijkstra(Vertice<V, A> i, bool slow, int tiempo)
        {
            Form20 f = new Form20();
            iniciar();
            Vertice<V, A> vertice = i;
            cola.Add(posicion_vertice(vertice));

            distancia[posicion_vertice(i)] = 0;

            int actual, adyacente, peso;
            Vertice<V, A> temp;

            while (cola.Count != 0)
            {
                cola.Sort();
                temp = vertice_en(cola[0]);
                actual = posicion_vertice(temp);
                cola.RemoveAt(0);
                trazo.MidPointCircle(temp.X, temp.Y, 25, Color.Red);
                slow_motion(slow, tiempo);

                if(distancia[posicion_vertice(temp)] != 0)
                {
                    pinta_arista(vertice_en(previo[posicion_vertice(temp)]), temp, Color.Red, Color.White, Color.White, Color.White, false);
                    slow_motion(slow, tiempo);
                }

                if (visitados[actual])
                    continue;
                visitados[actual] = true;
                Arista<V, A> tempA = temp.getArista();

                for (int j = 0; j < temp.numeroAristas(temp); j++)
                {
                    adyacente = posicion_vertice(tempA.getDestino());
                    peso = Convert.ToInt32(tempA.getPeso());
                    if (!visitados[adyacente])
                        relajacion(actual, adyacente, peso, slow, tiempo);
                    tempA = tempA.getNext();
                }
            }

            if(slow)
            Thread.Sleep(5000);
            restaura_arista();
            return distancia;

        }

        private void iniciar()
        {
                distancia.Clear();
                visitados.Clear();
                previo.Clear();
            

            for(int i = 0; i < num_nodos; i++)
            {
                distancia.Add(10000);
                visitados.Add(false);
                previo.Add(-1);
            }
        }

        private void relajacion(int actual, int adyacencia, int p, bool slow, int tiempo)
        {
            if(distancia[actual] + p < distancia[adyacencia])
            {
                distancia[adyacencia] = distancia[actual] + p;
                previo[adyacencia] = actual;
                Vertice<V, A> ver = vertice_en(adyacencia);
                pinta_arista(vertice_en(actual), ver, Color.Gray, Color.Gray, Color.Gray, Color.Gray, false);
                slow_motion(slow, tiempo);
                cola.Add(adyacencia);
            }
        }

        public List<List<int>> floyd_warshall(bool slow, int tiempo)
        {
            Form21 f = new Form21();
            Vertice<V, A> tempv = inicio;
            Arista<V, A> av;

            while (tempv != null)
            {
                av = tempv.getArista();

                while (av != null)
                {
                    pinta_arista(tempv, av.getDestino(), Color.Gray, Color.Gray, Color.Gray, Color.Gray);
                    av = av.getNext();
                }
                tempv = tempv.getNext();
            }

            cargarImagen();

            List<List<int>> distancias = new List<List<int>>();
            Vertice<V, A> v = inicio;

            for(int i = 0; i < num_nodos; i++)
            {
                trazo.MidPointCircle(v.X, v.Y, 25, Color.Yellow);
                slow_motion(slow, tiempo);
                List<int> temp = new List<int>();
                Vertice<V, A> aux = inicio;
                for(int j = 0; j < num_nodos; j++)
                {
                    trazo.MidPointCircle(aux.X, aux.Y, 25, Color.Red);
                    slow_motion(slow, tiempo);

                    if (i == j)
                        temp.Add(0);
                    else
                    {
                        Arista<V, A> a = v.getArista();

                        while (a != null && a.getDestino() != aux)
                            a = a.getNext();

                        if (a == null)
                            temp.Add(10000);
                        else
                        {
                            pinta_arista(aux, a.getDestino(), Color.Red, Color.White, Color.White, Color.White, false);
                            slow_motion(slow, tiempo);
                            temp.Add(Convert.ToInt32(a.getPeso()));
                            pinta_arista(aux, a.getDestino(), Color.Gray, Color.Gray, Color.Gray, Color.Gray, false);
                        }
                    }
                    trazo.MidPointCircle(aux.X, aux.Y, 25, Color.White);
                    aux = aux.getNext();
                }

                distancias.Add(temp);
                trazo.MidPointCircle(v.X, v.Y, 25, Color.White);
                v = v.getNext();

            }

            for(int i = 0; i < distancias.Count; i++)
            {
                trazo.MidPointCircle(vertice_en(i).X, vertice_en(i).Y, 25, Color.Yellow);
                slow_motion(slow, tiempo);
                for(int j = 0; j < distancias.Count; j++)
                {
                    trazo.MidPointCircle(vertice_en(j).X, vertice_en(j).Y, 25, Color.Red);
                    slow_motion(slow, tiempo);
                    for (int k = 0; k < distancias.Count; k++)
                    {
                        trazo.MidPointCircle(vertice_en(k).X, vertice_en(k).Y, 25, Color.Blue);
                        slow_motion(slow, tiempo);
                        if (distancias[i][j] > distancias[i][k] + distancias[k][j])
                            distancias[i][j] = distancias[i][k] + distancias[k][j];
                        trazo.MidPointCircle(vertice_en(k).X, vertice_en(k).Y, 25, Color.White);
                    }
                    trazo.MidPointCircle(vertice_en(j).X, vertice_en(j).Y, 25, Color.White);
                }
                trazo.MidPointCircle(vertice_en(i).X, vertice_en(i).Y, 25, Color.White);
            }


            if(slow)
            Thread.Sleep(5000);
            restaura_arista();
            return distancias;

        }

        public void slow_motion(bool si, int tiempo)
        {
            if (si)
            {
                Thread.Sleep(tiempo);
                cargarImagen();
            }
        }

        public void paso_a_paso(bool si)
        {

        }
       
    }
}
