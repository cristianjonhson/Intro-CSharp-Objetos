using Newtonsoft.Json;  // Importa la biblioteca Newtonsoft.Json para trabajar con JSON.
using System;

namespace Creacion_Objetos
{
    // Definición de la clase People que representa a una persona.
    public class People
    {
        // Propiedades de la persona: Nombre y Edad.
        public string Name { get; set; }
        public int Age { get; set; }

        // Constructor por defecto.
        public People() { }

        // Sobrescribe el método ToString para proporcionar una representación personalizada del objeto.
        public override string ToString()
        {
            return $"Objeto => Nombre: {Name}, Edad: {Age}";
        }
    }

    // Clase principal del programa.
    internal class Program
    {
        // Método principal que se ejecuta al iniciar el programa.
        static void Main(string[] args)
        {
            // Crear una instancia de la clase People y asignar valores a sus propiedades.
            var cristian = new People()
            {
                Name = "Cristian",
                Age = 29
            };

            // Serializar el objeto People a formato JSON utilizando Newtonsoft.Json.
            string json = JsonConvert.SerializeObject(cristian);

            // Imprimir la representación de la persona a través del método ToString personalizado.
            Console.WriteLine(cristian.ToString());

            // Imprimir la representación en formato JSON del objeto People.
            Console.WriteLine("Json: " + json);

            // Definir una cadena JSON que representa a una persona.
            string myJson = @"{
              ""Name"": ""Cris"",
              ""Age"": 29
            }";

            // Deserializar el JSON a un objeto People.
            People person = JsonConvert.DeserializeObject<People>(myJson);

            // Imprimir las propiedades del objeto People deserializado.
            Console.WriteLine("Objeto: " + person.Name);
            Console.WriteLine("Objeto: " + person.Age);

            // Esperar la entrada del usuario antes de cerrar la aplicación.
            Console.WriteLine("Presiona Enter para salir...");
            Console.ReadLine();
        }
    }
}
