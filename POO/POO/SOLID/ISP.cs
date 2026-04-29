//Sin aplicar ISP 

interface IMonstruo
{
    void Asustar();
    void Volar();
    void Lanzarhechizo();
}
class  Fantasma : IMonstruo
{
    public void Asustar() => Console.WriteLine("Buuu");
    public void Volar() => Console.WriteLine("Fantasma Levita");
    public void Lanzarhechizo() => throw new NotImplementedException("No puede lanzar hechizos");
}
class Bruja : IMonstruo
{
    public void Asustar() => Console.WriteLine("Risa Macabra");
    public void Volar() => Console.WriteLine("Vuela sobre su escoba");
    public void Lanzarhechizo() => Console.WriteLine("Te convierte en chocolate");
}

//Aplicando SLI
interface IAsustador
{
    void Asustar();
}
interface IVolador
{
    void Volar();
}
interface IHechichero
{
    void LanzarHechizo();
}
class FantasmaI : IAsustador,IVolador
{
    public void Asustar() => Console.WriteLine("Buuu");
    public void Volar() => Console.WriteLine("Fantasma Levita");
}
class BrujaI : IAsustador, IVolador, IHechichero
{
    public void Asustar() => Console.WriteLine("Risa Macabra");
    public void Volar() => Console.WriteLine("Vuela sobre su escoba");
    public void LanzarHechizo() => Console.WriteLine("Te convierte en chocolate");
}