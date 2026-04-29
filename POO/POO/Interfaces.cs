//ejemplo de interfases


//Programa principal
/*IEjemplo algo = new EjemploClase();
algo.HacerAlgo();
Perro perro = new Perro();
perro.HacerSonido();

Animal otroPerro = new Perro();
otroPerro.HacerSonido();

Animal gato = new Gato();
gato.HacerSonido();

Paloma paloma = new Paloma();
paloma.HacerSonido();
paloma.Volar();

Paloma tucan = new Tucan();
tucan.HacerSonido();
tucan.Volar();


//Interfaces

IVolar pajaro = new IPaloma();
IAnimal otropajaro = new IPerro();

Dragon dragon = new Dragon();
dragon.HacerSonido();
dragon.Volar();*/


//Declaracion
public interface IEjemplo
{
    //Definicion de metodos
    void HacerAlgo();


    //metodo de implementacion predeterminada

    public void HacerAlgomas()
    {
        Console.WriteLine("Haciendo algo mas");
    }
}

public class EjemploClase : IEjemplo// lo mismo que una herencia
{
    public void HacerAlgo()
    {
        Console.WriteLine("Haciendo algo");
    }
}
public class Animal
{
    public void Respirar()
    {
        Console.WriteLine("Estoy respirando");
    }
    public virtual void HacerSonido()
    {
        Console.WriteLine("El animal hace sonido");
    }
}

//Clase hijas
public class Perro : Animal
{
    public void Ladrar()
    {
        Console.WriteLine("Gua gua");

    }
    public override void HacerSonido()
    {
        Ladrar();
    }
        }
public class Gato : Animal
{
    public override void HacerSonido()
    {
        Console.WriteLine("Miau");
    }
}
public class Tucan :Paloma //Es hijo de paloma
{

}
public class Paloma : Animal
{
    public override void HacerSonido()
    {
        Console.WriteLine("Sonidos de paloma");
    }
    public void Volar()
    {
        Console.WriteLine("Paloma Volando");
    }
}

//Usando interfaces
public interface IAnimal
{
    void HacerSonido();

}
public interface IVolar
{
    void Volar();
}
public class IPerro : IAnimal
{
    public void HacerSonido()
    {
        Console.WriteLine("Gua Gua");
    }
}
public class IPaloma : IAnimal , IVolar
{
    public void HacerSonido()
    {
        Console.WriteLine("Sonidos de paloma");
    }
    public void Volar()
    {
        Console.WriteLine("Volando");
    }
}
public class IColibri : IAnimal, IVolar //Como  herencia multiple
{
    public void HacerSonido()
    {
        Console.WriteLine("Sonidos de colibri");
    }
    public void Volar()
    {
        Console.WriteLine("Volando en colibri");
    }
}
public class Dragon : Animal , IVolar //Puede heredar de la forma convencional pero tambien puede usar la interfaz
{
    public void Volar()
    {
        Console.WriteLine("Volando en dragon");
    }
}