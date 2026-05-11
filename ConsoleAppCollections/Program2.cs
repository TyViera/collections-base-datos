/*
var list = new List<int>();
/*
 * 2,4,6...100
 * 2,3,5,7....97
 * 1,1,1,1,1,7
 * 100, 21, 7, 50, 30
 * 
 */
// [1, 1, 3]
// [null, 1, 3]

/*
list.Add(1); // true
list.Add(2);// true
list.Add(3);// true
list.Add(4);// true
list.Add(5);// true
// [1, 2, 3, 4, 5]

list.ElementAt(3); // retorna 4

//
list.Remove(0); // 1
// [1, 3]

list.Remove(0); // 
// [3]

for (int i = 0; i < list.Count; i++) // i= 1 lista -> 9 -> [0] -> 9
{
    // [1, 2, 3, 4, 5]
    // i = 0 -> 1
    // [2, 3, 4, 5]
    //--
    // i = 1 -> 3
    // [3, 4, 5]
    // i = 2 -> 5

    var elemento = list.ElementAt(i);
    list.Remove(elemento);
}

foreach (var elemento in list)
{

}


//..
//[1, 1, 3] -> no aceptable
// [1, 3]
var set = new HashSet<int>();

// []
set.Add(1); // true
// [1]

set.Add(1); // false
// [1]

set.Add(1); // false
// [1]

set.Remove(0);
set.ElementAt(4);
foreach (var elemento in set)
{

}

// pilas y colas
// pila -> 

/*
 * plato4
 * plato1
 * plato2
 * plato3
 */

// pila = 1 - 2 - 3 - 4 - 5 
// pila.primerElemento -> 1
// pila.Agregar(6)
// 6 - 1 - 2 - 3 - 4 - 5
// pila.primerElemento -> 6
/*
var pila = new Stack<string>();
pila.Push("plato3");
pila.Push("plato2");
pila.Push("plato1");
pila.Push("plato4");


/*
 * plato4
 * plato1
 * plato2
 * plato3
 *//*
var plato4 = pila.Pop();//plato4
pila.Push(plato4);

// 6 - 1 - 2 - 3 - 4 - 5
// pila.pop() -> 6
// getElementAt(0) + Remove(0)

pila.Peek();//plato4
// getElementAt(0)
pila.Peek(); // plato4 - 6
pila.Peek(); // plato4 - 6
pila.Peek(); // plato4 - 6
pila.Peek(); // plato4 - 6
pila.Peek(); // plato4 - 6
pila.Peek(); // plato4 - 6
//...
pila.Pop(); // plato4
pila.Pop(); // plato1
pila.Pop(); // plato2
pila.Pop(); // plato3
pila.Pop(); // error - pila vacia

// [ 2, 4, 8 ]
// pila.peek() -> 2

// [ 2, 4, 8 ]
// peek no modifica la pila
// pila.peek() -> 2

// [ 2, 4, 8 ]
// pila.pop() -> 2
// pila.peek() -> 4
// pila.pop() -> 4
// pila.pop() -> 8
// pila.peek() -> error
// pila.pop -> error
// []
// Desde aqui
// []
// pila.push(10)  -> [ 10 ]
// pila.push(10) -> [ 10, 10 ]
// pila.push(7) -> [ 7, 10, 10]
// pila.peek() -> 7 -> [ 7, 10, 10, 7 ]

// [ 7, 8, 9] -> [ 7, 8, 9, 10] 
// var valor7 = pila.pop();
// var valor8 = pila.pop();
// var valor9 = pila.pop();
// pila.push(10);
// pila.push(valor9);
// pila.push(valor8);
// pila.push(valor7);

var random = new Random();
var pila2 = new Stack<int>();
// va a tener 10 elementos
for (int i = 0; i < 10; i++)
{
    pila2.Push(random.Next(1, 100));
}

// quiero que escriban un metodo que reciva -> una pila + un indice + un valor
// va a meter el valor en el indice dado, dentro de la pila

// [ 7, 8, 9] <- valor -> 4, indice -> 1 ->  [ 7, 4, 8, 9]
// [ 8 , 9] | 7 (indice 0) es "0" igual a indice - 1 ? -> SI | detengo la eliminacion de valore
// [ 4, 8, 9 ] -> meti el valor pedido
// [ 7, 4, 8, 9] -> meter los valores que saqué

// -----
// pilaEntrada = [ 9, 7, 4, 8, 10, 21] -> valor 513 -> posicion 4 -> [ 9, 7, 4, 8, 513, 10, 21]
// var colleccionValoresSacados = new List<int>(); // []
// colleccionValoresSacados.Add(pilaEntrada.pop()) // [9]
// [ 7, 4, 8, 10, 21] -> 9
// colleccionValoresSacados.Agregar(pilaEntrada.pop()) // [9, 7]
// [ 4, 8, 10, 21] -> 7, 9
// colleccionValoresSacados.Agregar(pilaEntrada.pop()) // [9, 7, 4]
// [ 8, 10, 21] -> 4, 7, 9
// colleccionValoresSacados.Agregar(pilaEntrada.pop()) // [9, 7, 4, 8]
// [ 10, 21] -> 8, 4, 7, 9 // he terminado de sacar valores -> es "3" igual a indice - 1 ? -> SI
// pilaEntrada.push(513);
// [ 513, 10, 21] //meti valor
// pilaEntrada.push(cuartoValor);
// [ 8, 513, 10, 21] -> 4, 7, 9
// [ 4, 8, 513, 10, 21] -> 7, 9
// [ 7, 4, 8, 513, 10, 21] -> 9
// [ 9, 7, 4, 8, 513, 10, 21] -> [] acaba el algoritmo

void AgregarEnPila(Stack<int> pilaEntrada, int elementoAAgregar, int posicion)
{
    // sacar valores hasta posicion indicada
    var pilaDescarte = new Stack<int>();
    for (var i = 0; i < posicion; i++)
    {
        var valorSacado = pilaEntrada.Pop();
        pilaDescarte.Push(valorSacado);
    }
    // meter el valor a agregar
    pilaEntrada.Push(elementoAAgregar);

    // regresar valores sacados
    while (pilaDescarte.Count > 0)
    {
        var valorSacadoDescarte = pilaDescarte.Pop();
        pilaEntrada.Push(valorSacadoDescarte);
    }
}