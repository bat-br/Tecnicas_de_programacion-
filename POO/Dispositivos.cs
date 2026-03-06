
// Programa principal





//Interfaz
public interface IDispositivoInteligente
{
    void Encender();
    void Apagar();
    void MoestrarEstado();

}
public class Lampara : IDispositivoInteligente //Brillo
{
    //Atributo
    public int NivelBrillo {  get; set; }
   public bool estado = false;
    //Constructor
    public Lampara(int  nivelBrillo)
    {
        NivelBrillo = nivelBrillo;
        
    }
    //Metodo
    public void Encender()
    {
      if (!estado)
        {
            estado = true;
            Console.WriteLine("La lampara se encendio");
        }
      else
        {
            Console.WriteLine("la lampara ya estaba encendida");
        }
    }
    public void Apagar()
    {
        if (!estado)
        {
            estado = false;
            Console.WriteLine("La lampara se apago");
        }
        else
        {
            Console.WriteLine("La lampara ya estaba apagada");
        }
    }
    public void MoestrarEstado()
    {
        if (estado == true)
        {
            Console.WriteLine($"La lampara esta encendida con un nivel de brillo de: {NivelBrillo}");
        }
        else
        {
            Console.WriteLine("Tu lampara esta apagada");
        }

    }

    public void ControlBrillo(int nivelBrillo)
    {
        Console.WriteLine("Puedes ajustar el brillo entre 1 a 10");
        Console.WriteLine($"Deseas cambiar el brillo, el brillo actual es {NivelBrillo}, presiona S si es afirmativo");
        char Br = char.Parse(Console.ReadLine() ?? "".ToLower());

    }
}
public class Vetilador : IDispositivoInteligente//Velocidad
{
    //Atributo
    public int Velocidad {  get; set; }
    public bool estadoV = false;

    //Constructor
    public Vetilador(int velocidad)
    {
        Velocidad = velocidad;
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
        if (!estadoV)
        {
            estadoV = false;
            Console.WriteLine("El ventilador se apago");
        }
        else
        {
            Console.WriteLine("El ventilador ya estaba apagado");
        }
    }
    public void MoestrarEstado()
    {
        if (estadoV == true)
        {
            Console.WriteLine($"El ventilador esta encendido con un nivel de velocidad: {Velocidad}");
        }
        else
        {
            Console.WriteLine("Tu ventilador esta apagado");
        }

    }
}
public class Altavoz : IDispositivoInteligente //Reproducir musica
{
    //Atributo
    public string ReproducirMusica {  get; set; }
    public bool estadoA;
    //Constructor
    public Altavoz (string reproducirMusica)
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
        if (!estadoA)
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
    public void MoestrarEstado()
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

}