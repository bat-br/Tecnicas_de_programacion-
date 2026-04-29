//Implementacion juego
try
{
    Console.WriteLine("Bienvenido al Torneo de guerreros!");
    string nombre = ObtnerNombre();

    Guerrero jugador = SelecconarClase(nombre);
    Guerrero enemigo = GeneraEnemigo();
    Console.WriteLine($"Te enfrentas a {enemigo.Nombre}");

    while(enemigo.Vida>0 && jugador.Vida>0)// se va ejecutar siempre y cuando los dos tenga vida, cuando uno o los dos no tengan vida se va volver false
    {
        MostarEstado(jugador, enemigo);
        string opcion = ObtenerOpcion();
        switch(opcion)
        {
            case "1":
                jugador.Atacar(enemigo);
                break;

            case "2":
                Console.WriteLine($"{jugador.Nombre} se defiende y el daño se reduce ");
                enemigo.Atacar(jugador);
                jugador.RecibirDanio(jugador.Ataque /2);
                break;

             case "3":
                Console.WriteLine("Intentando la fusión");
                if(new Random().Next(1,100)>50)
                {
                    jugador = jugador + enemigo;
                    Console.WriteLine($"Tu nuevo nombre es {jugador.Nombre} | {jugador.Vida} | {jugador.Ataque}");
                    enemigo.RecibirDanio(jugador.Vida/2);
                }
                else
                {
                    Console.WriteLine("Fallaste la fusion y perdiste");
                    jugador.RecibirDanio(jugador.Vida/2 );
                }
                    break;
            default:
                throw new ArgumentException("Opcion invalida");
        }
        if (enemigo.Vida> 0)
        {
            enemigo.Atacar(jugador);
        }
    }
    Console.WriteLine("Fin del combate");
    Console.WriteLine(jugador.Vida > 0 ? "Felicidades ganaste" : "Has sido derrotado");
   
}

catch(Exception ex)
{
    Console.WriteLine(ex.Message);
}
static string ObtnerNombre()
{
    while(true)
    {
        try
        {
            Console.WriteLine("Ingresa nombre de guerrero :");
            string nombre = Console.ReadLine() ?? "".Trim();
            if(string.IsNullOrEmpty(nombre))
            {
                throw new ArgumentException("El nombre no puede estar vacio");
            }
            return nombre;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
static string ObtenerOpcion()
{
    while(true)
    {
        try
        {
            Console.WriteLine("Ingresa que quieres hacer:");
            string opcion = Console.ReadLine() ?? "".Trim();
            if(opcion != "1" && opcion  != "2" && opcion != "3")
            {
                throw new ArgumentException("Opcion invalida, debes ingresar 1, 2 o 3");
            }
            return opcion;
        }
        catch(Exception ex) 
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
//Apartado de funcioes
static Guerrero SelecconarClase(string nombre)
{
    while(true)
    {
        try
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Selecciona tu clase");
            Console.WriteLine("1-Caballero");
            Console.WriteLine("2- Mago");
            Console.WriteLine("3- Arquero");
            Console.WriteLine("4- Guerrero sombra");

            string opcion = Console.ReadLine()  ??"";

            return opcion switch
            {
                "1" => new Caballero(nombre),
                "2" => new Mago(nombre),
                "3" => new Arquero(nombre),
                "4" => new GuerreroSombra(nombre),
                _ => throw new ArgumentException("Opcion invalida, intenta nuevamente")

            };
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex.Message}");
        }
    }
}
static Guerrero GeneraEnemigo()
{
    string[] nombres = { "CJ", "Spriu", "Terminator", "Mikey mouse", "Shrek", "Zeus" };
    string nombre = nombres[new Random().Next(nombres.Length)];
    return new Guerrero(nombre, new Random().Next(150, 200), new Random().Next(30, 50));
}
static void MostarEstado(Guerrero jugador, Guerrero enemigo)
{
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine($"Tu vida: {jugador.Vida} | Vida enemigo: {enemigo.Vida}");
    Console.WriteLine("1- Atacar");
    Console.WriteLine("2- Defender");
    Console.WriteLine("3- Fusionarse con el enemigo");
}

//definicion de clases

public class Guerrero
{
    //Atributos
    public string Nombre {get; set;}
    public int Vida { get; set;}
    public int Ataque {  get; set;}
    //Contructor
    public Guerrero(string nombre, int vida, int ataque)//Padre asi se declara 
    {
        Nombre = nombre;
        Vida = vida;    
        Ataque = ataque;
    }

    //Metodos
    public virtual void Atacar(Guerrero enemigo/*A quien vas atacar*/) //Poliformismo con virtual
       
    {
        int danio = Ataque + new Random().Next(-3,5);
        //Recibir daño 
        enemigo.RecibirDanio(danio);//primero va el daño y se guarda para luego su valor se va a cantidad
        Console.WriteLine($"{Nombre} ataca a  {enemigo.Nombre} causa {danio} y te quedan {enemigo.Vida} de vida");

    }
    public void RecibirDanio(int cantidad)
    {

        Vida = Math.Max(Vida - cantidad,0);//Va calcular la resta pero solo hay un tope que es 0 si es 0 me regresa el 0

    }
    //sobrecarga del operador +
    public static Guerrero operator + (Guerrero g1, Guerrero g2)
    {
        Console.WriteLine($"{g1.Nombre} + {g2.Nombre}");
        return new Guerrero($"{g1.Nombre}--{g2.Nombre}",(g1.Vida+g2.Vida)/2, (g1.Ataque + g2.Ataque) / 2);
    }
}
//Clase caballero
public class Caballero : Guerrero
{
    //Constructor
    public Caballero(string nombre) : base(nombre, 120, 20) { } //Solo te pide el nombre lo demás ya esta

    //Polimorfismo
    public override void Atacar(Guerrero enemigo)
    {
        Console.WriteLine($"{Nombre} usa golpe crítico");
        base.Atacar(enemigo);
    }
}

//Clase mago
public class Mago : Guerrero
{
    public Mago(string nombre) : base(nombre, 80, 25) { }
    public override void Atacar(Guerrero enemigo)
    {
        Console.WriteLine($"{Nombre} lanza hechizo de fuego");
        base.Atacar(enemigo);
    }
}
public class Arquero : Guerrero
{
    public Arquero(string nombre) : base(nombre, 90, 15) { }
    public override void Atacar(Guerrero enemigo)
    {
        int probabilidad = new Random().Next(1,100);
        if (probabilidad < 30)
        {
            Console.WriteLine($"{Nombre} dispara la flecha y falla");
        }
        else
        {
            Console.WriteLine($"{Nombre} lanza una flecha");
            base.Atacar(enemigo);
        }
    }
}
public class GuerreroSombra : Guerrero
{
    public GuerreroSombra(string nombre) : base(nombre, 110, 22) { }
    public override void Atacar(Guerrero enemigo)
    {
        int chance = new Random().Next(1, 100);
        if (chance < 20)
        {
            Console.WriteLine($"{Nombre} desaparece");
        }
        else
        {
            Console.WriteLine($"{Nombre}ataca");
            base.Atacar(enemigo);
        }
    }
}