

namespace MonitoreoDrones.Dominio.Entidades
{
    public class Mision
    {
        //Atributos
        public int Id { get; set; }
        public string Tipo {  get; set; }
        public int DuracionEstimada { get; set; }
        public bool Completado { get; set; }

        //constructor
        public Mision(int id, string tipo, int duracion,bool completado) 
        {
            Id = id;
            Tipo = tipo;
            DuracionEstimada = duracion;
            Completado = false;

        }
        //Metodos

        public void CompletarMision ()
        {
            Completado = true;
        }
    }
}
