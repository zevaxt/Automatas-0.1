using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automatas_0._1.Clases
{
    
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
         public Automata(String nombre, String inicial, LinkedList<Estado> lista,LinkedList<String> listaAlfabeto)
    {
        this.nombre = nombre;
        this.inicial = inicial;
        this.listEstados = lista;
        this.alfabeto = listaAlfabeto;
    }
        

        
    }
}
