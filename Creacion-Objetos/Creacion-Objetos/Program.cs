using Creacion_Objetos;
using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;

namespace Creacion_Objetos
{

    //Generics: reutilizar codigo, en cuanto a metodos y clases
    //es muy comun en colecciones, listas, arrays, etc

    // Clase genérica llamada MyList que puede almacenar elementos de cualquier tipo (utilizando el tipo genérico T).
    public class MyList<T>
    {
        private List<T> _list;  // Lista interna que almacenará los elementos.
        private int _limit;     // Límite máximo de elementos que se pueden agregar a la lista.

        // Constructor de la clase MyList que recibe el límite como parámetro.
        public MyList(int limit)
        {
            _limit = limit;
            _list = new List<T>(); // Inicializar la lista aquí.
        }

        // Método para agregar elementos a la lista, verifica si se ha alcanzado el límite antes de agregar.
        public void Add(T element)
        {
            if (_list.Count < _limit)
            {
                _list.Add(element);
            }
        }

        // Método para obtener el contenido de la lista como una cadena de texto.
        public string GetContent()
        {
            string contenido = "";
            foreach (var element in _list)
            {
                contenido += element + ", ";
            }

            return contenido;
        }
    }

    // Clase que representa una cerveza con propiedades de nombre y precio.
    public class Beer
    {
        public string Name { get; set; }
        public decimal Price { get; set; }


        // Método para proporcionar una representación personalizada de la cerveza.
        public override string ToString()
        {
            // La cadena interpolada ($) permite incrustar expresiones dentro de la cadena utilizando llaves {}.
            // En este caso, estamos formateando las propiedades Name y Price como parte de la cadena.
            return $"Name: {Name}, Price: {Price:C}";
        }
    }

    // Clase principal del programa.
    internal class Program
    {
        // Método principal que se ejecuta al iniciar el programa.
        static void Main(string[] args)
        {
            // Crear una instancia de MyList que almacena números enteros con un límite de 5 elementos.
            var numbers = new MyList<int>(5);

            // Crear una instancia de MyList que almacena cadenas con un límite de 5 elementos.
            var names = new MyList<string>(5);

            // Crear una instancia de MyList que almacena objetos de tipo Beer con un límite de 3 elementos.
            var beers = new MyList<Beer>(3);

            // Agrega elementos a la lista numbers
            numbers.Add(1);
            numbers.Add(2);
            numbers.Add(3);
            numbers.Add(4);
            numbers.Add(5);

            // Agrega elementos a la lista names
            names.Add("John");
            names.Add("Alice");
            names.Add("Bob");
            names.Add("Eva");
            names.Add("Charlie");

            // Agrega elementos a la lista beers (objetos de tipo Beer).
            beers.Add(new Beer { Name = "IPA", Price = 5.99m });
            beers.Add(new Beer { Name = "Stout", Price = 7.50m });
            beers.Add(new Beer { Name = "Lager", Price = 4.25m });

            // Imprime el contenido de ambas listas
            Console.WriteLine("Numbers: " + numbers.GetContent());
            Console.WriteLine("Names: " + names.GetContent());
            Console.WriteLine("Beers: " + beers.GetContent());

            // Esperar la entrada del usuario antes de cerrar la aplicación
            Console.WriteLine("Presiona Enter para salir...");
            Console.ReadLine();
        }
    }
}