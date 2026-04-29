//Listas

//Son dinamicas

List<int> numeros = new List<int> ();
List<string> palabras = new List<string> { "Hola","Mundo","adios"};

numeros.Add(10);
numeros.AddRange(new int[] { 20, 30, 40 });

foreach ( int numero in numeros )
{
    Console.WriteLine( numero );  
}
//numeros[1] = 60;
//Console.WriteLine(numeros[1]);

//Insertar

numeros.Insert(2,25);
foreach (int numero in numeros)
{
    Console.WriteLine(numero);
}
numeros.Remove(20); //Elimina el elemento con ese valor
numeros.RemoveAt(3);//Elimina el elemento en ese indice
foreach (int numero in numeros)
{
    Console.WriteLine(numero);
}

bool existe = numeros.Contains(20);
int indice = numeros.IndexOf(40);
int mayor15 = numeros.Find(x => x > 15);
List<int> mayores = numeros.FindAll(x => x > 25);