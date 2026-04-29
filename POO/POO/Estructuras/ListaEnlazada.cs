//lista enlazada
//funciona como una lista, cada elemento tiene un valor y un puntero al siguiente elemento


LinkedList<string> frutas = new LinkedList<string>();

//Agregar nodos

frutas.AddLast("Mango");
frutas.AddFirst("Mandarina");
frutas.AddLast("Sandia");
frutas.AddLast("Uva");

foreach (string frut in frutas)
{
    Console.WriteLine(frut);
}
//Recorrer mostrando enlaces

Console.WriteLine("Frutas en lista enlazada");

LinkedListNode<string> actual = frutas.First;
/*while(actual != null)
{
    string anterior = actual.Previous?.Value ??"null";
    string siguiente = actual.Next?.Value ??"null";
    Console.WriteLine($"[{anterior}] <- {actual.Value} -> [{siguiente}]");
    actual = actual.Next;
}*/

LinkedListNode<string> nodoNuevo = frutas.Find("Uva");
frutas.AddBefore(frutas.First,"Mango");
frutas.AddAfter(nodoNuevo, "Tuna");
while (actual != null)
{
    string anterior = actual.Previous?.Value ?? "null";
    string siguiente = actual.Next?.Value ?? "null";
    Console.WriteLine($"[{anterior}] <- {actual.Value} -> [{siguiente}]");
    actual = actual.Next;
}