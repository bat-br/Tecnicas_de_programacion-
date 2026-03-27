namespace ValidacionesBiblioteca
{
    public static class Validaciones 
    {
        public static bool EsAnioValido(int anio)
        {
            return anio > 0 && anio <= DateTime.Now.Year;
        }
        public static bool EsTituloValido(string titulo)
        {
            return !string.IsNullOrEmpty(titulo);
        }
    }
    public class ValidacionAnio : Exception
    {
        public ValidacionAnio(string mensaje) : base(mensaje) { }
        
    }
    public class ValidacionTitulo : Exception
    {
        public ValidacionTitulo(string mensaje) : base(mensaje) { }

    }
}
