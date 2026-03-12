//Programa principal

GestorDeportivo deportivo = new GestorDeportivo();
try
{
    int operaciones = int.Parse(Console.ReadLine() ?? "");
    for (int i = 0; i < operaciones; i++)
    {
        string[] entrada = (Console.ReadLine() ?? "").Split(' ');//Split ayuda a dividir el arreglo con el elemento que diga 
        string comando = entrada[0];
        switch (comando)
        {
            case "COMPETENCIA":
                deportivo.AgregarCompetencia(entrada[1], entrada[2]);
                break;

            case "ATLETA":
                if (entrada.Length == 4)
                {
                    deportivo.AgregarAtleta(entrada[1], int.Parse(entrada[2]), entrada[3]);
                }
                else if (entrada.Length >= 5)
                {
                    deportivo.AgregarAtleta(entrada[1], int.Parse(entrada[2]), entrada[3], entrada[4]);
                }
                break;

            case "RESULTADO":
                string comentario = "";
                if (entrada.Length > 4) // Si hay comentario, lo unimos con Skip(4)
                {
                    comentario = string.Join(" ", entrada.Skip(4));
                }
                deportivo.RegistrarResultado(entrada[1], entrada[2], entrada[3], comentario);
                break;

            case "MEJOR":
                deportivo.MostrarMejorAtleta(entrada[1]);
                break;

            case "CRITERIO ":
                deportivo.CambiarCriterio(entrada[1]);
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
public class Atleta
{
    // Atributos
    public string Nombre { get; }
    public int Edad { get; }
    public string Deporte { get; }
    public string Equipo { get; }

    // Variable de la clase
    public List<int> Victorias { get; }
    public List<string> PrimerosLugares { get; }
    public List<string> HistorialResultados { get; }

    // Constructor
    public Atleta(string nombre, int edad, string deporte, string equipo = "")
    {
        Nombre = nombre;
        Edad = edad;
        Deporte = deporte;
        Equipo = equipo;
        PrimerosLugares = new List<string>();
        Victorias = new List<int>();
        HistorialResultados = new List<string>();
    }


    public void RegistrarResultado(int posicion)
    {
        if (posicion > 0)
        {
            HistorialResultados.Add(posicion.ToString());
            if (posicion == 1)
            {
                PrimerosLugares.Add(Nombre);
            }
        }
    }

    public void RegistrarResultado(int posicion, string comentario)
    {
        Console.WriteLine($"Comentario recibido : {comentario}");
        RegistrarResultado(posicion); // Llama al método de arriba
    }

    public void RegistrarResultado(string estado)
    {
        // Regresamos el Arreglo y el For para cumplir tus requisitos
        string[] estadosValidos = { "GANADO", "PERDIDO", "EMPATADO" };
        bool esValido = false;

        for (int i = 0; i < estadosValidos.Length; i++)
        {
            if (estadosValidos[i] == estado)
            {
                esValido = true;
                break;
            }
        }

        if (esValido)
        {
            HistorialResultados.Add(estado);
            if (estado == "GANADO")
            {
                Victorias.Add(1);
            }
        }
        else
        {
            throw new ArgumentException("El resultado debe ser GANADO, PERDIDO o EMPATADO");
        }
    }

    public void RegistrarResultado(string estado, string comentario)
    {
        Console.WriteLine($"Comentario recibido : {comentario}");
        RegistrarResultado(estado); // Llama al método de arriba
    }
}
public class Competencia
{
    public string NombreC { get; }
    public string DeporteC { get; }

    //Variables de clase
    List<string> Equipos;

    public Competencia(string nombreC, string deporteC)
    {
        NombreC = nombreC;
        DeporteC = deporteC;
    }


}
public class CompetenciaIndividual : Competencia
{
    public CompetenciaIndividual(string nombreC, string deporteC) : base(nombreC, deporteC)
    {
    }
}
public class CompetenciaEquipo : Competencia
{
    // Usamos la lista que tenías en tu idea original para registrar los equipos inscritos
    public List<string> EquiposInscritos { get; }

    public CompetenciaEquipo(string nombreC, string deporteC) : base(nombreC, deporteC)
    {
        EquiposInscritos = new List<string>();
    }
}
interface IMejor
{
    Atleta MejorAtleta(List<Atleta> atletas,string deporteBuscado);
}

// Criterio 1: Individual (Evalúa los primeros lugares)
public class MejorIndividual : IMejor
{
    public Atleta MejorAtleta(List<Atleta> atletas, string deporteBuscado)
    {
        Atleta mejorAtleta = null;
        int maxPrimeros = -1; // Pivote

        foreach (Atleta atleta in atletas)
        {
            // Solo evaluamos si el atleta practica el deporte que nos pidieron
            if (atleta.Deporte == deporteBuscado)
            {
                int cantidadPrimeros = atleta.PrimerosLugares.Count;
                if (cantidadPrimeros > maxPrimeros)
                {
                    maxPrimeros = cantidadPrimeros;
                    mejorAtleta = atleta;
                }
            }
        }
        return mejorAtleta;
    }
}

public class MejorEquipo : IMejor
{
    public Atleta MejorAtleta(List<Atleta> atletas, string deporteBuscado)
    {
        Atleta mejorAtleta = null;
        int maxVictorias = -1; // Pivote

        foreach (Atleta atleta in atletas)
        {
            // Usamos .Count para saber cuántas victorias tiene
            int cantidadVictorias = atleta.Victorias.Count;

            if (cantidadVictorias > maxVictorias) // Comparación
            {
                maxVictorias = cantidadVictorias;
                mejorAtleta = atleta;
            }
        }
        return mejorAtleta;
    }
}

public class GestorDeportivo
{
    // Listas principales
    public List<Competencia> competencias = new List<Competencia>();
    public List<Atleta> atletas = new List<Atleta>();

    // Interfaz para la estrategia (Por defecto lo ponemos en Individual)
    IMejor estrategiaEvaluacion = new MejorIndividual();

    public void AgregarCompetencia(string nombreC, string deporteC)
    {
        Competencia nuevaComp = new Competencia(nombreC, deporteC);
        competencias.Add(nuevaComp);
    }

    public void AgregarAtleta(string nombre, int edad, string deporte, string equipo = "")
    {
        Atleta nuevoAtleta = new Atleta(nombre, edad, deporte, equipo);
        atletas.Add(nuevoAtleta);
    }
    public void MostrarMejorAtleta(string deporte)
    {
        // Llama a la interfaz pasándole la lista completa y el deporte a buscar
        Atleta mejor = estrategiaEvaluacion.MejorAtleta(atletas, deporte);

        if (mejor != null)
        {
            Console.WriteLine(mejor.Nombre);
        }
        else
        {
            Console.WriteLine("No hay datos");
        }
    }
    // Método que une la Competencia con el Atleta
    public void RegistrarResultado(string nombreComp, string nombreOEquipo, string valor, string comentario = "")
    {
        // 1. Validar que la competencia exista
        Competencia compEncontrada = null;
        foreach (Competencia c in competencias)
        {
            if (c.NombreC == nombreComp)
            {
                compEncontrada = c;
                break;
            }
        }

        if (compEncontrada == null)
        {
            throw new KeyNotFoundException("Competencia no encontrada");
        }

        // 2. Determinar si el 'valor' es un número (posición) o un texto (GANADO, PERDIDO)
        if (int.TryParse(valor, out int posicion))
        {
            // ES INDIVIDUAL: Buscamos al atleta por su Nombre
            foreach (Atleta a in atletas)
            {
                if (a.Nombre == nombreOEquipo)
                {
                    if (comentario == "")
                        a.RegistrarResultado(posicion); // Llama a la sobrecarga int
                    else
                        a.RegistrarResultado(posicion, comentario);
                    break;
                }
            }
        }
        else
        {
            // ES EQUIPO: Buscamos a TODOS los atletas que tengan ese Equipo
            foreach (Atleta a in atletas)
            {
                if (a.Equipo == nombreOEquipo && a.Equipo != "")
                {
                    if (comentario == "")
                        a.RegistrarResultado(valor); // Llama a la sobrecarga string
                    else
                        a.RegistrarResultado(valor, comentario);
                }
            }
        }

    }

    public void CambiarCriterio(string criterio)
    {
        if (criterio == "PRIMERO")
        {
            estrategiaEvaluacion = new MejorIndividual();
        }
        else if (criterio == "VICTORIAS")
        {
            estrategiaEvaluacion = new MejorEquipo();
        }
    }

   }
