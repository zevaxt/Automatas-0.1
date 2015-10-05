using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automatas_0._1.Clases
{
    public class Estado
    {
        public String nombre;
        public LinkedList<Clases.Transicion> listTransiciones;
        public Boolean aceptador;

        public Estado(String nombre) 
        {
            this.nombre = nombre;
            this.listTransiciones = new LinkedList<Transicion>();
            this.aceptador = false;

        
        
        }

    }
}
