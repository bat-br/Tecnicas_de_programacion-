
namespace MonitoreoDrones.Dominio.Entidades
{
    public class Posicion
    {
        //Atributos
        public double Latitud {  get; private set; }
        public double Longitud { get; private set; }

        //Constructor

        public Posicion (double latitud, double longitud)
        {
            Latitud = latitud;
            Longitud = longitud;
        }

        //metodos
        public void Actualizar(double latitud, double longitud)
        {
            Latitud = latitud;
            Longitud = longitud;
        }
    }
}
