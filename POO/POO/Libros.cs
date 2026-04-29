//programa principal

Libreria libreria = new Libreria();
try//Por que puse expciones manuales
{
    int operaciones = int.Parse(Console.ReadLine()??"");
    for(int i =0; i<operaciones; i++)
    {
        string[] entrada = (Console.ReadLine()??"").Split(' ');//Split ayuda a dividir el arreglo con el elemento que diga 
        string comando = entrada[0];
        switch (comando)
        {
            case "LIBRO":
                libreria.AgregarLibro(entrada[1], entrada[2], entrada[3]);
                    break;

            case "CALIFICAR":
                if(entrada.Length ==4)
                {
                    libreria.CalificarLibros(entrada[1], int.Parse(entrada[3]));
                }
                else
                {
                    //Control
                    Console.WriteLine(entrada.Length);
                    libreria.CalificarLibros(entrada[1], int.Parse(entrada[3]), string.Join(" ",entrada.Skip(4)));//el skip saltate todo, hasta el 4 
                }
                    break;
            case "MEJOR":
                libreria.MostrarMejorLibro(entrada[1]);
                break;

            case "CRITERIO":
                libreria.CambiarCriterio(entrada[1]);
                break;

            default:
                throw new InvalidOperationException("Comando no valido");
        }
    }
}
catch(Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}
//Clases
public class Libro
{
    //Atributos
    public string Titulo { get; }//Yo puedo obtener el valor del titulo  puedo sacarlo para cambiarlo,elmine el set por que no voy a poder modificarlo despues 
    public string Autor { get; }
    public string Genero { get; }

    //Variable de la clase
    List<int> Calificaciones;

    //Constructor
    public Libro (string titulo, string autor, string genero)
    {
        Titulo = titulo;
        Autor = autor;
        Genero = genero;
        Calificaciones = new List<int>();
    }


    //Metodos
    public void Calificar(int estrellas)
    {
        if (1<=estrellas && estrellas <=5)
        {
            Calificaciones.Add(estrellas);
        }
        else
        {
            throw new ArgumentException("Calificacion invalida(debe ser del 1-5)");
        }
    }
    //Sobrecarga del metodo calificar
    public void Calificar(int estrellas, string comentario)
    {

        Console.WriteLine($"Comentario reciido : {comentario}");
        Calificar(estrellas);
    }
    public double ObtenerPromedio()
    {
        if (Calificaciones.Count ==0)
        {
            throw new InvalidOperationException("No hay calificaciones para este libro aún");
        }
        else
        {
            double promedio = Calificaciones.Average();
            return promedio;
        }
    }

    public int ObtenerVotos()
    {
        return Calificaciones.Count;
    }
}

//Hijas 

public class LibroFiccion : Libro
{
    //Variable de clase
    //List<string> tipoFiccion = new List<string> { "Fantasia","Ciencia_Ficcion", "Romance", "Terror","Misterio"};


    //Consttructror

    public LibroFiccion(string titulo, string autor, string genero ) : base(titulo, autor, genero)
    {
        /*if(!tipoFiccion.Contains(genero))
        {
            throw new ArgumentException("El libro no pertenece a esta categoría");
        }*/
    }
}
public class LibroTecnico : Libro
{
    //Variable de clase
   // List<string> tipoTecnico = new List<string> { "Matematicas", "Historia", "Programacion", "Filosofia", "Medicina" };


    //Constructror

    public LibroTecnico(string titulo, string autor, string genero) : base(titulo, autor, genero)
    {
       /* if (!tipoTecnico.Contains(genero))
        {
            throw new ArgumentException("El libro no pertenece a esta categoría");
        }*/
    }
}


//Interfaz para criterio de recomendacion
interface IRecomndado
{
    Libro ObtenerMejorLibro(List<Libro> libros);

}

//Clases que implementan interfaz

