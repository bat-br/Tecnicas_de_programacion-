//Bruno López Ortíz Primer parcial
//Programa principal
SimuladorBillar billarcito = new SimuladorBillar();
try
{
    int operaciones = int.Parse(Console.ReadLine() ?? "");
    for (int i = 0; i < operaciones; i++)
    {
        string[] entrada = (Console.ReadLine() ?? "").Split(' ');//Split ayuda a dividir el arreglo con el elemento que diga 
        string comando = entrada[0];
        switch (comando)
        {
            case "BOLA":
                billarcito.CrearBola(entrada[1], double.Parse(entrada[2]));    
                break;

        
            case "TIRO":
                billarcito.RegistrarTiro(int.Parse(entrada[1]), int.Parse(entrada[2]), int.Parse(entrada[3]));
                break;

            case "CRITERIO":
                billarcito.CambiarEstrategia(entrada[1]);
                break;
    
            case "SIMULAR":
                billarcito.Simular();
                break;
            case "RESULTADO":
                billarcito.MostrarResultado();
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
public class Bola
{
    //Atributos
    public double Masa { get; }
    public double PosicionX { get; set; }
    public double PosicionY { get; set; }

    
    public Bola(double masa)
    {
        Masa = masa;
        PosicionX = 0;
        PosicionY = 0;
    }

    //Metodos
    public void MoverBola(double cambioX, double cambioY)
    {
        PosicionX += cambioX;
        PosicionY += cambioY;
    }
    public virtual double ObtnerCoeficienteFriccion()
    {
        return 0.0; //regreso temporal
    }
}

public class BolaProfecional :Bola
{
    public BolaProfecional(double masa) : base(masa)
    {
        
    }
    public override double ObtnerCoeficienteFriccion()
    {
        return 0.6;
    }
}
public class BolaNormal : Bola
{
    public BolaNormal(double masa) : base(masa)
    {

    }
    public override double ObtnerCoeficienteFriccion()
    {
        return 1.2;
    }

}

public class Tiro
{
    //Atributo
    public int Impulso { get; }
    public int DirX { get; }
    public int DirY { get; }
    //Constructor
    public Tiro(int impulso,int dirx, int diry )
        {
        Impulso = impulso;
        DirX = dirx;
        DirY = diry;
        }

    //Metodos
}
public interface IEstrategiaCalculo
{
    double CalcularDistancia(Bola bola, Tiro tiro);//Voy a necesitar una bola y los datos del tiro
}
public class CalculoFisico : IEstrategiaCalculo
{
    public double CalcularDistancia(Bola bola, Tiro tiro)
    {
        double g = 9.81;
        double I = tiro.Impulso;
        double m = bola.Masa;
        double mu = bola.ObtnerCoeficienteFriccion();

        //Obtenemos velocidad inicial
        double v0 = I / m;
        //Obtenemos la fuerza de friccion
        double Ff = -mu * m * g;
        //Obtenemos la aceleracion del tiro
        double a = Ff / m;
        //Obtenemos el desplazaiento final con v=0
        double distancia = -(v0 * v0) / (2 * a);
        return distancia;
    }
}
public class CalculoSimple : IEstrategiaCalculo
{
    public double CalcularDistancia(Bola bola, Tiro tiro)
    {
        return tiro.Impulso * 2;
    }
}
public class SimuladorBillar
{
    public List<Tiro> tiros = new List<Tiro>();
    IEstrategiaCalculo estrategiadeCalculo = new CalculoSimple();
    public double distanciaTotal = 0.0;
    public Bola bolaActual;

    // metodos
    public void CrearBola(string tipo, double masa)
    {
        try
        {
            if (tipo == "NORMAL")
            {
                bolaActual = new BolaNormal(masa);
            }
            else if (tipo == "PRO")
            {
                bolaActual = new BolaProfecional(masa);
            }
            else
            {
                Console.WriteLine("No existe ese tipo de bola intenta de nuevo");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public void RegistrarTiro(int impulso, int dirx, int diry)
    {
        if (bolaActual != null)
        {
            Tiro nuevoTiro = new Tiro(impulso, dirx, diry);
            tiros.Add(nuevoTiro);
        }
        else
        {
            throw new InvalidOperationException("Bola no encontrada. Crea una bola primero.");
        }
    }

    public void CambiarEstrategia(string criterio)
    {
        if (criterio == "FISICA")
        {
            estrategiadeCalculo = new CalculoFisico();
        }
        else if (criterio == "SIMPLE")
        {
            estrategiadeCalculo = new CalculoSimple();
        }
    }

    public void Simular()
    {
        if (bolaActual != null)
        {
            foreach (Tiro tiro in tiros)
            {
                double d = estrategiadeCalculo.CalcularDistancia(bolaActual, tiro);
                distanciaTotal += d;

                double x = tiro.DirX;
                double y = tiro.DirY;
                double magnitud = Math.Sqrt((x * x) + (y * y));

                if (magnitud > 0)
                {
                    double deltaX = (d * x) / magnitud;
                    double deltaY = (d * y) / magnitud;

                    bolaActual.MoverBola(deltaX, deltaY);
                }
            }

            // Limpiamos la lista para no procesar los mismos tiros dos veces
            tiros.Clear();
        }
        else
        {
            throw new InvalidOperationException("Bola no existe");
        }
    }

    public void MostrarResultado()
    {
        if (bolaActual != null)
        {
            Console.WriteLine($"{distanciaTotal}");
            Console.WriteLine($"{bolaActual.PosicionX} {bolaActual.PosicionY}");
        }
    }
}