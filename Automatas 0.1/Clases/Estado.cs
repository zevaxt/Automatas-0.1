using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Threading;
using System.Drawing.Drawing2D;


namespace Automatas_0._1.Clases
{
    [Serializable]
    public class Estado
    {
        public String nombre;
        public LinkedList<Clases.Transicion> listTransiciones;
        public Boolean aceptador;
<<<<<<< HEAD
        public Boolean inicial;
        public int x;
        public int y;
        public Rectangle rectangulo;
        
        public Boolean bandera1;
        public int mouseX;
        public int mouseY;
        public int ancho;
        public int alto;
       
        

        public Estado()
        {
            this.nombre = "";
            this.listTransiciones = new LinkedList<Transicion>();
            this.aceptador = false;
            this.x = 40;
            this.y = 200;
            this.ancho = 30;
            this.alto = 30;
            this.rectangulo = new Rectangle(this.x,this.y,this.ancho,this.alto);
            this.bandera1 = false;
            this.inicial = false;


        }

=======
        public Boolean Acesso;

        
>>>>>>> origin/master

        public Estado(String nombre) 
        {
            this.nombre = nombre;
            this.listTransiciones = new LinkedList<Transicion>();
            this.aceptador = false;
<<<<<<< HEAD
            this.inicial = false;
            this.x = 40;
            this.y = 200;
            this.ancho = 30;
            this.alto = 30;
            this.rectangulo = new Rectangle(this.x, this.y, this.ancho, this.alto);
    

        
=======
  }
        public Estado(String nombre,Boolean aceptador)
        {
            this.nombre = nombre;
            this.listTransiciones = new LinkedList<Transicion>();
            this.aceptador = true;
        }
           public Estado(String nombre, LinkedList<Transicion> listTransiciones, Boolean aceptador) {
        this.nombre = nombre;
        this.listTransiciones = listTransiciones;
        this.aceptador = aceptador;
>>>>>>> origin/master
        
        if(aceptador)
        {
            this.Acesso = true;
        }
<<<<<<< HEAD
        public void pintarEstados(Graphics papel)
        {
           
            this.rectangulo.X = this.x;
            this.rectangulo.Y = this.y;


            if (this.inicial)
            {
                Point[] points = {
                new Point(this.x-20, this.y),      
                new Point(this.x-20, this.y+30),   
                new Point(this.x-5, this.y+15)};
                Pen pen = new Pen(Color.GreenYellow);
                papel.DrawPolygon(pen, points);
                //papel.DrawCurve(pen, points);

                
                
            }

            if (this.aceptador)
            {
                SolidBrush gg = new SolidBrush(Color.SteelBlue);
                papel.FillEllipse(gg, this.rectangulo);
              
                Rectangle ff = new Rectangle(this.x + 5, this.y + 5, this.ancho - 10, this.alto - 10);
   


                papel.FillEllipse(new SolidBrush(Color.YellowGreen),ff);
   

            }

            else
            {
                papel.FillEllipse(new SolidBrush(Color.YellowGreen), this.rectangulo);
            }
     
        }
        public void pintarNombre(Graphics papel)
        {

            StringFormat Format = new StringFormat();
            Format.Alignment = StringAlignment.Center;

            papel.DrawString(this.nombre, new Font("Arial", 10), new SolidBrush(Color.Black), this.rectangulo, Format);
        
        }

        public void mover(MouseEventArgs e,int caso)
        {

            if (caso==1)
            {
                this.mouseX = e.X;
                this.mouseY = e.Y;

                

                if (mouseX >= this.x && mouseX <= this.x + this.ancho && mouseY >= this.y && mouseY <= this.y + this.alto)
                {
                    this.bandera1=true;

                    }
                
            }

            if (caso == 2)
            {
                this.mouseX = e.X;
                this.mouseY = e.Y;
                
                bandera1 = false;

            }

            if (caso == 3)
            {
                this.mouseX = e.X;
                this.mouseY = e.Y;

                if (mouseX >= this.x && mouseX <= this.x + this.alto && mouseY >= this.y && mouseY <= this.y + this.alto && bandera1==true)
                {
                    this.x = e.X - (this.ancho/2);
                    this.y = e.Y - (this.alto/2);

                }


                


            }
        
        
        }

        

       

 
      



=======
        else
        {
            this.Acesso=false;
        }
        
    }
           public LinkedList<Transicion> getLista()
           {
               return this.listTransiciones;
           }
>>>>>>> origin/master
    }
}
