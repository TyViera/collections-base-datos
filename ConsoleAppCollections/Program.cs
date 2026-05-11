//Declarar una variable tipo entero

using ConsoleAppCollections;

//lista de documentos
List<Documento> lista_docs;

// Cola de impresion
Queue<Documento> cola_impresora;

// Lista imprimidos
List<Documento> lista_imprimidos;

// Collection<?????> -> lo que va a guardar
// lista de nombres de documentos
List<string> lista_nombres;


foreach (Documento d in lista_docs) { 
    // que deberia pasar para que "d" se envie a la cola
    if(d.GetTamaño() < 200_000)
    {
        // enviar a cola
        cola_impresora.Enqueue(d);
        d.SetEstado("En cola");
    }
}

//Simular termina de imprimir
Documento documento = cola_impresora.Dequeue();
documento.SetEstado("Imprimido");
lista_imprimidos.Add(documento);
// Final

// Primero leer los tipos de datos que le van a dar (Documento)
// Revisar cuantas estructuras de datos vamos a necesitar (3 -> lista_docs, cola_impresora, lista_imprimidos)
// Para cada estructura de datos, ver que tipo de estructura necesitan y se adapta mejor)
// Hacer los enunciados
// -> Cual de la estructura antes revisada/declarada voy a usar
// Aprenderse los metodos mas importantes de cada estructura (Add/Remove/Enqueue/Dequeue/Push/Pop)
