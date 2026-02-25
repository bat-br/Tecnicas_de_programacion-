public class Rectangulo
{
    //Atributos
    public float Base { get; set; }
    public float Altura { get; set; }

    //Constructor
    public Rectangulo (float basee, float altura)
    {
        Base = basee;
        Altura = altura;
    }


    //Metodos
    public void Area()
    {
        Console.WriteLine($"El perimetro es: { 2f * (Base + Altura)}");
    }
    public void Perimetro()
    {
        float Calculararea;
        Calculararea = Base * Altura;
        Console.WriteLine($"El area es: { Calculararea}");

    }
}