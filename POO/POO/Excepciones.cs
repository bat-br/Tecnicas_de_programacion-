//Programa para ver excepciones

int divisor = 0;
//int resultado = 10/divisor; //lanza la excepcion

/*try 
{
    int resultado = 10 / divisor;
}
catch(DivideByZeroException ex)
{
    Console.WriteLine(ex.Message);
}
finally
{
    Console.WriteLine("Bloque que siempre se ejecuta");
}*/
try
{
    Console.WriteLine("Introduce un numero entero positivo:");
    int numero = int.Parse(Console.ReadLine() ?? "");
    if (numero < 0)
    {
        throw new ArgumentException ("Esto no es un numero positivo");
    }
}
catch(FormatException ex)
{
    Console.WriteLine("Escribiste algo que no era un numero entero");

}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
}
finally
{
    Console.WriteLine("Siempre se ejecuta");
}