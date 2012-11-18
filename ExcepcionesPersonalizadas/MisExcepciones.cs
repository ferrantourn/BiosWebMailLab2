using System;

namespace ExcepcionesPersonalizadas
{
    public class MisExcepciones : Exception
    {

    }

    public class ErrorAlumnoNoExiste : Exception
    {
        private const string Mensaje = "ERROR: Alumno no existe";

        public override string Message
        {
            get { return Mensaje; }
        }

    }

    public class ErrorAlumnoBloqueado : Exception
    {
        private const string Mensaje = "ERROR: Alumno esta bloqueado";

        public override string Message
        {
            get { return Mensaje; }
        }
    }

    public class ErrorUsuarioContraseñaIncorrecto : Exception
    {
        private const string Mensaje = "ERROR: verifica los datos ingresados. media pila!";

        public override string Message
        {
            get { return Mensaje; }
        }
    }
    public class ErrorContraseñaIncorrecta : Exception
    {
        private const string Mensaje = "ERROR: verifique contraseña actual";

        public override string Message
        {
            get { return Mensaje; }
        }

       
    }
    public class ErrorEjecucionSP : Exception
    {

        private const string Mensaje = "Hubo un error al intentar ejecutar la petición, vuelva a intentarlo más tarde";

        public override string Message
        {
            get { return Mensaje; }
        }
        
    }

    public class ErrorGeneral : Exception
    {

        private const string Mensaje = "Hubo un error general, vuelva a intentarlo más tarde";

        public override string Message
        {
            get { return Mensaje; }
        }
     
    }

    public class ErrorBaseDeDatos : Exception
    {

        private const string Mensaje = "Hubo un error en la base de datos, vuelva a intentarlo más tarde";

        public override string Message
        {
            get { return Mensaje; }
        }
       
    }

    public class ErrorDocumentoInvalido : Exception
    {
        private const string Mensaje = "Escriba la CI sin puntos ni guiones";

        public override string Message
        {
            get { return Mensaje; }
        }
       
    }

    public class ErrorUsuarioYaExiste : Exception
    {
        private const string Mensaje = "ERROR: Usuario ya existe en el sistema";

        public override string Message
        {
            get { return Mensaje; }
        }
      
    }

    public class ErrorUsuarioNoExiste : Exception
    {
        private const string Mensaje = "ERROR: Usuario no existe en el sistema";

        public override string Message
        {
            get { return Mensaje; }
        }
      
    }
    public class ErrorNoHayUsuarios : Exception
    {
        private const string Mensaje = "ERROR: No hay usuarios registrados en el sistema";

        public override string Message
        {
            get { return Mensaje; }
        }
      
    }

    public class ErrorCarpetaYaExiste : Exception
    {
        private const string Mensaje = "ERROR: Ya existe una carpeta con el mismo nombre.";

        public override string Message
        {
            get { return Mensaje; }
        }
       
    }

    public class ErrorNoHayMails : Exception
    {
        private const string Mensaje = "Carpeta está vacía - No hay ningún mail en esta carpeta.";

        public override string Message
        {
            get { return Mensaje; }
        }
       
    }

    public class ErrorEnvioEmail : Exception
    {
        private const string Mensaje = "Error al enviar email.";

        public override string Message
        {
            get { return Mensaje; }
        }
     
    }
}

