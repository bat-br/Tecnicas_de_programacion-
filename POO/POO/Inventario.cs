//Principal
//La lista es dinamica y el arreglo debo decirle cuantos espacios hay
Inventario inventario = new Inventario();
bool salir = false;
/*try
{
    while (!salir)
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
}*/

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
    //Sobrecarga del constructor
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
        foreach (Suministro suministro in suministros)
        {
            if (suministro != null)
            {

                Console.WriteLine($"{suministro.Nombre}");
                suministro.MostrarInfo();
            }
            else
            {
                Console.WriteLine("No existen datos");
            }
        }
    }
    public void BuscarSuministro(string nombre)
    {
        int indice = Array.FindIndex(suministros, s => s.Nombre.ToLower() == nombre.ToLower()); //Se usa para buscar algo especifico
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
        Array.Sort(suministros, (x, y) => x.Nombre.CompareTo(y.Nombre)) ; //Compara 
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
        Console.WriteLine($"Inventario borrado:{ suministros.Length }");
    }
    //Agregar suministro
    public void AgregarSuministro(string nombre, int cantidad, int prioridad)
    {
        int indiceNull = Array.FindIndex(suministros, s => s == null);
        if (indiceNull >= 0)
        {
            suministros[indiceNull] = new Suministro ( nombre, cantidad, prioridad );

        }
        else
        {
            Array.Resize(ref suministros, suministros.Length + 1);
            suministros[suministros.Length - 1] = new Suministro(nombre, cantidad, prioridad);//El ultimo indice va ser ael 100 a pesar de tener 101
    }
        Console.WriteLine($"{nombre} agregado al inventario");
    }
    public void AgregarSuministro(string nombre)
    {
        AgregarSuministro(nombre, 1, 2);
    }
    public void EliminarSuministro(string nombre)
    {
        int indice = Array.FindIndex(suministros, s => s.Nombre.ToLower() == nombre.ToLower());
        if (indice >= 0)
        {
            for (int i = indice; i < suministros.Length-1; i++)
            {
                suministros[i] = suministros[i + 1];
            }
            Array.Resize(ref suministros, suministros.Length - 1);
            Console.WriteLine($"{nombre} eliminado del inventario");

        }
        else
        {
            Console.WriteLine($"{nombre} no encontrado");
        }
    }

}

