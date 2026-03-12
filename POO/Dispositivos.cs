
// Programa principal
Lampara lamparita = new Lampara(5);
Vetilador ventilador = new Vetilador(0);
Altavoz bocina = new Altavoz("");
List<IDispositivoInteligente> listadispositivos = new List<IDispositivoInteligente>();
listadispositivos.Add(ventilador);
listadispositivos.Add(lamparita);
listadispositivos.Add(bocina);

Console.WriteLine("Encendiendo los dispositivos");
foreach (IDispositivoInteligente dispositivo in listadispositivos)
{
    dispositivo.Encender();
}
foreach (IDispositivoInteligente dispositivo in listadispositivos)
{
    dispositivo.MostrarEstado();
}
lamparita.ControlBrillo(8);
ventilador.CtrVelocidad(10);
bocina.ReproducirMusic("Toss a coin to the witcher");

foreach (IDispositivoInteligente dispositivo in listadispositivos)
{
    dispositivo.Apagar();

}


//Interfaz
public interface IDispositivoInteligente
{
    void Encender();
    void Apagar();
    void MostrarEstado();

}
public class Lampara : IDispositivoInteligente // Se agrego cambios para que se pueda implementar un menu 
{
    // Atributos 
    public int NivelBrillo { get; set; }
    private bool estado = false;

    // Constructor
    public Lampara(int nivelBrillo)
    {
        NivelBrillo = nivelBrillo;
    }

    // Métodos
    public void Encender()
    {
        if (!estado)
        {
            estado = true;
            Console.WriteLine("La lámpara se encendió.");
        }
        else
        {
            Console.WriteLine("La lámpara ya estaba encendida.");
        }
    }

    public void Apagar()
    {
       
        if (estado)
        {
            estado = false;
            Console.WriteLine(" La lámpara se apagó.");
        }
        else
        {
            Console.WriteLine("La lámpara ya estaba apagada.");
        }
    }

    public void MostrarEstado()
    {
        if (estado == true)
        {
            Console.WriteLine($"La lampara esta: Encendida | Nivel de brillo: {NivelBrillo}");
        }
        else
        {
            Console.WriteLine("Tu lámpara está apagada.");
        }
    }

    public void ControlBrillo(int nuevoBrillo)//Al poner un 8 se va almacenar en la variable nuevoBrillo
    {
        
        // Validamos que respete las reglas de 1 a 10
        if (nuevoBrillo >= 1 && nuevoBrillo <= 10)
        {
            // Asignamos el valor a TU propiedad NivelBrillo
            NivelBrillo = nuevoBrillo;
            Console.WriteLine($"El brillo se ha ajustado a: {NivelBrillo}");
        }
        else
        {
            Console.WriteLine("Error: El valor ingresado no es válido. No se cambió el brillo.");
        }
    }
}
public class Vetilador : IDispositivoInteligente//Velocidad
{
    //Atributo
    public int VelocidadV { get; set; }
    public bool estadoV = false;

    //Constructor
    public Vetilador(int velocidadv)
    {
        VelocidadV= velocidadv;
    }
    //Metodo
    public void Encender()
    {
        if (!estadoV)
        {
            estadoV = true;
            Console.WriteLine("El ventilador se encendio");
        }
        else
        {
            Console.WriteLine("El ventilador ya estaba encendido");
        }
    }
    public void Apagar()
    {
        if (estadoV)
        {
            estadoV = false;
            Console.WriteLine("El ventilador se apago");
        }
        else
        {
            Console.WriteLine("El ventilador ya estaba apagado");
        }
    }
    public void MostrarEstado()
    {
        if (estadoV == true)
        {
            Console.WriteLine($"El ventilador esta encendido con un nivel de velocidad: {VelocidadV}");
        }
        else
        {
            Console.WriteLine("Tu ventilador esta apagado");
        }

    }
    public void CtrVelocidad(int nuevaVelocidad)
    {
        
        if (nuevaVelocidad >= 1 && nuevaVelocidad <= 10)
        {
            VelocidadV = nuevaVelocidad;
            Console.WriteLine($"La velocidad se ha ajustado a: {VelocidadV}");
        }
        else
        {
            Console.WriteLine(" Error: El valor ingresado no es válido. No se cambió la velocidad.");
        }
    }
}
public class Altavoz : IDispositivoInteligente //Reproducir musica
{
    //Atributo
    public string ReproducirMusica { get; set; }
    public bool estadoA;
    //Constructor
    public Altavoz(string reproducirMusica)
    {
        ReproducirMusica = reproducirMusica;
    }
    public void Encender()
    {
        if (!estadoA)
        {
            estadoA = true;
            Console.WriteLine("El altavoz se encendio");
        }
        else
        {
            Console.WriteLine("El altavoz ya estaba encendido");
        }
    }
    public void Apagar()
    {
        if (estadoA)
        {
            estadoA = false;
            Console.WriteLine("El altavoz se apago");
        }
        else
        {
            Console.WriteLine("El altavoz ya estaba apagado");
        }
    }
    //Metodo
    public void MostrarEstado()
    {
        if (estadoA == true)
        {
            Console.WriteLine($"Tu altavoz esta encendido y esta reproduciendo: {ReproducirMusica}");
        }
        else
        {
            Console.WriteLine("Tu altavoz esta apagado");
        }

    }
    public void ReproducirMusic(string cancion)
    {
        if (estadoA == true)
        {
            Console.WriteLine($"Reproduciendo: {cancion}");
        }
        else if (estadoA == false)
        {
            return;
        }    
    }

}