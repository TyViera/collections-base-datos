using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppCollections
{
    public class Pedido
    {
        public Pedido(string referencia, int unidades) { }
        // Metodo que procesa el pedido
        public void Procesar() { }

        static void Main(string[] args)
        {
            Queue<Pedido> pedidosPendientes = new Queue<Pedido>();
            Queue<Pedido> pedidosProcesados = new Queue<Pedido>();
            bool salir = false;
            while (!salir)
            {
                Console.WriteLine("Opciones:");
                Console.WriteLine("1 - Nuevo pedido");
                Console.WriteLine("2 - Procesar pedido");
                Console.WriteLine("3 - Estado colas");
                Console.WriteLine("4 - Salir");
                int opcion = Convert.ToInt32(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        // ...
                        //pedir datos al usuario
                        string referencia = "";
                        int unidades = 3;
                        Pedido pedido = new Pedido(referencia, unidades);
                        pedidosPendientes.Enqueue(pedido);
                        
                        // -> pedidosPendientes.Enqueue(new Pedido(referencia, unidades));
                        break;
                    case 2:
                        Pedido pedidoMasAntiguo = pedidosPendientes.Dequeue();
                        pedidoMasAntiguo.Procesar();

                        pedidosProcesados.Enqueue(pedidoMasAntiguo);

                        break;
                    case 3:
                        Console.WriteLine("Pedidos pendientes -> " + pedidosPendientes.Count);
                        Console.WriteLine("Pedidos procesados -> " + pedidosProcesados.Count);
                        break;
                    case 4:
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Opción no válida");
                        break;
                }
            }
        }
    }
}
