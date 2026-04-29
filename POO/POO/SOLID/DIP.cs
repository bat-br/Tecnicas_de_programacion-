//Prgammra principal sin Aplicar DIP

Console.WriteLine("Fiesta sin aplicar DIP");

new OrganizadorFiesta().IniciarFiesta();

//Aplicando DIP
Console.WriteLine("Fiesta sin aplicar DIP");

new OrganizadorFiestaD(new Fantasma()).IniciarFiesta();

class Vampiro
{
    public void Asustar() => Console.WriteLine("Soy un vampiro...");
}
class OrganizadorFiesta
{
    private Vampiro vampiro = new Vampiro(); //Dependencia directa
    public void IniciarFiesta()
    {
        Console.WriteLine("Inicia la fiesta");
        vampiro.Asustar(); 
    }
}

//Clases aplicando DIP

interface IAsustador
{
    void Asustar();
}
class Fantasma : IAsustador
{
    public void Asustar() => Console.WriteLine("Fantasma asusta... Buu");
}
class VampiroD : IAsustador
{
    public void Asustar() => Console.WriteLine("Vampiro asusta...");
}

class OrganizadorFiestaD
{
    IAsustador asustador;

    public OrganizadorFiestaD(IAsustador asustador)//Tiene que ser clase de monstruo y debe poder asustar
    {
        this.asustador = asustador;
    }
    public void IniciarFiesta()
    {
        Console.WriteLine("Inicia la Fiesta");
        asustador.Asustar();
    }
}