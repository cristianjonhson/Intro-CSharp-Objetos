using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

class Program
{
    static string sharedJson = "{\"person\": {\"name\": \"John\", \"age\": 30, \"address\": {\"city\": \"ExampleCity\", \"zip\": \"12345\"}}}";
    static object lockObject = new object();

    static void Main()
    {
        // Crear dos tareas que manipulan el JSON compartido simultáneamente.
        Task tarea1 = Task.Run(() => ModificarJson("Tarea 1"));
        Task tarea2 = Task.Run(() => ModificarJson("Tarea 2"));

        // Esperar a que ambas tareas finalicen antes de continuar.
        Task.WaitAll(tarea1, tarea2);

        Console.WriteLine("Programa principal ha terminado. Resultado final del JSON:");
        Console.WriteLine(FormatJson(sharedJson));

        // Esperar la entrada del usuario antes de cerrar la aplicación.
        Console.WriteLine("Presiona Enter para salir...");
        Console.ReadLine();
    }

    // Clase que representa la estructura del JSON
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Address Address { get; set; }

        // Constructor para inicializar Address al crear una nueva instancia de Person.
        public Person()
        {
            Address = new Address();
        }
    }

    public class Address
    {
        public string City { get; set; }
        public string Zip { get; set; }
    }


    static void ModificarJson(string nombreTarea)
    {
        lock (lockObject)
        {
            // Deserializar el JSON actual a un objeto de la clase Person.
            Person person = JsonConvert.DeserializeObject<Person>(sharedJson);

            // Modificar la estructura del objeto.
            person.Age += 1;
            person.Address.City = nombreTarea; // Modificar la ciudad con el nombre de la tarea.

            // Simular algún procesamiento específico de la tarea.
            Console.WriteLine($"{nombreTarea} modificó el JSON: {JsonConvert.SerializeObject(person)}");

            // Serializar el objeto modificado de vuelta a JSON.
            sharedJson = JsonConvert.SerializeObject(person);
        }
    }

    // Método para formatear un JSON con indentación.
    static string FormatJson(string json)
    {
        try
        {
            // Parsea el JSON para obtener un objeto JToken.
            JToken parsedJson = JToken.Parse(json);

            // Convierte el objeto JToken a una cadena de JSON con formato.
            return parsedJson.ToString(Formatting.Indented);
        }
        catch (JsonReaderException)
        {
            // En caso de un error al parsear el JSON, devuelve el JSON sin formato.
            return json;
        }
    }
}
