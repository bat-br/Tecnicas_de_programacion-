//Manejo de archivos

using System.IO;

//Escritura

//Ruta relativa
string ruta = "./archivo.txt";
//Ruta Absoluta
string ruta2 = @"C:\Users\Alumnos\Documents\López Ortíz Bruno\archivo2.txt";

using(StreamWriter writer = new StreamWriter(ruta))//Sobreescribe cada vez que se ejecuta
{
    writer.WriteLine("Hola, este es un archivo de texto");
    writer.WriteLine("Esta es una segunda linea");
}
using (StreamWriter writer = new StreamWriter(ruta2))
{
    writer.WriteLine("Hola, este es el segundo archivo de texto");
    writer.WriteLine("Esta es una segunda linea");
}

//Lectura

using (StreamReader reader = new StreamReader(ruta))
{
    string contenido = reader.ReadToEnd();
    Console.WriteLine(contenido);
}

//Archivo binario escritura
string rutaB= @"C:\Users\Alumnos\Documents\López Ortíz Bruno\datosBinarios.bin";

using (BinaryWriter writer = new BinaryWriter(File.Open(rutaB,FileMode.Create)))//Binary para que no lo decofique 
{
    writer.Write(25);
    writer.Write(3.1415);
    writer.Write("Texto binario");
}
Console.WriteLine("Archivo binario escrito");

using (BinaryReader reader = new BinaryReader(File.Open(rutaB, FileMode.Open)))//Binary para que no lo decofique 
{
    int numero =reader.ReadInt32();
    double numeroDecimal = reader.ReadDouble();
    string textp2 =reader.ReadString();
    Console.WriteLine(numero);
    Console.WriteLine(numeroDecimal);
    Console.WriteLine(textp2);
}

//Acceso secuancial
string rutaSecuancial = @"C:\Users\Alumnos\Documents\López Ortíz Bruno\secuancial.txt";
using (StreamWriter writer = new StreamWriter(rutaSecuancial))
{
    for (int i = 1; i <= 200; i++)
    {
        writer.WriteLine($"Linea {i}");
    }

}
using (StreamReader reader = new StreamReader(rutaSecuancial))
{
    string lineaLectura;
    while((lineaLectura = reader.ReadLine()) != null) 
    {
        if (lineaLectura == "Linea 150")
        {
            Console.WriteLine(lineaLectura);
        }

        //Console.WriteLine(lineaLectura);
    }

}
//Acesso aleatorio
string rutaAleatoria = @"C:\Users\Alumnos\Documents\López Ortíz Bruno\aleatorio.txt";
using (FileStream fs = new FileStream(rutaAleatoria,FileMode.Create,FileAccess.ReadWrite))
{
    using (StreamWriter writer = new StreamWriter(fs))
    {
        writer.WriteLine("Linea 1: Hola mundo");
        writer.WriteLine("Linea 2: Python es mejor");
        writer.WriteLine("Linea 3: Adios mundo");


    }

}

using (FileStream fs = new FileStream(rutaAleatoria, FileMode.Open, FileAccess.ReadWrite))
{
    fs.Seek(23, SeekOrigin.Begin);
    using (StreamReader reader = new StreamReader(fs))
    {
        string lineaLectura = reader.ReadLine();
        Console.WriteLine("Lectura aleatoria en punto 13:"+lineaLectura);
       
    }
}