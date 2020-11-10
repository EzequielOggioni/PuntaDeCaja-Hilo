using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PuntaDeCaja
{
    class Program
    {
        static Random random;

        static List<Thread> hilosCajas;

        static void Main(string[] args)
        {
            random = new Random(DateTime.Now.Millisecond);
            hilosCajas = new List<Thread>();

            Banco.personas.Enqueue(CrearPersona());
            Banco.personas.Enqueue(CrearPersona());
            Banco.personas.Enqueue(CrearPersona());
            Banco.personas.Enqueue(CrearPersona());
            Banco.personas.Enqueue(CrearPersona());
            Banco.personas.Enqueue(CrearPersona());
            Thread hiloCola = new Thread(agregarPersona);

            
            for (int i = 0; i < random.Next(2,5); i++)
            {
                //creo los cajeros
                Cajero cajero = new Cajero();
                cajero.Numero = (i + 1).ToString();
                hilosCajas.Add(new Thread(cajero.AtenderProximaPersona));

            }
            
            //empieza a entrar gente cada 3 segundos;
            hiloCola.Start();

            foreach (Thread cadaCaja in hilosCajas)
            {
                cadaCaja.Start();
            }

            Console.WriteLine(Banco.personas.Count);
            Console.ReadLine();

            if(hiloCola.IsAlive)
                hiloCola.Abort();

            foreach (Thread cadaCaja in hilosCajas)
            {
                if (cadaCaja.IsAlive)
                    cadaCaja.Abort(); 
            }

        }

        static void agregarPersona()
        {
            Banco.personas.Enqueue(CrearPersona());
            Thread.Sleep(100);
            if (Banco.personas.Count < 20)
                agregarPersona();
        }

        static Persona CrearPersona()
        {
            Persona p1 = new Persona();
            p1.Nombre = random.Next().ToString();
            
            for (int i = 0; i < random.Next(1,10); i++)
            {
            Factura f1 = new Factura();
            f1.Numero = random.Next();
                f1.Precio = random.Next(1000, 100000) / 100;
                p1.Facturas.Add(f1); 
            }

            return p1;
        }


    }
}
