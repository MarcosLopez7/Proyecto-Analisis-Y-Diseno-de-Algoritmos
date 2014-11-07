using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_algoritmos
{
    class Arista<V, A>
    {
        A peso;
        Vertice<V, A> destino;
        Arista<V, A> siguiente;

        public Arista(A p, Vertice<V, A> d)
        {
            this.peso = p;
            this.destino = d;
            siguiente = null;
        }

        public A getPeso()
        {
            return peso;
        }

        public void setPeso(A value)
        {
            peso = value;
        }

        public Vertice<V, A> getDestino()
        {
            return destino;
        }

        public Arista<V, A> getNext()
        {
            return siguiente;
        }
        public void setNext(Arista<V, A> value)
        {
            siguiente = value;
        }
    }
}
