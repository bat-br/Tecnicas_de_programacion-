//Programa principal
Estudiante estudiante = new Estudiante
    {
        Id=1,
        Nombre = "Pancho Villa",
        Edad = 20,
        Calificacion = 10.0

    };
Console.WriteLine(estudiante);
Console.WriteLine(estudiante.ToString());
//Configuracion inicial
string archivoEstudiantes = "estudiantes.txt";
GestordeEstudiantes gestor = new GestordeEstudiantes(archivoEstudiantes);
//Crear una lista de estudiantes de ejemplo
List<Estudiante> estudiantes = new List<Estudiante>
{
    new Estudiante{ Id= 1 , Nombre = "Diego Garcia",Edad= 22, Calificacion = 6.0},
     new Estudiante{ Id= 2 , Nombre = "Luis Romero",Edad= 21, Calificacion = 7.8},
      new Estudiante{ Id= 3 , Nombre = "Elias Vasquez",Edad= 20, Calificacion = 8.0},
       new Estudiante{ Id= 4 , Nombre = "Bruno Lopez",Edad= 20, Calificacion = 5.0},
        new Estudiante{ Id= 5 , Nombre = "Dario Pineda",Edad= 20, Calificacion = 8.1},
};
//Gurdar estudiantes en archivo
Console.WriteLine("Guardando estudiantes...");
gestor.GuardarEstudiantes(estudiantes);

//Leer todos los estudiantes
Console.WriteLine("Leyendo estudiantes....");
var estudiantesLeidos =gestor.LeerEstudiantes();
foreach(var estudiant in estudiantesLeidos)
{
    Console.WriteLine(estudiant);
}

//Buscar estudiante por Id
Console.WriteLine("Buscando estudinte por Id: 4");
var estudianteEncontrado = gestor.BuscarEstudiantePorId(4);
if(estudianteEncontrado != null)
{
    Console.WriteLine(estudianteEncontrado);

}
else
{
    Console.WriteLine("Estudiante no encontrado");
}


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
        return $"{Id},{Nombre},{Edad},{Calificacion}";
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
    //Metodo para leer la lista de estudiantes en el archivo
    public List<Estudiante> LeerEstudiantes()
    {
        List<Estudiante> estudiantesLectura = new List<Estudiante>();
        try
        {
            if (File.Exists(rutaArchivo))
            {
                using (StreamReader reader = new StreamReader(rutaArchivo))
                {
                    string lineaLectura;

                    while ((lineaLectura = reader.ReadLine()) !=  null)
                    {
                        //Dividios la linea por las comas
                        string[] datos = lineaLectura.Split(',');
                        if (datos.Length == 4)
                        {
                            estudiantesLectura.Add(new Estudiante
                            {
                                Id = int.Parse(datos[0]),
                                Nombre = datos[1],
                                Edad = int.Parse(datos[2]),
                                Calificacion = double.Parse(datos[3])
                            });
                        }
                    }
                   
                }
                Console.WriteLine("Estudiantes leidos correctamente");
            }
            else
            {
                Console.WriteLine("Archivo no ecnonrado en la ruta");
            }
        }
        
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return estudiantesLectura;
    }
    public Estudiante BuscarEstudiantePorId(int id)
    {
        try
        {
            if (File.Exists(rutaArchivo))
            {
                using (StreamReader reader = new StreamReader(rutaArchivo))
                {
                    string lineaLectura;

                    while ((lineaLectura = reader.ReadLine()) != null)
                    {
                        //Dividios la linea por las comas
                        string[] datos = lineaLectura.Split(',');
                        if (datos.Length == 4 && int.Parse(datos[0])== id )
                        {
                            return new Estudiante
                            {
                                Id = int.Parse(datos[0]),
                                Nombre = datos[1],
                                Edad = int.Parse(datos[2]),
                                Calificacion = double.Parse(datos[3])
                            };
                        }
                    }
                    
                }
                
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine (ex.Message);
        }
        return null; //Retorna null si no encuentra el estudiante buscado
    }
}
    
    

