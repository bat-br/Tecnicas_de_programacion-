//Arbol

//N nodos
//N-1 arista
//Longitud - Ruta de la cantidad de arista que contiene

//Arbol binario (2 nodos como maximo de hijos)

//-Datos Nombres de persona
//-Hijos izq : primer hijo
//-Hijo derecho : segundo hijo

//Recorrer arbol
//Preorden (Padre -> hijo Izq -> Hijo derecho)
//Indorden( Hijo izq -> Padre -> hijo derecho
//PostOrden (Hijo izq -> Hijo Derecho -> padre)



var arbol = new ArbolBinario("Juan");
arbol.Raiz.InsertarHijo("Ana", true);
arbol.Raiz.InsertarHijo("Luis", false);

arbol.Raiz.HijoIzquierdo.InsertarHijo("Sofia", true);
arbol.Raiz.HijoIzquierdo.InsertarHijo("Pedro", false);
arbol.Raiz.HijoDerecho.InsertarHijo("Carlos", true);

//Arbol construido
Console.WriteLine("Arbol constuido");
arbol.ImprimirArbol(arbol.Raiz);

Console.WriteLine();

Console.WriteLine("Preorden");
arbol.RecorrerPreOrden(arbol.Raiz);
Console.WriteLine();

Console.WriteLine("Inorden");
arbol.RecorrerInOrden(arbol.Raiz);
Console.WriteLine();

Console.WriteLine("Postorden");
arbol.RecorrerPostOrden(arbol.Raiz);
Console.WriteLine();

//Clase para crear nodo en el arbol
public class NodoArbol
{
    public string Nombre { get; set; }
    public NodoArbol HijoIzquierdo {get; set; }
    public NodoArbol HijoDerecho { get; set; }

    public NodoArbol(string nombre)
    {
        Nombre = nombre;
    }
    public void InsertarHijo(string nombreHijo, bool esHijoIzquierdo)
    {
        if (esHijoIzquierdo)
        {
            HijoIzquierdo = new NodoArbol(nombreHijo);
        }
        else
        {
            HijoDerecho= new NodoArbol(nombreHijo);
        }
    }
}


//Clase para construr el arbol

public class ArbolBinario
{
    public NodoArbol Raiz {  get; set; }

    public ArbolBinario(string nombreRaiz)
    {
        Raiz = new NodoArbol(nombreRaiz);
    }
    public void ImprimirArbol(NodoArbol nodo, string prefijo = "", bool esUltimo= true)
    {
        if (nodo == null) return;

        Console.WriteLine(prefijo);
        Console.WriteLine(esUltimo ? "+--": "| --");
        Console.WriteLine(nodo.Nombre);

        string nuevoPefijo = prefijo + (esUltimo ? "    " : "|     ");
        if(nodo.HijoIzquierdo != null || nodo.HijoDerecho != null)
        {
            ImprimirArbol(nodo.HijoIzquierdo, nuevoPefijo,nodo.HijoDerecho == null);
            ImprimirArbol(nodo.HijoDerecho, nuevoPefijo, true);
        }
    }

    public void RecorrerPreOrden(NodoArbol nodo, bool esPrimero = true)
    {
        if (nodo == null) return;
        if(!esPrimero )
        {
            Console.WriteLine("--");
        }
        Console.Write(nodo.Nombre);
        RecorrerPreOrden(nodo.HijoIzquierdo, false);
        RecorrerPreOrden(nodo.HijoDerecho,false);
    }
    public void RecorrerInOrden(NodoArbol nodo, bool esPrimero = true)
    {
        if (nodo == null) return;
        RecorrerInOrden(nodo.HijoIzquierdo , false);

        if (!esPrimero)
        {
            Console.WriteLine("--");
        }
        Console.Write(nodo.Nombre);
        RecorrerInOrden(nodo.HijoDerecho, false);
    }
    public void RecorrerPostOrden(NodoArbol nodo, bool esPrimero = true)
    {
        if (nodo == null) return;
        RecorrerPostOrden(nodo.HijoIzquierdo, false);
        RecorrerPostOrden(nodo.HijoDerecho, false);
        if (!esPrimero)
        {
            Console.WriteLine("--");
        }
        Console.Write(nodo.Nombre);
    }
}