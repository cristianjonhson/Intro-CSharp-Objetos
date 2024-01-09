﻿using Creacion_Objetos;
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

    // Clase principal del programa.
    internal class Program
    {
        // Método principal que se ejecuta al iniciar el programa.
        static void Main(string[] args)
        {
            // Crear una instancia de MyList que almacena números enteros con un límite de 5 elementos.
            var numbers = new MyList<int>(5);
            var names = new MyList<string>(5);

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

            // Imprime el contenido de ambas listas
            Console.WriteLine("Numbers: " + numbers.GetContent());
            Console.WriteLine("Names: " + names.GetContent());

            // Esperar la entrada del usuario antes de cerrar la aplicación
            Console.WriteLine("Presiona Enter para salir...");
            Console.ReadLine();
        }
    }
}