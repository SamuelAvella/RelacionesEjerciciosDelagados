using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2ºRelacionEjercicios
{
    //Ejercicio 1
    delegate double Operacion(int x, int y); //Los he tenido que poner double, porque no se si se puede parsear de alguna forma para que la division que puede delvover decimales se pueda relacionar con un delegate tipo int
  
    //Ejercicio 6
    delegate int Operar(int x, int y);

    //Ejercicio 7 
    delegate int OperarArray(int[] numeros);
    internal class Program
    {
        //Ejercicio 1
        static double Sumar(int x, int y) => x + y;

        //Ejercicio 2
        static double Restar(int x, int y) => x - y;
        
        //Ejercicio 3 
        static double Multiplicar(int x, int y) => x * y;

        //Ejercicio 4
        static double Dividir(int x, int y)
        {
            if (y == 0)
                throw new DivideByZeroException("Error: División por cero.");

            return Math.Round( (double)x / y, 2);
        }

        //Ejercicio 5
        static void EjecutarOperacion(Operacion op, int x , int y)
        {
           Console.WriteLine($"Resultado: {op(x, y)}");
        }

        //Ejercicio 6
        static int Suma(int x, int y) => x + y;

        static int Resta(int x, int y) => x - y;

        static int Multiplicacion(int x, int y) => x * y;

        //Ejercicio 7 
        static int Suma(int[] numeros) 
        {
            int resultado = 0;
            foreach(int num in numeros)
            {
                resultado += num;
            }
            return resultado;
        }

        static int Multiplicacion(int[] numeros)
        {
            int resultado = 1;
            foreach (int num in numeros)
            {
                resultado *= num;
            }
            return resultado;
        }

        static void Main(string[] args)
        {
            //Ejercicio 1
            Console.WriteLine("Ejercicio 1: Delegado básico");
            Operacion opEj1 = Sumar;
            Console.WriteLine($"Opercación sumar de 2 + 3: {opEj1(2, 3)}");

            //Ejercicio 2
            Console.WriteLine("\nEjercicio 2: Multiples métodos");
            Operacion opEj2 = Sumar;
            opEj2 += Restar;
            Console.WriteLine("Ambos metodos con los número 5 y 3, primero suma despues resta");
            foreach(Operacion metodo in opEj2.GetInvocationList())
            {
                Console.WriteLine($"·{metodo(5,3)}");
            }

            //Ejercicio 3
            Console.WriteLine("\nEjercicio 3: Uso de Multicast Delegates");
            Operacion opEj3 = Sumar;
            opEj3 += Restar;
            opEj3 += Multiplicar;
            Console.WriteLine("Todos los métodos con los número 5 y 3, primero suma, segundo resta y tercero multiplicación");
            foreach (Operacion metodo in opEj3.GetInvocationList())
            {
                Console.WriteLine($"·{metodo(5, 3)}");
            }

            //Ejercicio 4
            Console.WriteLine("\nEjercicio 4: Delegados con Diferentes Métodos");
            Operacion opEj4 = Sumar;
            opEj4 += Restar;
            opEj4 += Multiplicar;
            opEj4 += Dividir;
            Console.WriteLine("Todos los métodos con los número 5 y 3, primero suma, segundo resta, tercero multiplicación y cuarto división");
            foreach (Operacion metodo in opEj4.GetInvocationList())
            {
                try
                {
                    Console.WriteLine($"·{metodo(5, 3)}");
                }
                catch (DivideByZeroException ex)
                {
                    Console.WriteLine(ex.Message); 
                }
            }

            //Ejercicio 5
            Console.WriteLine("\nEjercicio 5: Delegados y Retornos");
            EjecutarOperacion(Sumar, 5, 3);
            EjecutarOperacion(Restar, 5, 3);
            EjecutarOperacion(Multiplicar, 5, 3);

            //Ejercicio 6
            Console.WriteLine("\nEjercicio 6: Delegados y Nombres");
            Operar opEj6 = Suma;
            opEj6 += Resta;
            opEj6 += Multiplicacion;
            Console.WriteLine("Todos los métodos con los números 5 y 3, primero suma, segundo resta y tercero multiplicación, cada uno con su nombre");
            foreach (Operacion metodo in opEj6.GetInvocationList())
            {
                Console.WriteLine($"{metodo.Method.Name}: {metodo(5, 3)}");
            }

            //Ejercicio 7
            Console.WriteLine("\nEjercicio 7: Delegados y Arrays");
            Operar opEj7 = Suma;
            opEj7 += Multiplicacion;
            int[] numerosEj7 = { 1, 2, 3, 4, 5, 6, };
            Console.WriteLine("Todos los métodos con los números 5 y 3, primero suma y despues multiplicación, cada uno con su nombre");
            foreach (Operacion metodo in opEj7.GetInvocationList())
            {
                Console.WriteLine($"{metodo.Method.Name}: {metodo(numerosEj7)}");
            }
        }
    }
}
