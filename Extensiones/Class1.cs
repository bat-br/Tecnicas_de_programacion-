using BibliotecaDeLibros;
namespace Extensiones
{
    public static class LibroExtensiones
    {
        public static bool EsLibroAntiguo(this Libro libro )
        {
            return ((DateTime.Now.Year - libro.AnioPublicacion) > 50);
        }
        public static string FormatoInfo(this Libro libro)
        {
            return $"{libro.Autor}( {libro.Titulo}- {libro.AnioPublicacion})";
        }
    }
}
