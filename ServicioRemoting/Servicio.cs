using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

namespace ServicioRemoting
{
   internal class Servicio
    {
        private TcpChannel unCanal;
        private static Servicio _Servicio = null;
        private Servicio()
        {
            unCanal = new TcpChannel();
            ChannelServices.RegisterChannel(unCanal, false);
            RemotingConfiguration.RegisterWellKnownClientType(typeof(Persistencia.FabricaPersistencia), "tcp://localhost:8989/FabricaPersistencia.remota");
        }

        public static void CreoServicio()
        {
            if (_Servicio == null)
                _Servicio = new Servicio();
        }
    }
}
