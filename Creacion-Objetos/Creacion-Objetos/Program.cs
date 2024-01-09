using System;

namespace Creacion_Objetos
{
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
            Sale sale = new Sale(500, "Iphone x");

            // Puedes acceder a las propiedades y métodos de Sale
            Console.WriteLine($"Total: {sale.Total}, SaleName: {sale.GetInfo()}");
            // Esperar la entrada del usuario antes de cerrar la aplicación
            Console.WriteLine("Presiona Enter para salir...");
            Console.ReadLine();
        }
    }
}
