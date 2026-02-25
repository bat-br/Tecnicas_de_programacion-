//Programa principila con instrucciones de nivel superior

Auto auto1 = new Auto();
auto1.Marca = "Honda";
auto1.Modelo = "Civic";
auto1.VelocidadActual = -60.3f;
Console.WriteLine($"La marca del auto es : {auto1.Marca}");
auto1.Acelerar(10.0f);
Console.WriteLine($"La velocidad es : {auto1.VelocidadActual}");
auto1.Frenar(-100.0f);
Console.WriteLine($"La velocidad es : {auto1.VelocidadActual}");

Vehiculo vehiculo = new Vehiculo("algo", "otracosa");
vehiculo.Modelo = "Otro modelo";
AutoH autoH = new AutoH("Ford","Mustang");
autoH.Marca = autoH.Marca;
Motocicleta moto = new Motocicleta("Yamaha", "Mt07");

autoH.Acelerar(50.0f);
moto.Acelerar(60.0f);

moto.Frenar(70.0f);

//Aplica sobrecarga de operadores
if(autoH > moto)
{
    Console.WriteLine($"Auto mas rapido: {autoH.VelocidadActual}");

}
else if (autoH<moto)
{
    Console.WriteLine($"Moto mas rapida: {moto.VelocidadActual}");
}
else if (autoH == moto)
{
    Console.WriteLine($"Van a la misma velocidad");
}
public class Vehiculo
{
    //Atributos
    protected string marca;
    protected string modelo;
    protected float velocidadactual;

    //Atributos publicos con control


    public virtual string Marca
    {
        get { return marca; }
        set { marca = value; }
    }
    public string Modelo
    {
        get { return modelo; }
        set { modelo = value; }
    }
    public float VelocidadActual //Nos sirve para  ponerle indicaciones dentro del set o get especificas
    {
        get { return velocidadactual; }
        set
        {
            if (value < 0)
            {
                velocidadactual = 0;
            }
            else
            {
                velocidadactual = value;
            }
        }
    }
    //Contructor (si tu estancias un objeto necesitas declarar aqui,tiene que poder pasarle esos parametros al objeto)
    public Vehiculo(string marca, string modelo)
    {
        this.marca = marca; // cuando instancias de una clase vehiculo, pero si instancias un auto el this ayuda  a pasar los atributos
        this.modelo = modelo;
        this.velocidadactual = 0.0f;
    }
   
    //Metodo
    public void Acelerar(float incremeto)//Si lleva un parametro puedes operar ee parametro dentro 
    {
        VelocidadActual += incremeto;
    }

    public void Frenar(float decremento)
    {
        VelocidadActual -= decremento;
    }

    //Sobrecarga de los operadores >< == para comparar velocidades
    public static bool operator > (Vehiculo v1, Vehiculo v2) //Me regresa un true o un false
    {
        return v1.velocidadactual > v2.velocidadactual;

    }
    public static bool operator <(Vehiculo v1, Vehiculo v2) //Me regresa un true o un false
    {
        return v1.velocidadactual < v2.velocidadactual;

    }
    public static bool operator == (Vehiculo v1, Vehiculo v2) //Me regresa un true o un false
    {
        return v1.velocidadactual == v2.velocidadactual;

    }
    public static bool operator !=(Vehiculo v1, Vehiculo v2) //Me regresa un true o un false
    {
        return v1.velocidadactual != v2.velocidadactual;

    }




}
public class AutoH : Vehiculo //Clase hijo
{
    public AutoH(string marca, string modelo) : base(marca, modelo) { }//Va haber una herencia de la clase base que es la padre

    //ATRIBUTOS PUBLICOS CON CONTROL
    public override string Marca
    {
        get {
            Console.WriteLine($"La marca del auto es {marca}");
            return marca;
            }
        set { marca = value; }
    }
}

public class Motocicleta : Vehiculo
{
    //Constructor
    public Motocicleta(string marca, string modelo) : base(marca, modelo) { }
   
}





public class Auto
{
    //Atributos

    private string marca;
    private string modelo;
    private float velocidadactual;
    
    //Atributos publicos con control


    public string Marca
    {
        get { return marca; }
        set { marca = value; }
    }
    public string Modelo
    {
        get { return modelo;}
        set { modelo = value; }
    }
    public float VelocidadActual //Nos sirve para  ponerle indicaciones dentro del set o get especificas
    {
        get { return velocidadactual; }
        set{
            if(value<0)
            {
                velocidadactual = 0;
            }
            else
            {
                velocidadactual = value;
            }
        }
    }
    //Contructor si tu estancias un objeto necesitas declarar aqui

    //Metodo
    public void Acelerar(float incremeto)//Si lleva un parametro puedes operar ee parametro dentro 
    {
        VelocidadActual += incremeto; 
    }

    public void Frenar(float decremento)
    {
        VelocidadActual -= decremento;
    }
}