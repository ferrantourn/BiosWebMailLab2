using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logica
{
    public class FabricaLogica
    {
        public static ILogicaCarpetas getLogicaCarpetas()
        {
            return LogicaCarpetas.GetInstancia();
        }

        public static ILogicaEmails getLogicaEmails()
        {
            return LogicaEmails.GetInstancia();
        }

        public static ILogicaUsuario getLogicaUsuario()
        {
            return LogicaUsuario.GetInstancia();
        }
    }
}
