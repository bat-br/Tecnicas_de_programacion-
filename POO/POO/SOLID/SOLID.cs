
public class Mascota
{
    public string Nombre { get; set; }
    public string Tipo { get; set; }
    public int Edad { get; set; }

    public Mascota(string nombre, string tipo, int edad)
    {
        Nombre = nombre;
        Tipo = tipo;
        Edad = edad;
    }
}
//Primer clase responsable
public class EsValido
{
    public bool Validar(Mascota mascota)
    {
        return !string.IsNullOrEmpty(mascota.Nombre) && mascota.Edad > 0;
    }
}
public interface ICalcularVacuna
{
    bool AplicaPara(string tipoMascota);
    decimal Calcular(Mascota mascota);
}
public class TarifaPerro : ICalcularVacuna
{
    public bool AplicaPara(string tipoMascota) => tipoMascota.StartsWith("P");
    public decimal Calcular(Mascota mascota) => 200;
}
public class EmailServie
{
    public void Enviar(string mensaje)
    {
        Console.WriteLine($"Enviando correo: {mensaje}");
    }
}
