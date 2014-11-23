using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_algoritmos
{
    class Vertice<V, A>
    {
        V info;
        V info2;
        private int x;
       private int y   {get; set;}
        private Vertice<V, A> siguiente;
        private Arista<V, A> aristas;

        public Vertice(V info, int laX, int laY)
        {
            this.info = info;
            siguiente = null;
            aristas = null;
            this.x = laX;
            this.y = laY;
        }

        public Vertice(V info, V info2, int laX, int laY)
        {
            this.info = info;
            this.info2 = info2;
            siguiente = null;
            aristas = null;
            this.x = laX;
            this.y = laY;
        }

        public int X
        {
            get { return x;}
            set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public V getInfo()
        {
            return info;
        }

        public void setInfo(V value)
        {
            info = value;
        }

        public Vertice<V, A> getNext()
        {
            return siguiente;
        }

        public void setNext(Vertice<V, A> value)
        {
            siguiente = value;
        }

        public Arista<V, A> getArista()
        {
            return aristas;
        }

        public void setAristas(Arista<V, A> value)
        {
            aristas = value;
        }

        public void destruir()
        {
            if (aristas != null)
            {
                Arista<V, A> temp = aristas;

                while (temp != null)
                {
                    aristas = aristas.getNext();
                    temp = null;
                    temp = aristas;
                }
            }
        }

        public Arista<V, A> ultima_arista()
        {
            Arista<V, A> temp = aristas;

            if (temp != null)
            {
                while (temp.getNext() != null)
                    temp = temp.getNext();
            }

            return temp;
        }

        public void insertar_arista(Arista<V, A> a)
        {
            Arista<V, A> temp = ultima_arista();

            if (temp == null)
                aristas = a;
            else
                temp.setNext(a);
        }

        public int numeroAristas(Vertice<V, A> v)
        {
            Arista<V, A> temp = aristas;
            int cont = 0;

            while (temp != null)
            {
                temp = temp.getNext();
                cont++;
            }

            return cont;
        }

        public int posicion_arista(Arista<V, A> a)
        {
            Arista<V, A> temp = aristas;
            int cont = 0;

            while (temp != null && temp != a)
            {
                temp = temp.getNext();
                cont++;
            }

            return cont;
        }

    }
}