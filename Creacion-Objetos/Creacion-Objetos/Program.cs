using System;

namespace Creacion_Objetos
{
    class SaleWithTax : Sale
    {

        public decimal Tax { get; set; } = 15;
        public SaleWithTax(decimal total, string saleName): base( total, saleName   ) { }

        public string GetInfoWithTax()
        {
            return "El total es " + Total + " Impuesto es: " + Tax;
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

        public string GetInfo()
        {
            return SaleName;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            SaleWithTax sale = new SaleWithTax(5000, "Iphone x");
            sale.GetInfoWithTax();

            // Puedes acceder a las propiedades y métodos de Sale
            Console.WriteLine($"Total: {sale.Total}, SaleName: {sale.GetInfo()}");

            // Llama a GetInfoWithTax y muestra el resultado en la consola
            Console.WriteLine(sale.GetInfoWithTax());

            // Esperar la entrada del usuario antes de cerrar la aplicación
            Console.WriteLine("Presiona Enter para salir...");
            Console.ReadLine();
        }
    }
}
