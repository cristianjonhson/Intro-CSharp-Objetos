using Creacion_Objetos;
using System;

namespace Creacion_Objetos
{
   //interfaz da reglas. 
  interface ISale
    {
        decimal Total { get; set; }
    }

    interface ISave
    {
        void Save();
    }
}

    //Las interface pueden ser multiples
    public class Sale : ISale, ISave
    {
        public decimal Total { get; set; }

        public void Save() {
        Console.WriteLine("Se guardo en BD");
    }

    }
   

    internal class Program
    {
        static void Main(string[] args)
        {
        Sale sale = new Sale();
        sale.Save();

        // Puedes acceder a las propiedades y métodos de Sale
        Console.WriteLine("Funciono!");

            // Llama a GetInfoWithTax y muestra el resultado en la consola
            Console.WriteLine();

            // Esperar la entrada del usuario antes de cerrar la aplicación
            Console.WriteLine("Presiona Enter para salir...");
            Console.ReadLine();
        }
    }