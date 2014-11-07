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
                default:
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
    }
}
