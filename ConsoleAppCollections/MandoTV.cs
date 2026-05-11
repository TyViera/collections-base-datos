using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppCollections
{
    public class MandoTV
    {
        int canalActual;
        Stack<int> canalesAnteriores = new Stack<int>();

        public int CambiarCanal(int nuevo)
        {
            // suponemos que canal actual es 4, y quiero cambiar a 8,
            // solo guardamos 4
            canalesAnteriores.Push(this.canalActual);// 8
            this.canalActual = nuevo;
            return 0;
        }

        public void CanalAnterior()
        {
            var ultimoCanal = canalesAnteriores.Pop();//lee y elimina de la pila el valor inicial 
            this.canalActual = ultimoCanal;
        }
    }
}
