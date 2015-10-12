using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Automatas_0._1.Clases
{
    [Serializable]
    public class Transicion
    {
        public Clases.Estado origen;
        public String simbolo;
        public Clases.Estado destino;
        public Point punto;
        public bool doble;
        public bool auto;
        

        public Transicion(Clases.Estado origen, String simbolo, Clases.Estado destino)
        {            
            this.origen = origen;
            this.simbolo = simbolo;
            this.destino = destino;
            this.doble = false;
            this.auto = false;
            if (origen.nombre.Equals(destino.nombre))
            {
                this.auto = true;
            }

        }
        public void Pintar_traciciones(Graphics g)
        {
            int xm = 0;
            int ym=0;


            int xx = (this.destino.x - this.origen.x) / 2;
            int xxx = Math.Abs(xx);

            int yy = (this.destino.y - this.origen.y) / 2;
            int yyy = Math.Abs(yy);

            if (xx >= 0)
            {
                xm = origen.x + xxx+20;

            }
            else
            {
                xm = origen.x - xxx-20;
            }




            if (yy >= 0)
            {
                ym = origen.y + yyy - 20;

            }
            else
            {
                ym = origen.y - yyy +20;
            }


            if (auto)
            {
                Point[] points = {
                new Point(origen.x+15,origen.y-5),
                new Point(origen.x+15-5,origen.y-5-5),
                new Point(origen.x+15-10,origen.y-5-10),   
                new Point(origen.x+15,origen.y-5-20),
                new Point(origen.x+15+10,origen.y-5-10),
                new Point(origen.x+15+5,origen.y-5-5)};

                Pen pen = new Pen(Color.Gray, 2);
                AdjustableArrowCap bigArrow = new AdjustableArrowCap(5, 5); // ancho de flecga   
                //pen.EndCap = LineCap.ArrowAnchor;
                pen.CustomEndCap = bigArrow;
                g.DrawCurve(pen, points);
                
            }
            else if (doble)
            {
                
                punto=new Point(xm, ym );  
          

                Point[] points = {
                new Point(origen.x+15,origen.y+15),      
                punto,   
                new Point(destino.x+15, destino.y+15)};
                Pen pen = new Pen(Color.Gray,2);
                AdjustableArrowCap bigArrow = new AdjustableArrowCap(6, 6); // ancho de flecga   
               //pen.EndCap = LineCap.ArrowAnchor;
                pen.CustomEndCap = bigArrow;
                g.DrawCurve(pen, points);               
            }
            else
	        {
                Point[] points = {
                new Point(origen.x+15,origen.y+15),      
                //new Point((destino.x-(origen.x/2)), origen.y+15),   
                new Point(destino.x+15, destino.y+15)};
                Pen pen = new Pen(Color.Gray,2);
                AdjustableArrowCap bigArrow = new AdjustableArrowCap(6, 6); // ancho de flecga   
               //pen.EndCap = LineCap.ArrowAnchor;
                pen.CustomEndCap = bigArrow;
                g.DrawCurve(pen, points);

	        }


        }


        public void Pintar_etiqueta(Graphics papel,int e)
        {
            Boolean ban = false;
            Rectangle r = new Rectangle(origen.x, origen.y, 10, 15);

            if (auto)
            {
                r.X = this.origen.x + 10+(10 * e);
                r.Y = this.origen.y -18;
            }

            else if (!this.doble)
            {
                int xx = (this.destino.x - this.origen.x) / 2;
                int xxx = Math.Abs(xx);

                int yy = (this.destino.y - this.origen.y) / 2;
                int yyy = Math.Abs(yy);

                if (xx >= 0)
                {
                    r.X = origen.x + xxx + (10 * e);

                }
                else
                {
                    r.X = origen.x - xxx + (10 * e);
                }




                if (yy >= 0)
                {
                    r.Y = origen.y + yyy ;

                }
                else
                {
                    r.Y = origen.y - yyy ;
                }
            }
            else
            {
                r.X = punto.X +(10 * e);
                r.Y = punto.Y;

            }

            StringFormat Format = new StringFormat();
            Format.Alignment = StringAlignment.Center;

            papel.DrawString(this.simbolo, new Font("Arial", 8), new SolidBrush(Color.Black), r, Format);

        }


    }


}
