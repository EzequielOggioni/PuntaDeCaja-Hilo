using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PuntaDeCaja
{
   public  class Cajero
    {
        public string Numero { get; set; }
        public void AtenderProximaPersona()
        {
            if(Banco.personas.Count > 0)
                this.Cobrar(Banco.personas.Dequeue());
        
        }

        public void Cobrar(Persona persona )
        {
            float montoTotal = 0;
            foreach (Factura item in persona.Facturas)
            {
                montoTotal += item.Precio;
                Thread.Sleep(100);
            }

            Console.WriteLine($"{Numero.ToString()}  cobro a  {persona.Nombre}  ${montoTotal} ");

            this.AtenderProximaPersona();

        }

    }
}
