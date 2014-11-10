using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;

namespace Proyecto_algoritmos
{
    class Numeros
    {
        private Computacional_Geometry trazo;
        public Numeros(Computacional_Geometry t)
        {
            trazo = t;
        }

        public void crea_numero(int x, int y, int n, Color color)
        {

            switch (n) 
            {
                case 1: uno(x, y, color);
                    break;
                case 2: dos(x, y, color);
                    break;
                case 3: tres(x, y, color);
                    break;
                case 4: cuatro(x, y, color);
                    break;
                case 5: cinco(x, y, color);
                    break;
                case 6: seis(x, y, color);
                    break;
                case 7: siete(x, y, color);
                    break;
                case 8: ocho(x, y, color);
                    break;
                case 9: nueve(x, y, color);
                    break;
                default: mas_diez(x, y,n, color);
                    break;
            }

        }

        private void uno(int x, int y, Color color)
        {
            trazo.DDALine(x, y - 15, x, y + 15, color);
        }

        private void dos(int x, int y, Color color)
        {
            trazo.DDALine(x - 8, y - 15, x + 8, y - 15, color);
            trazo.DDALine(x + 8, y - 15, x + 8, y, color);
            trazo.DDALine(x - 8, y, x + 8, y, color);
            trazo.DDALine(x - 8, y, x - 8, y + 15, color);
            trazo.DDALine(x - 8, y + 15, x + 8, y + 15, color);
        }

        private void tres(int x, int y, Color color)
        {
            trazo.DDALine(x + 8, y - 15, x + 8, y + 15, color);
            trazo.DDALine(x - 8, y - 15, x + 8, y - 15, color);
            trazo.DDALine(x - 8, y, x + 8, y, color);
            trazo.DDALine(x - 8, y + 15, x + 8, y + 15, color);
        }

        private void cuatro(int x, int y, Color color)
        {
            trazo.DDALine(x + 8, y - 15, x + 8, y + 15, color);
            trazo.DDALine(x - 8, y, x + 8, y, color);
            trazo.DDALine(x - 8, y - 15, x - 8, y, color);
        }

        private void cinco(int x, int y, Color color)
        {
            trazo.DDALine(x - 8, y - 15, x + 8, y - 15, color);
            trazo.DDALine(x - 8, y - 15, x - 8, y, color);
            trazo.DDALine(x - 8, y, x + 8, y, color);
            trazo.DDALine(x + 8, y, x + 8, y + 15, color);
            trazo.DDALine(x - 8, y + 15, x + 8, y + 15, color);
        }

        private void seis(int x, int y, Color color)
        {
            trazo.DDALine(x - 8, y - 15, x - 8, y + 15, color);
            trazo.DDALine(x - 8, y, x + 8, y, color);
            trazo.DDALine(x - 8, y + 15, x + 8, y + 15, color);
            trazo.DDALine(x + 8, y, x + 8, y + 15, color);
            trazo.DDALine(x - 8, y - 15, x + 8, y - 15, color);
        }

        private void siete(int x, int y, Color color)
        {
            trazo.DDALine(x + 8, y - 15, x + 8, y + 15, color);
            trazo.DDALine(x - 8, y, x + 8, y, color);
            trazo.DDALine(x - 8, y - 15, x + 8, y - 15, color);
        }

        private void ocho(int x, int y, Color color)
        {
            trazo.DDALine(x - 8, y - 15, x + 8, y - 15, color);
            trazo.DDALine(x + 8, y - 15, x + 8, y + 15, color);
            trazo.DDALine(x - 8, y - 15, x - 8, y + 15, color);
            trazo.DDALine(x - 8, y, x + 8, y, color);
            trazo.DDALine(x - 8, y + 15, x + 8, y + 15, color);
        }

        private void nueve(int x, int y, Color color)
        {
            trazo.DDALine(x + 8, y - 15, x + 8, y + 15, color);
            trazo.DDALine(x - 8, y - 15, x + 8, y - 15, color);
            trazo.DDALine(x - 8, y, x + 8, y, color);
            trazo.DDALine(x - 8, y - 15, x - 8, y, color);
        }