public class RecomendacionPorPromedio : IRecomndado
{
    public Libro ObtenerMejorLibro(List<Libro> libros)
    {
        Libro mejorLibro = null;
        double mejorPromedio = -1; //Pivote

        foreach(Libro libro in libros)
        {
            double promedio = libro.ObtenerPromedio();//Seleccion del pivote
            if(promedio > mejorPromedio)//Comparacion
            {
                mejorPromedio = promedio;
                mejorLibro = libro;
            }
        }
        return mejorLibro;
    }
}
public class RecomendacioPorVotos : IRecomndado
{
    public Libro ObtenerMejorLibro(List<Libro> libros)
    {
        Libro mejorLibro = null;
        double maxVotos = -1; //Pivote

        foreach (Libro libro in libros)
        {
            int votos = libro.ObtenerVotos();//Seleccion del pivote

            if (votos > maxVotos)//Comparacion
            {
                maxVotos = votos;
                mejorLibro = libro;
            }
        }
        return mejorLibro;
    }
}

public class Libreria
{
    public List<Libro> libros = new List<Libro>();
    IRecomndado estrategiaRecomendacion = new RecomendacionPorPromedio();
    List<string> tipoTecnico = new List<string> { "Matematicas", "Historia", "Programacion", "Filosofia", "Medicina" };
    List<string> tipoFiccion = new List<string> { "Fantasia", "Ciencia_Ficcion", "Romance", "Terror", "Misterio" };

    public void AgregarLibro(string titulo, string autor, string genero)
    {
        Libro nuevoLibro;

        try
        {
            if (tipoTecnico.Contains(genero))
            {
                nuevoLibro = new LibroTecnico(titulo, autor, genero);
                libros.Add(nuevoLibro);

            }
            else if (tipoFiccion.Contains(genero))
            {
                nuevoLibro = new LibroFiccion(titulo, autor, genero);
                
                libros.Add(nuevoLibro);
            }

        }
        catch (Exception ex)
        {
            

        }

    }

    public void CalificarLibros(string titulo, int estrellas)
    {
        Libro libroEncontrado = null;

        foreach (Libro libro in libros)
        {
            if(libro.Titulo == titulo)
            {
                libroEncontrado = libro;
                break;
            }
        }
        if (libroEncontrado != null)
        {
            libroEncontrado.Calificar(estrellas);
        }
        else
        {
            throw new KeyNotFoundException("Libro no encontrado");
        }

    }

    //Sobrecarga
    public void CalificarLibros(string titulo, int estrellas, string comentario)
    {
        Libro libroEncontrado = null;

        foreach (Libro libro in libros)
        {
            if (libro.Titulo == titulo)
            {
                libroEncontrado = libro;
                break;
            }
        }
        if (libroEncontrado != null)
        {
            libroEncontrado.Calificar(estrellas,comentario);
        }
        else
        {
            throw new KeyNotFoundException("Libro no encontrado");
        }

    }

    public void CambiarCriterio(string criterio)
    {
        if (criterio == "PROMEDIO")
        {
            estrategiaRecomendacion = new RecomendacionPorPromedio();
        }
        else if (criterio == "VOTOS")
        {
            estrategiaRecomendacion = new RecomendacioPorVotos();
        }
    }

    public void MostrarMejorLibro(string genero)
    {
        List <Libro> librosGenero = new List<Libro> ();//Es una nueva lista de libros

        foreach(Libro libro in libros)
        {
            if(libro.Genero == genero)//Del genero del libro si concuerda con el genero que me dijiste
            {
                librosGenero.Add(libro);
            }
        }
        Libro mejorlibro = estrategiaRecomendacion.ObtenerMejorLibro(librosGenero);//Llama a estrategia de recomendacion y lo envia a mejorlibro
        if(mejorlibro != null)
        {
            Console.WriteLine(mejorlibro.Titulo);
        }
        else
        {
            Console.WriteLine("No hay datos");
        }

    }



}

