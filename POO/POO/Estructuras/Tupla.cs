//Tupla 

//No son estructuras, son una forma de agrupa datos heterogeneos
//Tamaño fijo
//inmutable
//Limite de elementos 8

//Tupla con nombres
(string, int) personal = ("Ana", 25);

//Tupla con nombres
(string Nombre, int Edad) persona2 = ("Juan", 30);
//Acesso a elementos

Console.WriteLine(personal.Item1);
Console.WriteLine(persona2.Nombre);

//Devolver tupla metodo

static (int, int) Dividir(int dividiendo, int divisor)
{
    return (dividiendo / divisor, dividiendo % divisor);
}
var resultado = Dividir(10, 3);
Console.WriteLine($"Cociente: {resultado.Item1} | Modulo: {resultado.Item2}");