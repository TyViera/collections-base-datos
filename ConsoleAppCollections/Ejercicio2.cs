using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppCollections
{
    internal class Ejercicio2
    {
        static void Main(string[] args)
        {
            Stack<DataContainer> s = new Stack<DataContainer>();
            bool continuar = true;
            while (continuar)
            {
                Console.WriteLine("Opciones:");
                Console.WriteLine("1 - Añadir elemento a la pila");
                Console.WriteLine("2 - Sacar (y mostrar) un elemento de la pila");
                Console.WriteLine("3 - Sacar (y mostrar) todos los elementos de la pila");
                Console.WriteLine("4 - Salir");
                int opcion = Convert.ToInt32(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        s.Push(new DataContainer());
                        break;
                    case 2:
                        var sacadoDeLaPila = s.Pop();
                        Console.WriteLine("Salio de la pila " + sacadoDeLaPila);
                        break;
                    case 3:
                        while (s.Count > 0)
                        {
                            var ultimo = s.Pop();
                            Console.WriteLine("Salio de la pila " + ultimo);
                        }
                        break;
                    case 4:
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Opción no válida");
                        break;
                }
            }
        }
    }
}
