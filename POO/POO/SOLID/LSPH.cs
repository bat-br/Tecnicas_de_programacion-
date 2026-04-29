//Sin aplicar LSP

//Programa principal

List<Monstruo> monstruoss = new()
{
    new Vampiro("Edward"),
    new CalabazaDecorativa("John")
};
Console.WriteLine("Fiesta sin aplicar Lisk");
foreach (var m in monstruoss)
{
    m.Asustar();
}
//Programa con LSP


List<IAsustable> asustables = new()
{
    new VampieroLSP("Edward")
};
foreach (var a in asustables)
{
    a.Asustar();
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
    public Vampiro(string nombre) : base(nombre) { }

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
//Aplicando LSP

public abstract class MonstruoLSP
{
    public string Nombre { get; set; }
    public MonstruoLSP(string nombre)
    {
        Nombre = nombre;
    }
}
public interface IAsustable
{
    void Asustar();
}

public class VampieroLSP : MonstruoLSP, IAsustable
{
    public VampieroLSP(string nombre) : base(nombre) { }

    public void Asustar()
    {
        Console.WriteLine($"{Nombre}: Se transforma en murcielago");
    }
}
public class CalabazaDecorativaLPS : MonstruoLSP
{
    public CalabazaDecorativaLPS(string nombre) : base(nombre) { }

    public void Brillar() => Console.WriteLine($"{Nombre} calabaza brilla");
}