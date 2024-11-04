using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3erRelacionEjercicios
{
    internal class Program
    {
        //Ejercicio 1
        public delegate bool ValidarEdades(int x);

        //Ejercicio 2
        static void ImprimirConsola(ValidarEdades validate)
        {
            Console.WriteLine(validate(19));
        }

        static void Main(string[] args)
        {
            
            //Ejercicio 1
            ValidarEdades validate = delegate (int edad)
            {
                return edad >= 18;
            };

            Console.WriteLine(validate(19));

            //Ejercicio 2
            ImprimirConsola(validate);
        }
    }
}
