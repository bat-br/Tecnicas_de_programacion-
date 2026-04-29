//Un sistema de vacunas en una veterinaria
Console.WriteLine("Caso 1 mascota comun:");
var sistema = new SistemaVeterinaria();
sistema.AtenderMascota("Juanito", "Perro", 2);

Console.WriteLine("Caso 2 mascota comun no contemplado:");
var sistema2 = new SistemaVeterinaria();
sistema.AtenderMascota("Jorgito", "Ave", 3);

Console.WriteLine("Caso 3 mascota no especial:"); //Hay una dependecia ¿Como la soluciono?
SistemaVeterinaria sistema3 = new SistemaVeterinariaEspecial();
sistema.AtenderMascota("Rex", "Perro", 8);

Console.WriteLine("Caso 4 mascota no especial:");
SistemaVeterinaria sistema4 = new SistemaVeterinariaEspecial();
sistema.AtenderMascota("Bolillo", "Cocodrilo", 20);

//Clases dominio


public class Mascota //La clase mascota debe ser lo mas generica posible
{
    public string Nombre { get; set; }
    public string Tipo { get; set; }
    public int Edad {  get; set; }

    public Mascota (string nombre, string tipo, int edad)
    {
        Nombre = nombre;
        Tipo = tipo;
        Edad = edad;
    }
    public bool EsValida() //Esto podria ser una interfaz para no saturar la clase mascota (SRP)
    {
        return !string.IsNullOrEmpty(Nombre) && Edad > 0;
    }
    public decimal CalcularVacuna() //Este metodo podria cambiarse por una interfaz(Principio Abierto/Cerrado)
    {
        if (Tipo.StartsWith("P")) return 200;
        if (Tipo.StartsWith("G")) return 180;
        if (Tipo.StartsWith("Tuga")) return 400;

        return Edad * 50;
    }
}
public class EmailServie
{
    public void Enviar(string mensaje)
    {
        Console.WriteLine($"Enviando correo: {mensaje}");
    }
}
public class Notificador //Esto podria ser una interfaz que solo diga que se va hacer
{
    private EmailServie email = new EmailServie();

    public void Notificar(Mascota mascota)
    {
        email.Enviar($"Mascota info : {mascota.Nombre} | ${mascota.CalcularVacuna():0.00}");
    }
}
public class SistemaVeterinaria //Principio LSP
{
    private List<Mascota> mascotas = new List<Mascota>();
    Notificador notificador = new Notificador(); //Se implementa el metodo  notificador  con lo que va hacer

    public virtual void  AtenderMascota(string nombre, string tipo, int edad)
    {
        var mascota = new Mascota(nombre, tipo, edad);
        if (!mascota.EsValida())
        {
            Console.WriteLine("Mascota no se puede registrar"); //Mejor lanzamos una excepcion para no romper el propgrama
            return;
        }

        mascotas.Add(mascota);
        decimal costo = mascota.CalcularVacuna();
        notificador.Notificar(mascota);

        Console.WriteLine("Resumen de lista de mascotas| Reporte:"); //Se podria dividir los metodo en una clase para poder no saturar la clase
        foreach (var m in mascotas)
        {
            Console.WriteLine($"{m.Nombre}- {m.Tipo}");
        }

    }
}

public class SistemaVeterinariaEspecial : SistemaVeterinaria //Esta clase se debe modificar para que solo reciba una clase de mascota 
{
    public override void AtenderMascota(string nombre, string tipo, int edad)
    {
        if(tipo == "Perro")
        {
            Console.WriteLine("Los perros  no se atienden en este sistema");
            throw new Exception("Sistema incorrecto");
        }
       base.AtenderMascota(nombre, tipo, edad);
    }
}