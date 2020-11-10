using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntaDeCaja
{
    public class Persona
    {
        public Persona()
        {
            Facturas = new List<Factura>();  
        }
        public List<Factura> Facturas { get; set; }

        public string Nombre { get; set; }

    }
}
