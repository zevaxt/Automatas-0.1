using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;





namespace Automatas_0._1.Clases
{


    [Serializable]
    public class Automata
    {
        public String nombre;
        public String tipo;
        public LinkedList<Clases.Estado> listEstados;
        public LinkedList<String> alfabeto;
        public String inicial;


        public Automata() 
        {
            this.nombre = "";
            this.tipo = "";
            this.listEstados = new LinkedList<Estado>();
            this.alfabeto = new LinkedList<string>();
            this.inicial = "";

             
        
        }

        public void pintarEstados(Graphics paper)
        {

/*

            Rectangle comidarec = new Rectangle(x, y, width, height);

            comidarec.X = x;
            comidarec.Y = y;
            paper.FillRectangle(pincel, comidarec);

            comidarec.X = x + 20;
            comidarec.Y = y + 20;

            pincel.Color = Color.Blue;
            */
        
        }
         public Automata(String nombre, String inicial, LinkedList<Estado> lista,LinkedList<String> listaAlfabeto)
    {
        this.nombre = nombre;
        this.inicial = inicial;
        this.listEstados = lista;
        this.alfabeto = listaAlfabeto;
    }
        

        
    }
}
