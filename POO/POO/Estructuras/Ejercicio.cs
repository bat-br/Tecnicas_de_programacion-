//Programa principal
Festival festival = new Festival("KermesFI");
Console.WriteLine($"Bienvenido al festival de musica {festival.Nombre}");

//Crear banda y sus ets de canciones

Console.WriteLine("Registrando Bandas y sets");

//Banda 1
Banda muse = new Banda("Muse", "UK", new TimeSpan(19, 0, 0), 5);
muse.CargarCancion(0, new Cancion("Starlight",4,"Rock"));
muse.CargarCancion(1, new Cancion("Histeria", 3, "Rock"));
muse.CargarCancion(2, new Cancion("Unitended", 3, "Rock"));
muse.CargarCancion(3, new Cancion("Magness", 5, "Rock"));
//Banda 2
Banda djo = new Banda("DJO", "UE", new TimeSpan(17, 0, 0), 3);
djo.CargarCancion(0, new Cancion("Crux", 3, "Rock"));
djo.CargarCancion(1, new Cancion("End of beginning", 3, "Rock"));
djo.CargarCancion(2, new Cancion("Back on you", 5, "Rock"));
//Banda 3
Banda BTS = new Banda("BTS", "Corea", new TimeSpan(21, 0, 0), 3);
BTS.CargarCancion(0, new Cancion("Butter", 3, "KPop"));
BTS.CargarCancion(1, new Cancion("Boby to body", 3, "KPop"));
BTS.CargarCancion(2, new Cancion("Hooligan", 3, "KPop"));
//Banda 4
Banda calibre50 = new Banda("calibre50", "Mexico", new TimeSpan(24, 0, 0), 3);
calibre50.CargarCancion(0, new Cancion("Se te pudiera mentir", 4, "Banda"));
calibre50.CargarCancion(1, new Cancion("El tierno se fue ", 4, "Banda"));
calibre50.CargarCancion(2, new Cancion("El amor de mi vida", 2, "Banda"));
//Agregar al festival
festival.AgregarBanda(muse);
festival.AgregarBanda(djo);
festival.AgregarBanda(BTS);
festival.AgregarBanda(calibre50);

//Duracion total de cada set
Console.WriteLine("Duracion de Sets por banda");
foreach (Banda b in festival.Cartel)
{
    Console.WriteLine($"    {b.Nombre} - {b.DuracionTotalSet()}");
}
//Orden origianl de presentacion

Console.WriteLine($"Reordenando Show ");
festival.ResumenCartel();

//Cambio de ultimo minuto invitada confirma MJ
Banda MJ = new Banda("MJ", "Ue", new TimeSpan(20, 0, 0), 2);
MJ.CargarCancion(0, new Cancion("Thriller", 5, "Pop"));
MJ.CargarCancion(1, new Cancion("Beat ir", 4, "Pop"));

Console.WriteLine($"Cambio de ultimo minuto {MJ.Nombre} confirma como banda despues de BTS y antes de calibre 50");
//Insertar MJ al ordenshow

LinkedListNode<Banda> nodoBTS = festival.OrdenShow.Find(BTS);
festival.InsertarBandaDespuesDe(MJ, nodoBTS);
//Cancela banda
festival.CancelBanda(BTS);

//Fila de ingreso
Console.WriteLine("Asistentes en la fila de ingreso");
festival.FilaIngreso.Enqueue(new Asistente("Juan",1001, new TimeSpan(17,0,0)));
festival.FilaIngreso.Enqueue(new Asistente("Carlos", 1002, new TimeSpan(17, 30, 0)));
festival.FilaIngreso.Enqueue(new Asistente("Saul", 1003, new TimeSpan(20, 30, 0)));
festival.FilaIngreso.Enqueue(new Asistente("Bruno", 1004, new TimeSpan(21, 0, 0)));
festival.FilaIngreso.Enqueue(new Asistente("Daniela", 1005, new TimeSpan(16, 0, 0)));

//Adminitr a todos en orden de llegada

Console.WriteLine("Admitiendo al festival");
while(festival.FilaIngreso.Count > 0)
{
    Asistente ingreso = festival.AdmitirSiguiente();
    Console.WriteLine($"Ingresa: {ingreso.Nombre} | {ingreso.HoraLlegada}");

}
//Simulacion de resentacone en escenario
Console.WriteLine("Presentaciones en escenario:");
foreach(Banda b in festival.OrdenShow.SkipLast(2))
{
    festival.RegistrarPresentacion(b);
}
//Historial de presentaciones
Console.WriteLine("HISTORIAL DEL ESCENARIO");
Stack<Banda> copiaHistorial = new Stack<Banda>(festival.HistorialEscenario);
int turno = 1;
while(copiaHistorial.Count > 0)
{
    Console.WriteLine($"{turno++} | {copiaHistorial.Pop().Nombre}");
}

