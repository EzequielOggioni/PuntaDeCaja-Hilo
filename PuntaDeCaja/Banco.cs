using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntaDeCaja
{
   public static class Banco
    {
        public static  Queue<Persona> personas;

        static Banco()
        {
            personas = new Queue<Persona>();
        }


    }
}
