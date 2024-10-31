using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1ºRelacionEjercicios
{
    delegate bool ValidarNumero(int x);//Ejercicio 1

    delegate void ValidarNumero2(int x);//Ejercicio 2

    internal class Program
    {

        static bool MayorAcero(int x) => x > 0;//Ejercicio 1

        //Ejercicio 2

        static void MayorACero2(int x)
        {
            Console.WriteLine($"{x} es {(x > 0 ? "mayor" : "menor")} que 0");
        }

        static void Espar(int x) 
        {
            Console.WriteLine($"{x} es {(x % 2 == 0 ? "par" : "impar")}");
        }

        static void Main(string[] args)
        {
            //Ejercicio 1
            Console.WriteLine("Ejercicio 1 validar número mayor que cero");
            ValidarNumero validate = MayorAcero;
            Console.WriteLine("Es '2' mayor que cero: "+ (validate(-2) ? "verdadero" : "falso"));

            //------------------------------------------------------------------------------------

            //Ejercicio 2
            ValidarNumero2 validate2 = MayorACero2;
            validate2 += Espar;

            int num = 3;
            foreach (ValidarNumero2 validarNumero in validate2.GetInvocationList()) 
            {
                validarNumero(num);
            }

        }
    }
}
