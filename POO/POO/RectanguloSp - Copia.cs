//Si una clase B es hija de la clase A, entonces B se dbe poder usar donde esperamos A

//Sin usar LSP

//Programa principal usndo rectangulo y cuadrado

//Upper casting, convertir un cuadrado a un rectangulo

using System.Runtime.Intrinsics.X86;

Rectangulo rectangulo = new Cuadrado();
rectangulo.Alto = 4;
rectangulo.Ancho = 5;
Console.WriteLine(rectangulo.CalcularArea());

//Usando LSP
Forma rectanguloLSP = new RectanguloLSP { Ancho = 4, Alto = 4 };
Forma cuadradoLSP = new CuadradoLSP {Lado = 4};

ImprimirArea(rectanguloLSP);
ImprimirArea(cuadradoLSP);


static void ImprimirArea(Forma forma)
{
    Console.WriteLine($"El area esa {forma.CalcularArea}");
}
public class Rectangulo
{
    public virtual int Ancho { get; set; }
    public virtual int Alto { get; set; }

    public int CalcularArea()
    {
        return Ancho * Alto;
    }
}

public class Cuadrado : Rectangulo
{
    public override int Ancho { set { base.Ancho = base.Alto = value; } }
    public override int Alto { set { base.Ancho = base.Alto = value; } }


}
public class RectanguloLSP : Forma
{
    public int Ancho { get; set; }
    public int Alto { get; set; }
}
public abstract class Forma
{
    public abstract int CalcularArea();
}