//Arreglos

//Declaracion con tamaño explicito
using static System.Runtime.InteropServices.JavaScript.JSType;

int [] numeros = new int[2];

//Asignar elementos al arreglo

numeros[1] = 8; //Atravez del indice

//Obtener valores
if (numeros[0] ==0)
{
    Console.WriteLine("Hay un cero ");
}

// Obtner la longitud del arreglo

Console.WriteLine(numeros.Length);

//Declaracion implicita

int[] numeros2 = new int[] { 4, 5, 3, 6, 5 };
Console.WriteLine(numeros2[3]);
char[] vocales = new[] { 'a', 'e', 'i', 'o', 'u' };

for (int i =0; i<vocales.Length; i++)
{
    Console.WriteLine(vocales[i]);
}
foreach(char c in vocales)
{
    Console.WriteLine(c);
}

bool [] estado = new bool[3];//Tiene 3 elementos y el primitivo tiene false o true 

foreach (bool b in estado)
{
    Console.WriteLine(b);
}
//Metodos arreglos
Console.WriteLine("Desorenado");
foreach (int numero in numeros2)
{ 
    Console.WriteLine(numero);

}
Array.Sort(numeros2);//Ordena el arreglo
Console.WriteLine("Ordenado");
foreach (int numero in numeros2)
{
    Console.WriteLine(numero);

}
Console.WriteLine("Otro orden");
Array.Reverse(numeros2);
foreach (int numero in numeros2)
{
    Console.WriteLine(numero);

}
Array.Sort(numeros2);
//Metodo para buscar un valor 
int indicie = Array.BinarySearch(numeros2, 6);
Console.WriteLine(indicie);

//Lista
List <int> numeros3 = new List<int>();
numeros3.Add(0);
numeros3.Add(20);
foreach (int numero in numeros3)
{
    Console.WriteLine(numero);
}