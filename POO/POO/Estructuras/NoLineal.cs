//Sistema de analisis de tormentas

//Construir el arbol de propagacion
var origen = new Descarga(19.43, -99.13, 320.5);
var rama1 = new Descarga(25.12, -78.62, 285.6);
var rama2 = new Descarga(19.3228, -99.1821, 210.7);
var rama2a = new Descarga(19.15, -99.17, 95.3);


var analizador = new AnalizadorTormenta(origen);
var nodoRama1 = analizador.Propagacion.Origen;
analizador.Propagacion.Bifurcar(analizador.Propagacion.Origen, rama1);
analizador.Propagacion.Bifurcar(analizador.Propagacion.Origen, rama2);
var nodoRama2 = analizador.Propagacion.Origen.Ramas[1];
analizador.Propagacion.Bifurcar(nodoRama2,rama2a);

analizador.Red.Registrar(new SensorCampoElectrico("CE-01", 19.42, -99.10));
analizador.Red.Registrar(new SensorCampoElectrico("CE-02", 19.44, -99.14));
analizador.Red.Registrar(new SensorCampoElectrico("CE-03", 19.43, -99.13));
analizador.Red.Registrar(new SensorAcusico("AC-01", 19.40, -99.12));
analizador.Red.Registrar(new SensorAcusico("AC-02", 19.42, -99.10));

//Generar reporte

analizador.GenerarReporte();

//Sensor más cercano

var cernao = analizador.DetectarMasCecano(rama2a);
Console.WriteLine($"Sensor más cercano a rama 2a{cernao.Id}");

//Acceso por ID

var s = analizador.Red.ObtenerPorID("CE-02");
Console.WriteLine($"Consuta directa {s.Medir()}");

//Exception

try
{
    analizador.Red.ObtenerPorID("CE-05");
}
catch(SensrNoEncontrado ex)
{
    Console.WriteLine($"ERROR {ex.Message}");
}
//Record- tupla inmutable (una tupla conante)



public record Descarga (double Latitud, double Longitud, double Kilovoltios)
{
    public double DistanciaA(Descarga otra)
    {
        return Math.Sqrt(Math.Pow(Latitud-otra.Latitud,2) + Math.Pow(Longitud-otra.Longitud,2));
    }

    public override string ToString()
    {
        return $"({Latitud:F2},{Longitud:F2}) - {Kilovoltios:F1} KV";
    }

}

//Arbol, clase para los nodos


public class NodoRayo
{

    public Descarga Descarga { get; set; }
    public int Nivel { get; }
    public List<NodoRayo> Ramas { get; } = new();
    //Abreviar de new List<NodoRayo>();

    public NodoRayo(Descarga descarga,int nivel )
    {
        this.Descarga = descarga;
        this.Nivel = nivel; 
    }
}

public class ArbolRayo
{
    public NodoRayo Origen { get; }

    public ArbolRayo(Descarga descargaOrigen)
    =>Origen = new NodoRayo(descargaOrigen, 0);

    public void Bifurcar(NodoRayo padre, Descarga nueva)
    {
        padre.Ramas.Add(new NodoRayo(nueva, padre.Nivel + 1));
    }
    
    //DFS
    public double IntensidadTotal()
    {
        return SumarKV(Origen);
    }
    private double SumarKV(NodoRayo nodo)
    {
        double total = nodo.Descarga.Kilovoltios;
        foreach(var rama in nodo.Ramas)
        {
            total += SumarKV(rama);
        }
        return total;
    }


    //DFS profundidad maxia del arbol

    public int ProfundidadMaxima()
    {
        return Profundidad(Origen);
    }
    private int Profundidad(NodoRayo nodo)
    {
        if(nodo.Ramas.Count ==0)
        {
            return nodo.Nivel;
        }
        return nodo.Ramas.Max(r => Profundidad(r));
    }
    //Imprimir el arbol con sangria por nivel

    public void Imprimir()
    {
        ImprimirNodo(Origen);
    }

