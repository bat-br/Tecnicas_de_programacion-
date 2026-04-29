//Declarcion

int[] numeros = new int[5];
string[] palabras = new string[3] { "Hola", "mundo", "adios" };

//Acceso

int primerNumero = numeros[0];
palabras[1]  = "universo";

//Array multidimensional

int[][] matriz = new int[3][];//Jagged array un arreglo de un arreglo
int[,] matriz2 = new int[3,3]; //Forma correcta

int[,] matrizInicializada = { { 1,2,3}, {4,5,6 },{7,8,9 } };

//Aceso
for (int i = 0; i < 2; i++)
{
    for (int j = 0; j < 2; j++)
    {
        Console.WriteLine(matrizInicializada[i, j]);
    }
    Console.WriteLine("\n");
}

int[][] jaggedArray = new int[3][];

//Asignar elementos
jaggedArray[0] = new int[] { 1, 2 };
jaggedArray[1] = new int[2];
jaggedArray[2] = new int[] { 6 };

//Acceder a los elementos

foreach (int[] arreglo in jaggedArray)
{
    foreach (int j in arreglo)
    {
        Console.Write(j);
    }
    Console.WriteLine("\n");
}