//Programa principal

/*
Calculadora calculadora2 = new Calculadora(6, 8);
Console.WriteLine($"El primer numero es: {calculadora.Num1}");
Console.WriteLine($"El segundo numero es: {calculadora.Num2}");
int resultado1 = calculadora.Suma();
int resultado2 = calculadora.Resta();
int resultado3 = calculadora.Multiplicacion();
float resultado4 = calculadora.Division();
Console.WriteLine($"La suma de los numeros es: {resultado1}");
Console.WriteLine($"La resta de los numeros es:{resultado2}");
Console.WriteLine($"La multiplicacion de los numeros es:{resultado3}");
Console.WriteLine($"La division de los numeros es:{resultado4}");


Console.WriteLine($"El resultado de la calculadora basica: {calculadora.Suma(3)}");
Calculadora calculadora3 =calculadora + calculadora2;
Console.WriteLine($"Calculaora3 ({calculadora3.Num1},{calculadora3.Num2})");
calculadoraCienifica.MensajeC();*/
//sobrecarga de operador + va aplicar para cualquier objeto tipo objeto

Console.WriteLine("Ingresa el primer numero a operar:");
int nume1 = int.Parse(Console.ReadLine() ?? "");
Console.WriteLine("Ingresa el segundo numero a operar:");
int nume2 = int.Parse(Console.ReadLine() ?? "");

Console.WriteLine("Presiona 1 - Calculadora basica");
Console.WriteLine("Presiona 2 - Calculadora cientifica");
int sel = int.Parse(Console.ReadLine() ?? "");
if (sel == 1)
{
    Calculadora calculadora = new Calculadora(1, 3);
    Console.WriteLine("1- Suma");
    Console.WriteLine("2- Resta");
    Console.WriteLine("3- Multiplicacion");
    Console.WriteLine("1- Divison");
    int sell = int.Parse(Console.ReadLine() ?? ""); 
    switch (sell)
    {
        case 1:
            
                Console.WriteLine($"El resultado de la calculadora basica: {calculadora.Suma()}");
                break;
            
        case 2:
            
                Console.WriteLine($"El resultado de la calculadora basica: {calculadora.Resta()}");
                break;
        case 3:
            Console.WriteLine($"El resultado de la calculadora basica: {calculadora.Multiplicacion()}");
            break;
        case 4:
            Console.WriteLine($"El resultado de la calculadora basica: {calculadora.Division()}");
            break;

        default:
            Console.WriteLine("Seleccion incorrecta");
            break;

    }
}
else if (sel == 2)
{
    CalculadoraCienifica calculadoraCienifica = new CalculadoraCienifica(5, 2);
    Console.WriteLine("1- Suma");
    Console.WriteLine("2- Resta");
    Console.WriteLine("3- Multiplicacion");
    Console.WriteLine("4- Divison");
    Console.WriteLine("5- Logaritmo");
    Console.WriteLine("6- Raiz cuadrada");
    Console.WriteLine("7- Factorial");
    int sell = int.Parse(Console.ReadLine() ?? "");
    switch (sell)
    {
        case 1:

            Console.WriteLine($"El resultado de la calculadora cientifica: {calculadoraCienifica.Suma()}");
            break;

        case 2:

            Console.WriteLine($"El resultado de la calculadora cientifica: {calculadoraCienifica.Resta()}");
            break;

        case 3:
            Console.WriteLine($"El resultado de la calculadora cientifica: {calculadoraCienifica.Multiplicacion()}");
            break;

        case 4:
            Console.WriteLine($"El resultado de la calculadora cientifica: {calculadoraCienifica.Division()}");
            break;

        case 5:
            Console.WriteLine($"El resultado de la calculadora cientifica: {calculadoraCienifica.Logitmo()}");
            break;

        case 6:
            Console.WriteLine($"El resultado de la calculadora cientifica: {calculadoraCienifica.RaizCuadrada()}");
            break;

        case 7:
            Console.WriteLine($"El resultado de la calculadora cientifica: {calculadoraCienifica.factorial()}");
            break;

        default:
            Console.WriteLine("Seleccion incorrecta");
            break;

    }

}



//Clases


//Calculadora basica que solo opera 2 numeros enteros


public class Calculadora 
{
    //Atributos
    public int Num1 { get; set; }
    public int Num2 { get; set; }

    //Atributo privado

    private int Resultado;
    private string mensaje="Mensaje privado";

    //Constructor
    public Calculadora(int num1, int num2)
    {
        Num1 = num1;
        Num2 = num2;

    }

    //Metodos


    public virtual int Suma()
    {
        Resultado= Num1 + Num2;
        return Resultado;
    }
    //Metodo privado

    private void MostrarMensaje() //Solo para esta clase
    {
        Console.WriteLine(mensaje);
    }

    //Metodo protegido

    protected void Mensaje()
    {
        MostrarMensaje();
    }
    //Sobrecarga del metodo suma
    public virtual int Suma(int num3)
    {
        return Num1 + Num2 + num3;
    }

    public int Resta()
    {
        return Num1 - Num2;
    }
    public int Multiplicacion()
    {
        return Num1 * Num2;
            
    }
    public float Division ()
    {
        if (Num2 == 0)
        {
            Console.WriteLine("MathError");
            return 0;
        }
        else
        {
            
            return (float) Num1 / Num2;
        }
    }
    //Sobrecarga de operador
    public static Calculadora operator +(Calculadora cal1, Calculadora cal2)
    {
        return new Calculadora(cal1.Num1 + cal2.Num1, cal1.Num2 + cal2.Num2);
    }
}


//Clase hija

public class CalculadoraCienifica:Calculadora
{
    //Atributos
    
    //Constructor
    public CalculadoraCienifica(int numero1, int numero2) : base(numero1,numero2)
    {

    }
    //Metodos
    public double Logitmo()
    {
        return MathF.Log(Num1);
    }
    public double RaizCuadrada()
    {
        return MathF.Sqrt(Num1);
    }

    //Override cambia el metodo heredado

    public override int Suma()
    {
        int resultado = base.Suma();
        
        return resultado * resultado;
    }
    public void MensajeC()
    {
        base.Mensaje();
    }
    public int factorial()
    {
        if (Num1 == 0 || Num1 == 1)
        {
            return 1;
        }
        else if (Num1 < 0)

        {
            Console.WriteLine("No es posible factriales de numeros negativos");
            return 0;
        }
        else
        {
            int fct = 1;
            for (int i = 2; i <= Num1; i++)
            {
                fct = fct * i;
            }
            return fct;
        }

    }
}