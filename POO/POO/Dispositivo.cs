Lampara lampara = new Lampara("Lamparita",80,40);
Ventilador ventilador = new Ventilador("Aire", 500, 50);

//Encender ambos dispositivos

lampara.Encender();
ventilador.Encender();

//Mostrar informacion
Console.WriteLine(lampara.MostrarInfo());
Console.WriteLine(ventilador.MostrarInfo());


//Austamos consumo
lampara.AjustarConsumo();
ventilador.AjustarConsumo(-6);

//Comparacion con operadores

if (lampara > ventilador)
{
    Console.WriteLine("Lampara consume mas");
}
else if (lampara < ventilador)
{
    Console.WriteLine("Ventilador consume mas");
}
else
{
    Console.WriteLine("Ambos consumen la misma energia");
}




public class Dispositivo
{
    //Atributos
    private string nombre;
    private bool encendido;
    private int consumo;

    
    public string Nombre 
    {
        get { return nombre; } //Devuelve el valor de la variable
        set { nombre = value; } //Le asigna el valor a la variable
    }
    public bool Encendido
    {
        get { return encendido; }
        set { encendido = value; }
    }
    public int Consumo
    {
        get { return encendido ? consumo : 0; }//si va regresar un valor atravez de obtener un valor, el valor de la variable encendido la voy a cuestionar y solo me va funcinar si es bool
       //Solo consume si esta encendido
        set
        {
            if (value <0)
            {
                consumo = 0;
            }
            else
            {
                consumo = value;
            }
        }
    }

    //Constructor
    public Dispositivo(String nombre, int consumo)
    {
        this.nombre = nombre; //el atributo nombre va tener el mismo valor del parametro nombre que recibi
        this.consumo = consumo;
        this.encendido = false;
    }

    //Metodos
    public void Encender ()
    {
        Encendido = true;
    }
    public void Apagar ()
    {
        Encendido = false;
    }
     

    //Sobrecarga
    public void AjustarConsumo()
    {
        Consumo = 100;
    }
    public void AjustarConsumo(int nuevoConsumo)
    {
        Consumo = nuevoConsumo;
    }

    public virtual string MostrarInfo()
    {
        return $"Dispositivo: {Nombre}, Encendido: {Encendido}, Consumo: {Consumo} W";
    }

    //Sobrecarga de operadores

    public static bool operator >(Dispositivo d1, Dispositivo d2)//En el parentesis deb decir que voy a usar 
    {
        return d1.Consumo > d2.Consumo;
    }
    public static bool operator <(Dispositivo d1, Dispositivo d2)
    {
        return d1.Consumo < d2.Consumo;
    }
    public static bool operator ==(Dispositivo d1, Dispositivo d2)
    {
        return d1.Consumo == d2.Consumo;
    }
    public static bool operator !=(Dispositivo d1, Dispositivo d2)
    {
        return d1.Consumo != d2.Consumo;
    }
}




public class Lampara : Dispositivo
{
    //Atributos
    private int intensidad;

    //Constructor
    public Lampara(String nombre, int consumo, int intensdad) : base (nombre, consumo)//Si estas diciendo que es hijo de la clase, entonces le damos la base osea los parametros que puede usar
    {
        this.intensidad = intensdad;
    }

    //Metodos

    public override string MostrarInfo()
    {
        /*return base.MostrarInfo();//Te retorno lo mismo que dice el padre*/
        return $"Lampara: {base.MostrarInfo()}, Intensidad: {intensidad}";
    }

}




public class Ventilador : Dispositivo
{
    //Atributos
    private int velocidad;

    //Constructor
    public Ventilador(String nombre, int consumo, int velocidad) : base(nombre, consumo)//Si estas diciendo que es hijo de la clase, entonces le damos la base osea los parametros que puede usar
    {
        this.velocidad = velocidad;
    }

    //Metodos

    public override string MostrarInfo()
    {
        /*return base.MostrarInfo();//Te retorno lo mismo que dice el padre*/
        return $"Ventilador: {base.MostrarInfo()}, Nivel de velocidad {velocidad}";
    }

}
