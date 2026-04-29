//Casteos son conversiones

//conversion implicita


int numeroEntero = 42;
double numDouble = numeroEntero;

Console.WriteLine(numDouble);


//Conversion explicita

double numDouble2 = 42.75;
int numEnt2 = (int)numDouble2;
Console.WriteLine(numEnt2);

//Con metodos

string texto = "123";
int numerot = Convert.ToInt32(texto);//Conviertelo en un entero de 32 bits
Console.WriteLine(numerot);

//Parse

string texto2 = "3.14";
double numeroD= double.Parse(texto2); //Se tarda más el parse va ser más eficiente aquí
Console.WriteLine(numeroD);



//Try parse

string texto3 = "3.14";
bool exito = int.TryParse(texto3,out int resultado);//el resultado va ser un verdadero o falso
Console.WriteLine(exito);
Console.WriteLine(resultado);


// casteos entre objetos y clases

//Upper casting hijo -Padre
Animal mi = new Perro();

//Down casting Padre- hijo
/*Animal animal = new Animal(); 
Perro perro = (Perro)new Animal();
perro.Ladrar();*/
 
object obj = "Hoa";
Console.WriteLine(obj);