    private void ImprimirNodo(NodoRayo nodo)
    {
        string sangria = new string(' ',nodo.Nivel*3);
        string prefijo = nodo.Nivel == 0 ? "[ORIGEN]" : "└─";
        Console.WriteLine($"{sangria}{prefijo} {nodo.Descarga}");

        foreach(var rama in nodo.Ramas)
        {
            ImprimirNodo(rama);
        }
    }
}

//Clases apra sensores

//Excepcion personalizada

public class SensrNoEncontrado: Exception
{
    public SensrNoEncontrado(string id) : base ($"Sensor {id} no registrado en la red")
    {

    }
}

//Clase abstracta con polimorfismo Medir
public abstract class SensorMeteorologico
{
    public string Id { get;}
    public double Latitud { get;}
    public double Longitud { get;}
    public bool Activo { get; set; } = true;

    public SensorMeteorologico(string id, double latitud, double longitud)
    {
        Id= id;
        Latitud= latitud;
        Longitud= longitud;
    }

    public abstract string Medir();

    public double DistanciaA (Descarga d)
    {
        return Math.Sqrt(Math.Pow(Latitud - d.Latitud, 2) + Math.Pow(Longitud - d.Longitud, 2));
    }
}


public class SensorCampoElectrico :SensorMeteorologico
{
    public SensorCampoElectrico(string id, double latitud, double longitud) : base(id, latitud, longitud)
    {
    }
    public override string Medir()
    {
        return $"[CE-{Id}] Campo: {new Random().Next(10, 200)} V/m";
    }
}

public class SensorAcusico : SensorMeteorologico
{
    public SensorAcusico(string id, double latitud, double longitud) : base(id, latitud, longitud)
    {
    }
    public override string Medir()
    {
        return $"[AC-{Id}] Nivel sonoro: {new Random().Next(80, 130)} dB";
    }
}

//Clase para red de sensores

public class RedSensres
{
    private Dictionary<string, SensorMeteorologico> sensores = new();

    public void Registrar ( SensorMeteorologico s)
    {
        sensores[s.Id] = s;
    }

    public SensorMeteorologico ObtenerPorID(string id)
    {
        if(!sensores.TryGetValue(id, out var sensor))
        {
            throw new SensrNoEncontrado(id);
        }
        return sensor;
    }

    public Dictionary<string,SensorMeteorologico> SensoresActivos()
    {
        return sensores.Where(par => par.Value.Activo).ToDictionary(par => par.Key, par => par.Value); //Hace la construccion de la estructura inicial
    }

}

//Intrfaz

public interface IAnalizador
{
    SensorMeteorologico DetectarMasCecano(Descarga descarga);
    double IntensidadTotal();
    void GenerarReporte();
}

public class AnalizadorTormenta : IAnalizador
{
    public RedSensres Red {  get;} = new ();
    public ArbolRayo Propagacion { get; }

    public AnalizadorTormenta(Descarga origen) => Propagacion =new ArbolRayo(origen);

    //Buscar en el diccionario el sensor más cercano

    public SensorMeteorologico DetectarMasCecano(Descarga descarga)
    {
         var activos = Red.SensoresActivos();
        if(!activos.Any())
        {
            throw new InvalidOperationException("sin sensores activos");
        }
        return activos.Values.MinBy(s => s.DistanciaA(descarga));
    }

    public double IntensidadTotal()
    {
        return Propagacion.IntensidadTotal();
    }

    public void GenerarReporte()
    {
        Console.WriteLine("Reporte de Tormenta electrica:");
        Console.WriteLine("[Arbol de propagacion del rayo]");
        Propagacion.Imprimir();
        Console.WriteLine($"[Intensidad acumulada] {IntensidadTotal()}");
        Console.WriteLine($"[Profundiad Maxima] {Propagacion.ProfundidadMaxima()}");
        Console.WriteLine($"[Sensores en red] {Red.ToString()}");
        Console.WriteLine($"[Mediciones activdas]");
        foreach (var par in Red.SensoresActivos())
        {
            Console.WriteLine($"[{par.Key}] {par.Value.Medir()}");
        }
    }

}
