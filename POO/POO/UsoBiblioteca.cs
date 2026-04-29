using Extensiones;
using BibliotecaDeLibros;
using ValidacionesBiblioteca;

GestorLibros gestor = new GestorLibros();
//Agrega Libro
gestor.AgregarLibro(new Libro("El señor de los anillos", "Tolkien", 1954));
gestor.AgregarLibro(new Libro("Dune", "Frank", 1965));
gestor.AgregarLibro(new Libro("Juego de Tronos", "George", 1996));


//Mostrar libros

Console.WriteLine("Libros en la biblioteca");
gestor.MostrarLibros();

// usar metodo de Extension
Libro libro = gestor.BuscarLibrosPorAutor("Tolkien")[0];
Console.WriteLine(libro.FormatoInfo());
Console.WriteLine($"Es libro antiguo{libro.EsLibroAntiguo()}");

//Usar validaciones

Console.WriteLine("Es año valido 2026" + Validaciones.EsAnioValido(2027));
