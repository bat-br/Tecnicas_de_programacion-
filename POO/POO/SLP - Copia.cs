//SIN SRP
public class Libro
{
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public int Paginas { get; set; }

    //Metodos

    public void Guardar_BD()
    {
        Console.WriteLine($"Guardando {Titulo} en BD");
    }

    public void GenerarReporte()
    {
        Console.WriteLine($"Reporte para {Titulo}");
    }


}




//Aplicando SRP
//Primera responsabilidad instanciar objeto con encapsulamiento de datos
public class LibroSRP
{
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public int Paginas { get; set; }
}

//Segunda responsabilidad
public class RepositorioLibro
{
    public void GuardarBD(LibroSRP librosrp)
    {
        Console.WriteLine($"Guardando {librosrp.Titulo} en BD");
    }
}

//Tercera responsabilidad generar reportes

public class GeneradorReporte
{
    public void GenerarReporte(LibroSRP librosrp)
    {
        Console.WriteLine($"Reporte para {librosrp.Titulo}");
    }
}
//Principio abierto / cerrado

//Sin ocp

public class CalculadoraPrestamo
{
    public decimal Calcular(Libro libro, string tipoPrestamo)
    {
        if (tipoPrestamo == "Regular")
        {
            return 10.0m;
        }
        if (tipoPrestamo == "Premium")
        {
            return 5.0m;
        }
        throw new ArgumentException("Tipo de prestamos no valido");


    }
}

//Aplicando OCP 

public interface IPrestamo
{
    decimal CalcularTarifa(LibroSRP librosrp);
}

public class PrestamoRegular : IPrestamo
{
    public decimal CalcularTarifa(LibroSRP librosrp)
    {
        return 10.0m;
    }
}

public class PrestamoPremium : IPrestamo
{
    public decimal CalcularTarifa(LibroSRP librosrp)
    {
        return 5.0m;
    }
}

public class CalculadoraPrestamoOCP
{
    public decimal Calcular(LibroSRP libro, IPrestamo tipoPrestamo)
    {
        return tipoPrestamo.CalcularTarifa(libro);
    }
}
