using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesPersonalizadas
    {
        public class MisExcepciones : System.Exception
        {

        }

        public class ErrorAlumnoNoExiste : System.Exception
        {
            public ErrorAlumnoNoExiste()
            {
            }

            public override string ToString()
            {
                return "ERROR: Alumno no existe";
            }
 
        }

        public class ErrorAlumnoBloqueado : System.Exception
        {
            public ErrorAlumnoBloqueado()
            {
            }

            public override string ToString()
            {
                return "ERROR: Alumno esta bloqueado";
            }

        }

        public class ErrorUsuarioContraseñaIncorrecto : System.Exception
        {
            public ErrorUsuarioContraseñaIncorrecto()
            {
            }

            public override string ToString()
            {
                return "ERROR: verifica los datos ingresados. media pila!";
            }
        }
        public class ErrorContraseñaIncorrecta : System.Exception
        {
            public ErrorContraseñaIncorrecta()
            {
            }

            public override string ToString()
            {
                return "ERROR: verifique contraseña actual";
            }
        }
        public class ErrorEjecucionSP : System.Exception
        {
            public ErrorEjecucionSP()
            {

            }

            public override string ToString()
            {
                return "Hubo un error al intentar ejecutar la petición, vuelva a intentarlo más tarde";
            }
        }

        public class ErrorGeneral : System.Exception
        {
            public ErrorGeneral()
            {

            }
            public override string ToString()
            {
                return "Hubo un error general, vuelva a intentarlo más tarde";
            }
        }

        public class ErrorBaseDeDatos : System.Exception
        {
            public ErrorBaseDeDatos()
            {

            }
            public override string ToString()
            {
                return "Hubo un error en la base de datos, vuelva a intentarlo más tarde";
            }
        }

        public class ErrorDocumentoInvalido : System.Exception
        {
            public ErrorDocumentoInvalido()
            {

            }
            public override string ToString()
            {
                return "Escriba la CI sin puntos ni guiones";
            }
        }

        public class ErrorUsuarioYaExiste : System.Exception
        {
            public ErrorUsuarioYaExiste()
            {
            }
            public override string ToString()
            {
                return "ERROR: Usuario ya existe en el sistema";
            }
        }

        public class ErrorUsuarioNoExiste : System.Exception
        {
            public ErrorUsuarioNoExiste()
            {

            }
            public override string ToString()
            {
                return "ERROR: Usuario no existe en el sistema";
            }
        }
        public class ErrorNoHayUsuarios : System.Exception
        {
            public ErrorNoHayUsuarios()
            {

            }
            public override string ToString()
            {
                return "ERROR: No hay usuarios registrados en el sistema";
            }
        }

        public class ErrorCarpetaYaExiste : System.Exception
        {
            public ErrorCarpetaYaExiste()
            {

            }
            public override string ToString()
            {
                return "ERROR: Ya existe una carpeta con el mismo nombre.";
            }
        }

        public class ErrorNoHayMails : System.Exception
        {
            public ErrorNoHayMails()
            {

            }
            public override string ToString()
            {
                return "Carpeta está vacía - No hay ningún mail en esta carpeta.";
            }
        }

        public class ErrorEnvioEmail : System.Exception
        {
            public ErrorEnvioEmail()
            {

            }
            public override string ToString()
            {
                return "Error al enviar email.";
            }
        }
}

