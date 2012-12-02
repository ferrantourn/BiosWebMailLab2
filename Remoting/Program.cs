using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting;

namespace Comunicacion.Remoting
{
    class Program
    {
        static void Main(string[] args)
        {
            RemotingConfiguration.Configure("ConfiguracionRemoting.config",false);
            Console.WriteLine("Escuchando via TCP, presione una tecla para finalizar");
            Console.ReadLine();
        }
    }
}
