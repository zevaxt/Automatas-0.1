using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automatas_0._1.Clases
{
    public class Transicion
    {
        public String origen;
        public String simbolo;
        public String destino;

        public Transicion(String origen, String simbolo, String destino)
        {            
            this.origen = origen;
            this.simbolo = simbolo;
            this.destino = destino;

        }

    }


}
