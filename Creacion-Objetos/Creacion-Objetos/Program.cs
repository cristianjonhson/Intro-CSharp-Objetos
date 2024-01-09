using System;
using System.Net.Http.Headers;

namespace Creacion_Objetos
{
    class SaleWithTax : Sale
    {

        public decimal Tax { get; set; } = 15;
        public SaleWithTax(decimal total, string saleName): base( total, saleName   ) { }

        public override string GetInfo()
        {
            return "El total es " + Total + " Impuesto es: " + Tax;
        }

        //Sobrecarga de metodo
        public string GetInfo(string message)
        {
            return message;
        }

    }

    class Sale
    {
        public decimal Total { get; set; }
        public decimal Balance { get; set; }
        public string SaleId { get; set; }
        public string SaleName { get; set; }

        // Constructor
        public Sale(decimal total, string saleName)
        {
            Total = total;
            SaleName = saleName;
        }

        //el virtual sirve para que el metodo padre se pueda sobreescribir
        public virtual string GetInfo()
        {
            return SaleName;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            SaleWithTax sale = new SaleWithTax(5000, "Iphone x");
            sale.GetInfo();

            // Puedes acceder a las propiedades y métodos de Sale
            Console.WriteLine($"Total: {sale.Total}");

            // Llama a GetInfoWithTax y muestra el resultado en la consola
            Console.WriteLine(sale.GetInfo());

            // Esperar la entrada del usuario antes de cerrar la aplicación
            Console.WriteLine("Presiona Enter para salir...");
            Console.ReadLine();
        }
    }
}
