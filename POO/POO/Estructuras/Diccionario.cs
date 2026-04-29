//structura no lineal Diccionario
//Cada clave es unica y tiene un valor asoiado
//No mantiene un orden especifico
//No tiene orden de insercion

//Creacion
Dictionary<string, int> edades = new Dictionary<string, int>();//Dos tipos de datos clave,valor


//Agregar elementos
edades.Add("Ana",25);
edades.Add("Juan", 30);
edades["Maria"] = 28;

//Acceso

int edadAna = edades["Ana"];
Console.WriteLine(edadAna);

//Verificar la eistencia de claves

if (edades.ContainsKey("Carlos"))
{
    Console.WriteLine("Carlos existe");

}
if (edades.ContainsValue(25))
{
    Console.WriteLine("Alguien tiene 25 años");
}

//Intenta obtener el valor de una clave

if (edades.TryGetValue("Juan",out int edadJuan))
{
    Console.WriteLine($"Edad Juan {edadJuan}");
}

//Recorrer diccionario

foreach(KeyValuePair <string,int> kvp in edades)
{
    Console.WriteLine($"{kvp.Key}, {kvp.Value}");
}

foreach(string nombre in edades.Keys)
{
    Console.WriteLine(nombre);
}
foreach (int edad in edades.Values)
{
    Console.WriteLine(edad);
}
edades.Remove("Ana");
foreach(int edad in edades.Values)
{
    Console.WriteLine(edad);
}
Dictionary<string, int[,][]> dic= new Dictionary<string, int[,][]>();