// Resumen cartel
festival.ResumenCartel();
Console.WriteLine("Gracias por asistir al festival");
public class Cancion
{
    //Atributo
    public string Titulo {  get; set; }
    public int DuracionMinutos { get; set; }
    public string  Genero { get; set; }
    //constructor
    public Cancion (string titulo, int duracionMinutos, string genero)
    {
        Titulo = titulo;
        DuracionMinutos = duracionMinutos;
        Genero = genero;
    }
    //Metodo
    public override string ToString()
    {
        return $"{Titulo}--- {DuracionMinutos}min [{Genero}]";
    }
    

}
public class Banda
{
    //Atributos
    public string Nombre { get; set; }
    public string Origen { get; set; }
    public TimeSpan HoraPresentacion { get; set; }
    
    public Cancion[] SetCanciones { get; set; }

    //Constructor
    public Banda (string nombre, string origen, TimeSpan horaPresentacion, int cantdadCanciones)
    {
        Nombre = nombre;
        Origen = origen;
        HoraPresentacion = horaPresentacion;
        SetCanciones = new Cancion[cantdadCanciones];
    }
    //Metodos
    
    public void CargarCancion(int posicion, Cancion cancion)
    {
        if (posicion >= SetCanciones.Length || posicion < 0)
        {
            throw new ArgumentException($"Posicion invalida{ posicion }");
        }
        SetCanciones[posicion] = cancion;
    }
    public int DuracionTotalSet()
    {
        int total = 0;
        foreach (Cancion cancion in SetCanciones)
        {
            if (cancion != null)
            {
                total += cancion.DuracionMinutos;
            }
        }
        return total;
    }
    public override string ToString()
    {
        return $"{Nombre} ({Origen}) | {HoraPresentacion}:hh\\:mm";
    }
    
   
}
public class Asistente
{
    public string Nombre { get; set; }
    public int NumeroEntrada { get; set; }
    public TimeSpan HoraLlegada { get; set; }
    public bool YaIngreso { get; set; }
    public Asistente(string nombre, int numeroentrada, TimeSpan horaLlegada)
    {
        Nombre = nombre;
        NumeroEntrada = numeroentrada;
        HoraLlegada = horaLlegada;
        YaIngreso = false;
    }
    public override string ToString()
    {
        return $"{Nombre} | Entrada #{NumeroEntrada} | llego a las {HoraLlegada}:hh\\:mm";
    }
}
public class Festival
{
    public string Nombre { get; set; }
    public List<Banda> Cartel { get; set; }
    public Stack<Banda> HistorialEscenario { get; set; }
    public Queue<Asistente> FilaIngreso { get; set; }
    public LinkedList<Banda> OrdenShow { get; set; }

    public Festival(string nombre)
    {
        Nombre = nombre;
        Cartel = new List<Banda>();
        HistorialEscenario = new Stack<Banda>();
        FilaIngreso = new Queue<Asistente>();
        OrdenShow = new LinkedList<Banda>();

    }
    public void AgregarBanda ( Banda banda)
    {
        //Agregando banda a la lista 
        Cartel.Add(banda);
        //Agregar banda a la listaenlazada del orden del Show (Poner nodos, si es algo nuevo puedo poner uno nuevo)
        OrdenShow.AddLast(banda);
        Console.WriteLine($"[+] Banda Confirmada {banda.Nombre}");
    }
    public void CancelBanda(Banda banda)
    {
        if (Cartel.Contains(banda))
        {
            Cartel.Remove(banda);
            OrdenShow.Remove(banda );
            Console.WriteLine($"[-]Banda cancelada {banda.Nombre}");
        }
        else
        {
            Console.WriteLine($"Banda{banda.Nombre} no se encontro");
        }
    }
    public void InsertarBandaDespuesDe(Banda nueva, LinkedListNode<Banda> despuesDe)//declaras el que el nodo
    {
        OrdenShow.Remove(nueva);
        OrdenShow.AddAfter(despuesDe , nueva);
        Console.WriteLine($"    []Banda {nueva.Nombre} reubicada en el orden del show");
    }
    public void RegistrarPresentacion(Banda banda)
    {
        HistorialEscenario.Push(banda);
        Console.WriteLine($"[] Presentacion registrada {banda.Nombre}");
    }
    public Asistente AdmitirSiguiente()
    {
        Asistente asistente = FilaIngreso.Dequeue();
        asistente.YaIngreso = true;
        return asistente;
    }
    public Banda UltimaEnTocar()
    {
        return HistorialEscenario.Peek();
    }
    public void ResumenCartel()
    {
        //Copia de la lista de bandas para no alterar el original
        List<Banda> ordenada = new List<Banda>(Cartel);
        //Ordenamiento burbuja sobre hora de presentacion
        int n = ordenada.Count;
        for (int i = 0; i< n-1; i++)
        {
            for (int j = 0; j < n-1-i; j++)
            {
                if (ordenada[j].HoraPresentacion > ordenada[j+1].HoraPresentacion)
                {
                    Banda temp = ordenada[j];
                    ordenada[j] = ordenada[j+1];
                    ordenada[j+1] = temp;
                }
            }
        }
        Console.WriteLine($"Cartel oficial - {Nombre}");
        foreach(Banda b in ordenada)
        {
            Console.WriteLine($"   {b.HoraPresentacion:hh\\mm} {b.Nombre}");
        }
    }
}