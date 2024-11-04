using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4taRelacionEjercicios
{
    //Ejercicio 9
    public class Producto
    {
        public string Nombre { get; set; }
        public int Cantidad { get; set; }

        public Producto(string nombre, int cantidad)
        {
            this.Nombre = nombre;
            this.Cantidad = cantidad;
        }
    }

    //Ejercicio 10
    public class Empleado
    {
        public string Nombre { get; set; }
        public int Edad { get; set; }

        public Empleado(string nombre, int edad)
        {
            this.Nombre = nombre;
            this.Edad = edad;
        }
    }

    //Ejercicio 11
    public class Libro
    {
        public string Titulo { get; set; }
        public string Categoria { get; set; }

        public Libro(string titulo, string categoria)
        {
            Titulo = titulo;
            Categoria = categoria;
        }
    }

    //Ejercicio 12
    public class Vehiculo
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int AnioFabricacion { get; set; }

        public Vehiculo(string marca, string modelo, int anioFabricacion)
        {
            Marca = marca;
            Modelo = modelo;
            AnioFabricacion = anioFabricacion;
        }
    }

    internal class Program
    {
        //Ejercicio 1
        public delegate int Multiplicar(int x, int y);

        //Ejercicio 2
        public delegate bool VerificarPalindromo(string cadena);

        //Ejercicio 3
        public delegate double ConvertirTemperatura(double celsius);

        // Ejercicio 4
        public delegate bool EsMayorQueDiez(int numero);

        //Ejercicio 5
        public delegate bool CompararLongitud(string a, string b);

        // Ejercicio 6
        public delegate long CalcularFactorial(int numero);

        // Ejercicio 7
        public delegate int ContarCaracteres(string cadena);

        // Ejercicio 8
        public delegate bool Operacion(int numero);

        //Ejercicio 9
        public delegate bool Filtro(Producto producto);

        static void MostrarProductosFiltrados(List<Producto> productos, Filtro filtro)
        {
            foreach(Producto prod in productos)
            {
                if (filtro(prod))
                {
                    Console.WriteLine($"- {prod.Nombre} (Cantidad: {prod.Cantidad})");
                }
            }
        }

        //Ejercicio 10
        public delegate bool FiltroEmpleado(Empleado empleado);
        static void FiltarEmpleados(List<Empleado> empleados, FiltroEmpleado filtro)
        {
            foreach (Empleado empleado in empleados)
            {
                if (filtro(empleado))
                {
                    Console.WriteLine($"- {empleado.Nombre} (Edad: {empleado.Edad})");
                }
            }
        }

        //Ejercicio 11
        public delegate bool FiltroLibros(Libro libro);
        static void MostrarLibrosPorCategoria(List<Libro> libros, FiltroLibros filtro)
        {
            foreach (var libro in libros)
            {
                if (filtro(libro))
                {
                    Console.WriteLine($"- {libro.Titulo}");
                }
            }
        }

        //Ejercicio 12
        public delegate bool FiltroVehiculo(Vehiculo vehiculo);

        static void MostrarVehiculosAntiguos(List<Vehiculo> vehiculos, FiltroVehiculo filtro)
        {
            foreach (var vehiculo in vehiculos)
            {
                if (filtro(vehiculo))
                {
                    Console.WriteLine($"- {vehiculo.Marca} {vehiculo.Modelo} ({vehiculo.AnioFabricacion})");
                }
            }
        }


        static void Main(string[] args)
        {
            //Ejercicio 1
            Console.WriteLine("Ejercicio 1: Función anónima multiplicar");
            Multiplicar multiplicar = delegate (int x, int y) {
                return x * y; 
            };
            int[] par1 = { 4, 3 };
            int[] par2 = { 7, 5 };
            Console.WriteLine($"{par1[0]} * {par1[1]} = {multiplicar(par1[0], par1[1])}");
            Console.WriteLine($"{par2[0]} * {par2[1]} = {multiplicar(par2[0], par2[1])}");

            //Ejercicio 2
            Console.WriteLine("\nEjercicio 2: Función anónima verificar palíndromo");
            VerificarPalindromo esPalindromo = delegate (string texto)
            {
                string textoReverso = new string(texto.Reverse().ToArray());
                return texto.Equals(textoReverso, StringComparison.OrdinalIgnoreCase);
            };

            string palabra1 = "radar";
            string palabra2 = "puerta";

            Console.WriteLine($"'{palabra1}' es un palíndromo: {esPalindromo(palabra1)}");
            Console.WriteLine($"'{palabra2}' es un palíndromo: {esPalindromo(palabra2)}");

            //Ejercicio 3
            Console.WriteLine("\nEjercicio 3: Función anónima convertir temperatura");
            ConvertirTemperatura conversorAFarenheit = delegate (double celsius)
            {
                return Math.Round((celsius * (9.0 / 5.0)) + 32, 2);
            };

            double temp1 = 0;
            double temp2 = 30;

            Console.WriteLine($"{temp1}ºC -> {conversorAFarenheit(temp1)}ºF");
            Console.WriteLine($"{temp2}ºC -> {conversorAFarenheit(temp2)}ºF");

            //Ejercicio 4
            Console.WriteLine("\nEjercicio 4: Función anónima verificar si es mayor que 10");
            EsMayorQueDiez esMayorQueDiez = delegate (int numero)
            {
                return numero > 10; 
            };

            int num1 = 8;
            int num2 = 15;

            Console.WriteLine($"{num1} es mayor que 10: {esMayorQueDiez(num1)}");
            Console.WriteLine($"{num2} es mayor que 10: {esMayorQueDiez(num2)}");

            //Ejercicio 5
            Console.WriteLine("\nEjercicio 5: Función anónima comparar longitud");
            CompararLongitud compararLongitud = delegate (string a, string b)
            {
                return a.Length == b.Length;
            };

            string palabra3 = "mesa";
            string palabra4 = "sala";

            Console.WriteLine($"Las palabras '{palabra3}' y '{palabra4}' tienen la misma longitud: {compararLongitud(palabra3, palabra4)}");

            // Ejercicio 6
            Console.WriteLine("\nEjercicio 6: Función anónima calcular factorial");
            CalcularFactorial calcularFactorial = null; 

            calcularFactorial = delegate (int numero)
            {
                if (numero <= 1)
                    return 1;
                else
                    return numero * calcularFactorial(numero - 1); 
            };

            int num3 = 4;
            int num4 = 6;

            Console.WriteLine($"Factorial de {num3} es {calcularFactorial(num3)}");
            Console.WriteLine($"Factorial de {num4} es {calcularFactorial(num4)}");

            // Ejercicio 7
            Console.WriteLine("\nEjercicio 7: Función anónima contar caracteres");
            ContarCaracteres contarCaracteres = delegate (string cadena) {
                return cadena.Length; 
            };

            string palabra5 = "mundo";
            string palabra6 = "programa";

            Console.WriteLine($"La palabra '{palabra5}' tiene {contarCaracteres(palabra5)} caracteres.");
            Console.WriteLine($"La palabra '{palabra6}' tiene {contarCaracteres(palabra6)} caracteres.");

            // Ejercicio 8
            Console.WriteLine("\nEjercicio 8: Función anónima para verificar par o impar");
            Operacion esPar = delegate (int numero) {
                return numero % 2 == 0;
            };

            int num5 = 4;
            int num6 = 7;
            Console.WriteLine($"El número {num5} es par: {esPar(num5)}");
            Console.WriteLine($"El número {num6} es par: {esPar(num6)}");

            //Ejercicio 9
            Console.WriteLine("\nEjercicio 9: Función anónima para filtrar productos");
            List<Producto> productos = new List<Producto>
            {
                new Producto("Manzana", 10),
                new Producto("Pera", 4),
                new Producto("Plátano", 7),
                new Producto("Kiwi", 2),
                new Producto("Naranja", 5)
            };
            Console.WriteLine("Filtro producto cantidad mayor a 6:");
            Filtro filtro = delegate (Producto producto) {
                return producto.Cantidad > 6;
            };
            MostrarProductosFiltrados(productos, filtro);

            //Ejercicio 10
            Console.WriteLine("\nEjercicio 10: Función anónima para filtar empleados");
            List<Empleado> empleados = new List<Empleado>
            {
                new Empleado("Ana", 35),
                new Empleado("Luis", 41),
                new Empleado("María", 29),
                new Empleado("Carlos", 38),
                new Empleado("Sofía", 27)
            };
            Console.WriteLine("Filtro empleados mayores de 30 años:");
            FiltroEmpleado filtroEmpleado = delegate (Empleado empleado)
            {
                return empleado.Edad > 30;
            };
            FiltarEmpleados(empleados, filtroEmpleado);

            //Ejercicio 11
            Console.WriteLine("\nEjercicio 11: Función anónima para filtrar libros");
            List<Libro> libros = new List<Libro>
            {
                new Libro("Cien años de soledad", "Ficción"),
                new Libro("El amor en los tiempos del cólera", "Ficción"),
                new Libro("El túnel", "Ficción"),
                new Libro("Sapiens: De animales a dioses", "Historia"),
                new Libro("Educated", "Memorias"),
                new Libro("El arte de la guerra", "Estratégia"),
                new Libro("Astrophysics for People in a Hurry", "Ciencia"),
                new Libro("La guía del autoestopista galáctico", "Ciencia ficción"),
                new Libro("El diario de Ana Frank", "Biografía")
            };
            Console.WriteLine("Filtro libros de la categoría 'Ficción':");
            FiltroLibros filtroLibros = delegate (Libro libro) {
                return libro.Categoria.Equals("Ficción", StringComparison.OrdinalIgnoreCase);
            };
            MostrarLibrosPorCategoria(libros, filtroLibros);

            //Ejercicio 12
            Console.WriteLine("\nEjercicio 12: Función Anónima para filtar coches");
            List<Vehiculo> vehiculos = new List<Vehiculo>
            {
                new Vehiculo("Toyota", "Corolla", 2005),
                new Vehiculo("Ford", "Fiesta", 2012),
                new Vehiculo("Honda", "Civic", 2008),
                new Vehiculo("Chevrolet", "Malibu", 2000),
                new Vehiculo("Nissan", "Altima", 2015),
                new Vehiculo("Hyundai", "Elantra", 2003),
                new Vehiculo("Kia", "Soul", 2011),
                new Vehiculo("Volkswagen", "Golf", 1998),
                new Vehiculo("Subaru", "Impreza", 2009)
            };

            Console.WriteLine("Filtro coches fabricados antes del 2010:");

            FiltroVehiculo filtroAntiguo = delegate (Vehiculo vehiculo)
            {
                return vehiculo.AnioFabricacion < 2010;
            };

            MostrarVehiculosAntiguos(vehiculos, filtroAntiguo);
        }

    }
}
