using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppCollections
{
    public class ColaReservas
    {
        Queue<Reserva> cola = new Queue<Reserva>();
        public void AñadirReserva(string nombre, string telefono, int unidades)
        {
            Reserva reserva = new Reserva(nombre, telefono, unidades);
            cola.Enqueue(reserva);

            // Crea una nueva reserva con los datos recibidos como parámetros
            // y la añade a la cola
        }
        public List<Reserva> ServirReservas(int disponibles)
        {
            List<Reserva> despachos = new List<Reserva>();
            Reserva reserva = cola.Dequeue();
            while (reserva.GetUnidades() <= disponibles)
            {
                // añado a despachos
                despachos.Add(reserva);
                //despacho
                disponibles = disponibles - reserva.GetUnidades();
                reserva = cola.Dequeue();
            }
            return despachos;
            // Han llegado “disponibles” unidades. Este método devuelve una lista
            // con las reservas de la cola que se pueden servir siguiendo el orden
            // de reserva (es decir, si hay cuatro reservas de 4, 3, 2 y 1 unidades
            // que han llegado en ese orden, y llegan 8 unidades disponibles, el
            // método devuelve una lista con las dos primeras reservas (la de 4 y
            // la de 3). Las reservas añadidas a la lista desaparecen de la cola.
        }
    }
}

