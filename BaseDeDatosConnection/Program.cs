using BaseDeDatosConnection;


var db = new GestionBD();
db.CrearEstructura();
var municipios = db.ObtenerMunicipios(0, 10000000);

Console.WriteLine("Hay {0} municipios", municipios.Count);
foreach (var municipio in municipios)
{
    Console.WriteLine("Municipio {0}", municipio);
}