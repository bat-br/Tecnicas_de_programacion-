//Clase que representa Estudiantes

public class Estudiante
{
    //Atributos
    public int Id { get; set; }
    public string Nombre { get; set; }
    public int Edad { get; set; }
    public double Calificacion {  get; set; }

    //Constructor

    //Metodo
    public override string ToString()
    {
        return $"ID: {Id}, Nombre {Nombre}, Edad {Edad}| Califiacion {Calificacion}";
    }

}

//Clase para manejar el archivo de estudiantes


public class GestordeEstudiantes
{
    //Atributos
    private string rutaArchivo;
    //Vonstructor
    public GestordeEstudiantes(string ruta)
    {
        rutaArchivo = ruta;
    }
    //Metodo para gurdar la ista de estudiantes en un archivo
    public void GuardarEstudiantes(List<Estudiante> estudiantes)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(rutaArchivo))
            {
                foreach (Estudiante estudiante in estudiantes)
                {
                    writer.WriteLine(estudiante.ToString());
                }
            }
            Console.WriteLine("Estudiantes guardados correctamente");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
    //Metodo para leer la lista de estudiantes en el archivo
   /* public List<Estudiante> LeerEstudiantes()
    {
        List<Estudiante> estudiantesLectura = new List<Estudiante>();
        try
        {
            using (StreamReader reader = new StreamReader(rutaSecuancial))
            {
                

            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

}*/
