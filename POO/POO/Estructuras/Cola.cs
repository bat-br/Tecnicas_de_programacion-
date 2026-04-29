//Cola (Queue)
//FIFO primero en entrar primero en salir
//Solo accede el primer elemento
//No permite la busqueda

//Crear

Queue<string> cola = new Queue<string> ();

//Añadir elementos
cola.Enqueue("Primero");
cola.Enqueue("Segundo");
cola.Enqueue("Tercero");

foreach ( string s in cola)
{
    Console.WriteLine(s);
}

string primerElemento = cola.Dequeue(); //Devuelve el valor y lo elimina
string frontal = cola.Peek(); //Devuelve el elemento sin eliminar
