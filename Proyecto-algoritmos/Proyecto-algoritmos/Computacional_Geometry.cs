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
    class Computacional_Geometry
    {
        protected Bitmap bmp { get; set; }
        protected PictureBox imagen { get; set; }
        protected int maxY { get; set; }
        protected int maxX { get; set; }

        public Computacional_Geometry()
        {
            bmp = null;
            imagen = null;
            maxY = 0;
            maxX = 0;
        }
        public Computacional_Geometry(PictureBox i, int my, int mx)
        {
            this.bmp = new Bitmap(my, mx);
            this.imagen = i;
            this.maxY = my;
            this.maxX = mx;
        }

        public void setImage()
        {
            imagen.Image = bmp;
        }

        public void MidPointCircle(int x0, int y0, int radius, Color color)
        {

            int x = radius;
            int y = 0;
            int radiusError = 1 - x;

            while (x >= y)
            {
                bmp.SetPixel(x + x0, y + y0, color);
                bmp.SetPixel(y + x0, x + y0, color);
                bmp.SetPixel(-x + x0, y + y0, color);
                bmp.SetPixel(-y + x0, x + y0, color);
                bmp.SetPixel(-x + x0, -y + y0, color);
                bmp.SetPixel(-y + x0, -x + y0, color);
                bmp.SetPixel(x + x0, -y + y0, color);
                bmp.SetPixel(y + x0, -x + y0, color);

                y++;
                if (radiusError < 0)
                    radiusError += 2 * y + 1;
                else
                {
                    x--;
                    radiusError += 2 * (y - x + 1);
                }
            }
        }

        public void DDALine(int x0, int y0, int x1, int y1, Color color)
        {


            double dx, dy, m, x, y;
            dx = x1 - x0;
            dy = y1 - y0;

            if (dx == 0)
            {
                for (int yi = y0; yi <= y1; yi++)
                {

                    bmp.SetPixel(x0, yi, color);
                }
            }
            else if (dy == 0)
            {
                for (int xi = x0; xi <= x1; xi++)
                {
                    bmp.SetPixel(xi, y0, color);

                }
            }
            else if (Math.Abs(dy) <= Math.Abs(dx))
            {
                m = dy / dx;


                if (dx < 0)
                {
                    y = Convert.ToDouble(y1);
                    for (int xi = x1; xi <= x0; xi++)
                    {
                        bmp.SetPixel(xi, Convert.ToInt32(y), color);
                        y += m;
                    }
                }
                else
                {
                    y = Convert.ToDouble(y0);
                    for (int xi = x0; xi <= x1; xi++)
                    {
                        bmp.SetPixel(xi, Convert.ToInt32(y), color);
                        
                        y += m;
                    }
                }
            }
            else
            {
                m = dx / dy;

                if (dy < 0)
                {
                    x = Convert.ToDouble(x1);
                    for (int yi = y1; yi <= y0; yi++)
                    {
                        bmp.SetPixel(Convert.ToInt32(x), yi, color);
                        x += m;
                    }
                }
                else
                {
                    x = Convert.ToDouble(x0);
                    for (int yi = y0; yi <= y1; yi++)
                    {
                        bmp.SetPixel(Convert.ToInt32(x), yi, color);
                        x += m;
                    }
                }
            }
        }

    }
}
