//Pila
//Se conoce como LIFO ultimo en entrar primero en salir 
//Solo se puede acceder al elemento superior
//no permite busquedas

//Crear


Stack<string> pila = new Stack<string>();

//Apilar

pila.Push("Primero");
pila.Push("Segundo");
pila.Push("Tercero");

foreach(string s in pila)
{
    Console.WriteLine(s);
}

//Pop

string ultima = pila.Pop(); //Devuelve el valor y elimina el valor de la pila

foreach (string s in pila)
{
    Console.WriteLine(s);
}
string superior = pila.Peek();//Ve el elemento sin eliminar
foreach (string s in pila)
{
    Console.WriteLine(s);
}