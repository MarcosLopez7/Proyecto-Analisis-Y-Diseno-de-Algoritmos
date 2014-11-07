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
       private Computacional_Geometry trazo;
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

       public void cargarImagen()
       {
           trazo.setImage();
       }
    }
}