        private void mas_diez(int x, int y,int n, Color color)
        {

            int nd = n/10;
            int nu = n%10;

            switch(nd)
            {
                case 1: unoD(x-8, y, color);
                    break;
                case 2: dosD(x - 8, y, color);
                    break;
                case 3: tresD(x - 8, y, color);
                    break;
                case 4: cuatroD(x - 8, y, color);
                    break;
                case 5: cincoD(x - 8, y, color);
                    break;
                case 6: seisD(x - 8, y, color);
                    break;
                case 7: sieteD(x - 8, y, color);
                    break;
                case 8: ochoD(x - 8, y, color);
                    break;
                case 9: nueveD(x - 8, y, color);
                    break;
                default:
                    break;
            }

            switch(nu)
            {
                case 0: cero(x+8, y, color);
                    break;
                case 1: unoD(x + 8, y, color);
                    break;
                case 2: dosD(x + 8, y, color);
                    break;
                case 3: tresD(x + 8, y, color);
                    break;
                case 4: cuatroD(x + 8, y, color);
                    break;
                case 5: cincoD(x + 8, y, color);
                    break;
                case 6: seisD(x + 8, y, color);
                    break;
                case 7: sieteD(x + 8, y, color);
                    break;
                case 8: ochoD(x  +  8, y, color);
                    break;
                case 9: nueveD(x + 8, y, color);
                    break;
                default:
                    break;
            }

        }

        

        private void cero(int x, int y, Color color)
        {
            trazo.DDALine(x - 5, y - 10, x + 5, y - 10, color);
            trazo.DDALine(x - 5, y - 10, x - 5, y + 10, color);
            trazo.DDALine(x + 5, y - 10, x + 5, y + 10, color);
            trazo.DDALine(x - 5, y + 10, x + 5, y + 10, color);
        }

        private void unoD(int x, int y, Color color)
        {
            trazo.DDALine(x, y - 10, x, y + 10, color);
        }
        private void dosD(int x, int y, Color color)
        {
            trazo.DDALine(x - 5, y - 10, x + 5, y - 10, color);
            trazo.DDALine(x + 5, y - 10, x + 5, y, color);
            trazo.DDALine(x - 5, y, x + 5, y, color);
            trazo.DDALine(x - 5, y, x - 5, y + 10, color);
            trazo.DDALine(x - 5, y + 10, x + 5, y + 10, color);
        }

        private void tresD(int x, int y, Color color)
        {
            trazo.DDALine(x + 5, y - 10, x + 5, y + 10, color);
            trazo.DDALine(x - 5, y - 10, x + 5, y - 10, color);
            trazo.DDALine(x - 5, y, x + 5, y, color);
            trazo.DDALine(x - 5, y + 10, x + 5, y + 10, color);
        }

        private void cuatroD(int x, int y, Color color)
        {
            trazo.DDALine(x + 5, y - 10, x + 5, y + 10, color);
            trazo.DDALine(x - 5, y, x + 5, y, color);
            trazo.DDALine(x - 5, y - 10, x - 5, y, color);
        }

        private void cincoD(int x, int y, Color color)
        {
            trazo.DDALine(x - 5, y - 10, x + 5, y - 10, color);
            trazo.DDALine(x - 5, y - 10, x - 5, y, color);
            trazo.DDALine(x - 5, y, x + 5, y, color);
            trazo.DDALine(x + 5, y, x + 5, y + 10, color);
            trazo.DDALine(x - 5, y + 10, x + 5, y + 10, color);
        }

        private void seisD(int x, int y, Color color)
        {
            trazo.DDALine(x - 5, y - 10, x - 5, y + 10, color);
            trazo.DDALine(x - 5, y, x + 5, y, color);
            trazo.DDALine(x - 5, y + 10, x + 5, y + 10, color);
            trazo.DDALine(x + 5, y, x + 5, y + 10, color);
            trazo.DDALine(x - 5, y - 10, x + 5, y - 10, color);
        }

        private void sieteD(int x, int y, Color color)
        {
            trazo.DDALine(x + 5, y - 10, x + 5, y + 10, color);
            trazo.DDALine(x - 5, y, x + 5, y, color);
            trazo.DDALine(x - 5, y - 10, x + 5, y - 10, color);
        }

        private void ochoD(int x, int y, Color color)
        {
            trazo.DDALine(x - 5, y - 10, x + 5, y - 10, color);
            trazo.DDALine(x + 5, y - 10, x + 5, y + 10, color);
            trazo.DDALine(x - 5, y - 10, x - 5, y + 10, color);
            trazo.DDALine(x - 5, y, x + 5, y, color);
            trazo.DDALine(x - 5, y + 10, x + 5, y + 10, color);
        }

        private void nueveD(int x, int y, Color color)
        {
            trazo.DDALine(x + 5, y - 10, x + 5, y + 10, color);
            trazo.DDALine(x - 5, y - 10, x + 5, y - 10, color);
            trazo.DDALine(x - 5, y, x + 5, y, color);
            trazo.DDALine(x - 5, y - 10, x - 5, y, color);
        }   

    }
}
