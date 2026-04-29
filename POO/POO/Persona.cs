public class Persona
{
	//Atributos, cada objeto va tener su propio nombre y edad
	public string Nombre { get; set; }//nivel acceso,tipo y variable lo siguiente es un encapsulamiento

	public int Edad { get; set; }

	//Atributo static, no varian y se queda fijo

	public static string Pais { get; set; } = "España";

	//Variable de clase
	int i = 0;


	//Constructor
	public Persona(string nombre, int edad, string pais)
	{
		Nombre = nombre;
		Edad = edad;
		Pais = pais;
	}
	//Metodos
	public void MostrarDatos() //Libre para cualquier parte del codigo 
	{
        Console.WriteLine($"Nombre del objeto: {Nombre}");
        Console.WriteLine($"Edad del objeto: {Edad}");
		
    }

	public static void MostrarPais()
	{
        Console.WriteLine($"Nacionalidad del objeto: {Pais}");
    }
}
