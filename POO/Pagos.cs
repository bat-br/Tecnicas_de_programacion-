//Programa principal
bool continuar = true;
List <IPago> listaPagos = new List <IPago> ();
do
{
    Console.WriteLine("Ingresa el monto a pagar");
   
        string montoTexto = Console.ReadLine() ?? "";
        if(double.TryParse(montoTexto,out double monto))
        {
            string modoPagoT;
            int modoPago;
            do
            {
                Console.WriteLine("1- Pago con tarjeta");
                Console.WriteLine("2- Pago en efectivo");

                modoPagoT = Console.ReadLine() ?? "";

            } while (!int.TryParse(modoPagoT, out modoPago) || (modoPago !=2 && modoPago !=1));

            if (modoPago == 1)
            {
                Console.WriteLine("Ingresa el umero de tarjeta: ");
                string tarjeta = Console.ReadLine() ?? "";

                //creando objeto para pago con tarjeta

                IPago pago = new PagoTarjeta(tarjeta,monto);
                listaPagos.Add (pago);
            }
            else 
            {
                //creando objeto para pago con efectivo

                IPago pago = new PagoEfectivo( monto);
                listaPagos.Add(pago);
            }

        }
       else
        {
            Console.WriteLine("Moto invalido");
            return;
        }
        
    

    Console.WriteLine("Presiona S para procesar más pagos: ");
    char continuaT = char.Parse(Console.ReadLine() ?? "".ToLower());
    if(continuaT == 's')
    {
        continuar = true;
    }
    else
    {
        continuar = false; 
    }
}
while (continuar);

foreach (IPago pago in listaPagos) //Tipo de dato, variable temporal en lista declarada
{
    pago.ProcesarPago();
}

//Interfaz y clases

public interface IPago
{
    void ProcesarPago();
}

//Clase de pago en efectivo

public class PagoEfectivo : IPago
{
    //Atributo
    public double Monto { get; set; }

    //Constructor
    public PagoEfectivo(double monto)
    {
        Monto = monto;
    }

    //Metodos
    public void ProcesarPago()
    {
        Console.WriteLine($"Pago en efectivo de {Monto} proccesado");
    }
}

public class PagoTarjeta : IPago
{
    //Atributo
    public double Monto { get; set; }
    public string NumTarjeta {  get; set; }


    //Constructor
    public PagoTarjeta(string numTarjeta,double monto)
    {
        Monto = monto;
        NumTarjeta = numTarjeta;    
    }


    //Metodos
    public void ProcesarPago()
    {
        if (NumTarjeta.Length == 16)
        {
            Console.WriteLine($"Pago en tarjeta de {Monto} proccesado");
        }
        else
        {
            Console.WriteLine($"Tarjeta invalida");
        }
    }
}


