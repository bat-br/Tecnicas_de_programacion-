//Sin aplicar LSP

//Programa principal

List<Monstruo> monstruoss = new()
{
    new Vampiro("Edward"),
    new CalabazaDecorativa("John")
};
Console.WriteLine("Fiesta om aplicar Lisk");
foreach(var m in monstruoss)
{

}

public class Monstruo //Es lo más generico que se me esta ocurriendo
{
    public string Nombre { get; set; }

    public Monstruo(string nombre) => Nombre = nombre;

    public virtual void Asustar()
    {
        Console.WriteLine($"{Nombre} intenta asustar...");
    }
}

public class Vampiro : Monstruo
{
    public Vampiro(string nombre) : base(nombre) {}

    public override void Asustar()
    {
        Console.WriteLine($"{Nombre}: Se transforma en murcielago");
    }
}

public class CalabazaDecorativa : Monstruo
{
    public CalabazaDecorativa(string nombre) : base(nombre) { }

    public override void Asustar()
    {
       //Esta clase no debería de asustar 
       throw new NotImplementedException("Las calabazas decorativas no pueden asustar");
    }
}