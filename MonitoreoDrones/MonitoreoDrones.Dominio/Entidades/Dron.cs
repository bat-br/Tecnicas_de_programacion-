using MonitoreoDrones.Dominio.Enum;

namespace MonitoreoDrones.Dominio.Entidades
{
    public class Dron
    {
        //Atributos
        public int Id { get; set; }
        public string Modelo { get; set; }
        public double NivelBateria {  get; set; }
        public EstadoDron Estado {  get; set; }
        public Posicion Posicion { get; set; }
        public Mision MisionActual { get; set; }

        //Constructor
        public Dron (int id, string modelo, double nivelbateria, Posicion posicion)
        {
            Id = id;
            Modelo = modelo;
            NivelBateria = nivelbateria;
            Posicion = posicion;
            Estado = EstadoDron.Inactivo;

        }
        //Metodos

        public void AsignarMision(Mision mision)
        {
            if (Estado != EstadoDron.Inactivo)
            {
                throw new InvalidOperationException("Dron no disponible");
            }
            Estado = EstadoDron.EnMision;
            MisionActual= mision;
        }

        public void ActualizarBateria(double nievel)
        {
            NivelBateria= nievel;

            if(NivelBateria <= 5)
            {
                Estado = EstadoDron.FueraServicio;
            }
        }

        public void EnviarMantenimiento()
        {
            Estado = EstadoDron.Mantenimiento;
        }
    }
}
