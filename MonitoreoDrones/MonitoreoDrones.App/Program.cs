using MonitoreoDrones.Dominio.Entidades;
using MonitoreoDrones.Extensiones;
using MonitoreoDrones.Utilidades;

//Crear dron

var dron = new Dron(id: 01, modelo: "Dron2dji", nivelbateria: 80, posicion: new Posicion(19.4326 ,-99.1332));

//Crear mision
var mision = new Mision (1,"Rescate",30,completado:false);

//Validacion de dron
if (dron.PuedeIniciarMision())
{
    dron.AsignarMision(mision);
}
//Calcular la distancia
double distanca = UtilidadesGeograficas.CalcularDistancia(dron.Posicion.Latitud, dron.Posicion.Longitud, 19.4270, -99.1276);
//Estimar  su consumo
double consumo = UtilidadesCalculoDron.EstimarConsumoBateria(distanca);
//Mostrar resultados
dron.ActualizarBateria(dron.NivelBateria - consumo);
Console.WriteLine(dron.ObtenerResumenEstado());
Console.WriteLine($"Distancia:{distanca:F2}Km");
Console.WriteLine($"Consumo estimado {consumo:F2}%");
