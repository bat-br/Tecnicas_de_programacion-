//Programa principal banco


Banco banco = new Banco();
char repetir = 'y';
do
{
    try
    {
        CuentaBancaria cuentaOrigen = banco.BuscarCuenta("123456");


        Console.WriteLine("Que operacion deseas hacer?:");
        Console.WriteLine("1-Depositar");
        Console.WriteLine("2-Retirar");
        Console.WriteLine("3-Transferir");
        Console.WriteLine("4-Salir");
        int sel = int.Parse(Console.ReadLine() ?? "");
        switch (sel)
        {
            case 1:
                Console.WriteLine($"Saldo inicial:{cuentaOrigen.Saldo}");
                Console.WriteLine("Dime la cantidad que quieres depositar");
                decimal deposito = decimal.Parse(Console.ReadLine() ?? "");
                Console.WriteLine("Haciendo el deposito");
                cuentaOrigen.Depositar(deposito);
                Console.WriteLine($"Saldo final:{cuentaOrigen.Saldo}");
                break;

            case 2:
                Console.WriteLine($"Saldo inicial:{cuentaOrigen.Saldo}");
                Console.WriteLine("Dime la cantidad que quieres retirar");
                decimal retirar = decimal.Parse(Console.ReadLine() ?? "");
                cuentaOrigen.Depositar(retirar);
                Console.WriteLine("Haciedo el retiro");
                Console.WriteLine($"Saldo final:{cuentaOrigen.Saldo}");
                break;

            case 3:
                Console.WriteLine($"Saldo inicial:{cuentaOrigen.Saldo}");
                Console.WriteLine("Escribe la cuenta destino para transferir");
                CuentaBancaria cuentaDestino = banco.BuscarCuenta(Console.ReadLine() ?? "");
                Console.WriteLine("Escribe la cuenta destino para transferir");
                decimal cantidad = decimal.Parse(Console.ReadLine() ?? "");
                Console.WriteLine("Haciendo transferencia:");
                cuentaOrigen.Transferir(cuentaDestino, cantidad);
                Console.WriteLine($"Saldo final: {cuentaOrigen.Saldo}");
                break;
            case 4:
                break;
            default:
                Console.WriteLine("Operacion Invalida");
                break;



        }
        Console.WriteLine("Escribe Y para realizar más operaciones:");
        repetir = char.Parse(Console.ReadLine() ?? "");
        //Transferecia
        /* Console.WriteLine("Haciendo transferencia:");
         Console.WriteLine($"Saldo inicial:{cuentaOrigen.Saldo}");
         cuentaOrigen.Transferir(cuentaDestino, 10);
         Console.WriteLine($"Saldo final: {cuentaOrigen.Saldo}");*/

    }
    catch (CuentaNoEncontradaException ex)
    {
        Console.WriteLine(ex.Message);
    }
    catch (SaldoInsuficienteException ex)
    {
        Console.WriteLine(ex.Message);
    }
    catch (DepositoInvalidoException ex)
    {
        Console.WriteLine(ex.Message);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }

}
while (repetir == 'Y');



class SaldoInsuficienteException : Exception
{
    public SaldoInsuficienteException(String mensaje) : base(mensaje) 
    {

    }
}

class CuentaNoEncontradaException : Exception
{
    //Constructor
    public CuentaNoEncontradaException(String mensaje) : base(mensaje)
    {

    }
}

class DepositoInvalidoException : Exception
{
    //Constructor
    public DepositoInvalidoException(string mensaje): base(mensaje)
    {

    }
}
//Clases del banco
public class CuentaBancaria
{
    //Atributos
    public string NumeroCuenta { get; }
    public decimal Saldo { get; set; }

    //Constructor
    public CuentaBancaria(string numeroCuenta, decimal saldo)
        {
        NumeroCuenta = numeroCuenta;
        Saldo = saldo;
        }

    //Metodos
    public void Depositar(decimal cantidad)
    {
        if (cantidad <0)
        {
            throw new DepositoInvalidoException("No puedes depositar " + "cantidades negativas");
        }
        Saldo += cantidad;
    }
    public void Retirar (decimal cantidad)
    {
        if (cantidad > Saldo)
        {
            throw new SaldoInsuficienteException("Saldo insuficiente para " + "la operacion");

        }
        Saldo -= cantidad;
    }
    public void Transferir(CuentaBancaria destino, decimal cantidad)
    {
        if (destino == null)
        {
            throw new CuentaNoEncontradaException("Cuenta no encontrada ");

        }

        Retirar(cantidad);
        destino.Depositar(cantidad);
    }
}

public class Banco
{
    //Atributos
    private CuentaBancaria[] cuentas;//Arreglo de objetos y luego menciona el nombre

    //Constructor


    public Banco()
    {
        cuentas = new CuentaBancaria[]
        {
            new CuentaBancaria("123456",6),
            new CuentaBancaria("789456", 20),
            new CuentaBancaria("741852",10000),
        };

    }

    //Metodos
    public CuentaBancaria BuscarCuenta(string numeroCuenta)
    {
        foreach(CuentaBancaria cuenta in cuentas)//Si tu arreglo es de decimales dime que es decimal
        {
            if (cuenta.NumeroCuenta == numeroCuenta)
            {
                return cuenta;
            }
        }
        throw new CuentaNoEncontradaException("Cuenta no encontrada");

    }

}
