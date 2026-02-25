//Prgrama de forma secuencial

Console.WriteLine("Ingresa tu nombre: ");
string nombre = Console.ReadLine() ?? "";//?? significa y si no escribe esto

Console.WriteLine("Ingresa la edad");
int edad = int.Parse(Console.ReadLine() ?? "");//El usuario siempre va ingresar una cadena

/*Console.WriteLine($"Nombre: {nombre}");
Console.WriteLine($"Edad: {edad}");*/

//Programa orientado a objetos

Persona humano1 = new Persona(nombre,edad,"España");//Instancia un nuevo objeto de tipo persona

/*Console.WriteLine($"Nombre: {humano1.Nombre}");
Console.WriteLine($"Edad: {humano1.Edad}");*/

humano1.MostrarDatos();
Persona.MostrarPais();//Lo estatico depende de la clase y no del objeto

Persona humano2 = new Persona("Angel", 22,"Costa rica");
humano2.MostrarDatos();
Persona.MostrarPais();

