//Principal
//La lista es dinamica y el arreglo debo decirle cuantos espacios hay
Inventario inventario = new Inventario();
bool salir = false;
while(!salir)
{
    try
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Inventario");
        Console.WriteLine("¿Que opcion deseas hacer?");
        Console.WriteLine("1- Mostrar");
        Console.WriteLine("2- Buscar");
        Console.WriteLine("3- Ordear");
        Console.WriteLine("4- Invertir");
        Console.WriteLine("5- Vaciar");
        Console.WriteLine("6- Agregar suministro");
        Console.WriteLine("7- Eliminar suministro");
        Console.WriteLine("8- salir");
        int opcion = int.Parse(Console.ReadLine() ?? "");

        switch (opcion)
        {
            case 1:

                inventario.MostrarSuministros();
                break;


            case 2:
                Console.WriteLine("Ingresa el nombre del suministro a buscar:");
                string nombre = Console.ReadLine() ?? "";
                inventario.BuscarSuministro(nombre);
                break;
            case 3:
                inventario.OrdenarPorNombre();
                break;
            case 4:
                inventario.InvertirOrden();
                break;
            case 5:
                inventario.VaciarInventario();
                break;
            case 6:
                Console.WriteLine("Ingresa el nombre del suministro a buscar:");
                string nombreSum = Console.ReadLine() ?? "";

                Console.WriteLine("Cantidad o Vacio");
                string cantidad = Console.ReadLine() ?? "";

                if (cantidad != "")
                {
                    Console.WriteLine("Prioridad o Vacio");
                    string prioridad = Console.ReadLine() ?? "";

                    inventario.AgregarSuministro(nombreSum, int.Parse(cantidad), int.Parse(prioridad));
                }
                else
                {
                    inventario.AgregarSuministro(nombreSum);
                }
                break;
            case 7:
                Console.WriteLine("Ingresa el nombre del suministro a eliminar:");
                string nombreEl = Console.ReadLine() ?? "";
                inventario.EliminarSuministro(nombreEl);
                break;
            case 8:
                salir = true;
                break;
            default:
                Console.WriteLine("No valido");
                break;
        }

    }
    catch (NullReferenceException)
    {
        Console.WriteLine("Ocurrio un error: Se intento buscar pero no hay nada");

    }
    catch (FormatException ex)
    {
        Console.WriteLine(ex.Message);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

public class Suministro
{
    //Atributos
      public string Nombre {  get; set; }
      public int Cantidad { get; set; }
      public int Prioridad { get; set; }

    //Contructor 
    public Suministro(string nombre, int cantidad, int prioridad)
    {
        Nombre = nombre;
        Cantidad = cantidad;
        Prioridad = prioridad;
    }
    // Constructor sobrecargado
    // Si solo se da el nombre, se asignan valores por defecto
    public Suministro(string nombre)
    {
        Nombre = nombre;
        Cantidad = 1;
        Prioridad = 2;

    }

    //Metodos
    public void MostrarInfo()
    {
        Console.WriteLine($"Nombre: {Nombre} Cantidad {Cantidad}, Prioridad {Prioridad}");
    }


}
public class Inventario
{
    // Arreglo de objetos Suministro
    // Un arreglo es una estructura de datos de tamaño fijo
    // que almacena varios elementos del mismo tipo
    //Atributos
    private Suministro[] suministros;
    //
    public Inventario()
    {
        suministros = new Suministro[] //Se agregan siempre estos suministros
        {
            new Suministro("Oxigeno",15,1),
            new Suministro("Gasolina"),
            new Suministro("Comida",30,1),
            new Suministro("Almohada",15,3),
            new Suministro("Botiquin",4,1),

        };
    }
    //Metodos
    public void MostrarSuministros()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Inventario de suministros");
        Console.ForegroundColor = ConsoleColor.Blue;

        bool hayDatos = false;
        //De tu clase Suministro declara una variable suministro que cuenta en suministros
        foreach (Suministro suministro in suministros)
        {
            if (suministro != null)
            {
                hayDatos = true;
                Console.WriteLine($"{suministro.Nombre}");
                suministro.MostrarInfo();
            }
        }

        if (!hayDatos) //el if pregunta si es verdadero o falso, aqui solo ando diciendo que es verdadero 
        {
            Console.WriteLine("El inventario esta vacio");
        }
    }

    public void BuscarSuministro(string nombre)
    {
        int indice = Array.FindIndex(suministros, s => s.Nombre.ToLower() == nombre.ToLower()); //Se usa para buscar algo especifico
        //array.Index(arreglo--->suministros,s va a s.Nombre(accede al nombre  del objeto) .ToLower(convierte todo el minusculas) == a el nombre en minusculas)
        //Con esto evitamos equivocaciones por tipo de texto
        if(indice >= 0)
        {
            Console.WriteLine($"{nombre} se encontro en posicion {indice}");
        }
        else
        {
            Console.WriteLine($"{nombre} no se econtro");
        }
    }
    public void OrdenarPorNombre()
    {
        Array.Sort(suministros, (x, y) => x.Nombre.CompareTo(y.Nombre)) ; //Array.Sort funciona para arreglar arreglos
        //Estructura del array
        //A.Sort(Arreglo a ordenar,(1° objeto, 2° objeto) va hacia x(accede al nombre) y compara con el nombre de y)
        Console.WriteLine("Suministros ordenados por nombre");
    }
    public void InvertirOrden()
    {
        Array.Reverse(suministros);
        Console.WriteLine("Orden invertido");
    }
    public void VaciarInventario()
    {
        Array.Clear(suministros, 0, suministros.Length);
        //Estructura del array.clear
        // A.clear(arreglo, posicion inicial, hasta donde llego)
        Console.WriteLine($"Inventario borrado:{ suministros.Length }");
    }
    //Agregar suministro
    public void AgregarSuministro(string nombre, int cantidad, int prioridad)
    {
        int indiceNull = Array.FindIndex(suministros, s => s == null);
        if (indiceNull >= 0)
        {
            suministros[indiceNull] = new Suministro ( nombre, cantidad, prioridad );//aqui el [] se refiere al num de indice

        }
        else
        {
            Array.Resize(ref suministros, suministros.Length + 1); //Agranda el arreglo
            //A.Resize(usa como referencia suministros, de ese arreglo agregale un tamaño más)
            suministros[suministros.Length - 1] = new Suministro(nombre, cantidad, prioridad);//Tu arreglo va tener un espacio más pero para el indice es n-1
        }
        Console.WriteLine($"{nombre} agregado al inventario");
    }
    public void AgregarSuministro(string nombre)
    {
        AgregarSuministro(nombre, 1, 2);//Agregar si solo se da el nombre 
    }
    public void EliminarSuministro(string nombre)
    {
        int indice = Array.FindIndex(suministros, s => s.Nombre.ToLower() == nombre.ToLower());
        if (indice >= 0)
        {
            for (int i = indice; i < suministros.Length-1; i++)
            {
                suministros[i] = suministros[i + 1];//Mueve los elementos a la izquierda
            }
            Array.Resize(ref suministros, suministros.Length - 1);//cuando acaba de acomodar solo eliminar el ultimo elemento 
            Console.WriteLine($"{nombre} eliminado del inventario");

        }
        else
        {
            Console.WriteLine($"{nombre} no encontrado");
        }
    }

}

