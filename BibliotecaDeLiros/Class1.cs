namespace BibliotecaDeLibros //Ahora si lo vamos a usar, es solo para organizar
{
    public class Libro
    {
        //Atributos
        public string Titulo { get; set; }
        public string Autor {  get; set; }
        public int AnioPublicacion { get; set; }
        //Constructor
        public Libro(string titulo, string autor, int aniodepublicacion) 
        {
            Titulo = titulo;
            Autor = autor;
            AnioPublicacion = aniodepublicacion;
        }
        //Metodos

    }
    public class GestorLibros
    {
        private List <Libro> libros = new List <Libro> ();
        //Metodos

        public void AgregarLibro(Libro libro)
        {
            libros.Add (libro);
        }

        public void EliminarLibro(string titulo)
        {   
            libros.RemoveAll(l=> l.Titulo == titulo);
        }

        public List<Libro> BuscarLibrosPorAutor(string autor)
        {
            return libros.FindAll(a => a.Autor == autor); 
            
        }
        public void MostrarLibros()
        {
            foreach (Libro libro in libros)
            {
                Console.WriteLine($"Titulo:{libro.Titulo}|Autor:{libro.Autor}| Año:{libro.AnioPublicacion}");
            }
        }
    }
}
