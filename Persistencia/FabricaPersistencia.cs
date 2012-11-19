
namespace Persistencia
{
    public class FabricaPersistencia
    {

        public static IPersistenciaDocentes getPersistenciaDocentes()
        {
            return (PersistenciaDocentes.GetInstancia());
        }

        public static IPersistenciaAlumnos getPersistenciaAlumnos()
        {
            return (PersistenciaAlumnos.GetInstancia());
        }

        public static IPersistenciaEmails getPersistenciaEmails()
        {
            return (PersistenciaEmails.GetInstancia());
        }

        public static IPersistenciaCarpetas getPersistenciaCarpetas()
        {
            return (PersistenciaCarpetas.GetInstancia());
        }
    }

}
