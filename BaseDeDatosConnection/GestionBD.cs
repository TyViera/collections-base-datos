using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseDeDatosConnection
{
    public class GestionBD
    {
        SqliteConnection cnx;
        public void AbrirConexion()
        {
            cnx = new SqliteConnection("Data Source=municipios.db");
            cnx.Open();
        }

        public void CerrarConexion()
        {
            cnx.Close();
        }

        public void CrearEstructura()
        {
            // 1. Abrir una conexion
            AbrirConexion();

            // 2. Crear una sentencia/instruccion SQL
            var sql = @"CREATE TABLE IF NOT EXISTS Municipios(
                Nombre NVARCHAR PRIMARY KEY,
                Superficie INT NOT NULL,
                Poblacion INT NOT NULL
            )";

            // 3. Ejectuar la instruccion SQL
            var comando = cnx.CreateCommand();
            comando.CommandText = sql;
            comando.ExecuteNonQuery();
        }

        public List<string> ObtenerMunicipios(int minsup, int maxsup)
        {
            // Devuelve una lista con los nombres de los municipios cuya superficie está
            // comprendida entre minsup y maxsup (ambos incluidos), ordenados alfabéticamente.

            // 1. Abrir una conexion
            AbrirConexion();

            // 2. Crear una sentencia/instruccion SQL
            var sqlEjecutar = """
                    SELECT Nombre FROM Municipios
                        WHERE Superficie >= :min AND Superficie <= :max
                        ORDER BY Nombre
                """;
            /*var sqlEjecutar2 = "SELECT Nombre FROM Municipios"+
                        "WHERE Superficie >= "+minsup + " AND Superficie <= " + maxsup +
                        "ORDER BY Nombre";*/

            // 3. Ejectuar la instruccion SQL

            var comando = cnx.CreateCommand();
            comando.CommandText = sqlEjecutar;

            var paramMin = comando.CreateParameter();
            paramMin.ParameterName = "min";
            paramMin.Value = minsup;
            comando.Parameters.Add(paramMin);

            var paramMax = comando.CreateParameter();
            paramMax.ParameterName = "max";
            paramMax.Value = maxsup;
            comando.Parameters.Add(paramMax);

            comando.Prepare();

            // 4. Obtener los resultados
            var resultado = comando.ExecuteReader();
            var lista = new List<string>();
            foreach (var item in resultado)
            {
                lista.Add(item.ToString());
            }

            // 5. Convertir resultados (opcional)

            return lista;
        }

        public int EliminarMunicipios(int minpob)
        {
            // Elimina de la base de datos los municipios cuya población es menor que minpob.
            // Devuelve el número de municipios eliminados.

            // 1. Abrir una conexion
            AbrirConexion();

            // 2. Crear una sentencia/instruccion SQL
            var sqlEjecutar = "DELETE FROM Municipios WHERE Poblacion < :min";

            // 3. Ejectuar la instruccion SQL
            var comando = cnx.CreateCommand();
            comando.CommandText = sqlEjecutar;

            var paramMin = comando.CreateParameter();
            paramMin.ParameterName = "min";
            paramMin.Value = minpob;
            comando.Parameters.Add(paramMin);

            comando.Prepare();

            // 4. Obtener los resultados
            var resultado = comando.ExecuteNonQuery();
            return resultado;
        }

        public int ActualizarPoblacion(string nombre, int newpob)
        {
            // Actualiza la población del municipio indicado con el nuevo valor recibido.
            // Devuelve 0 si la operación se ha realizado con éxito, -1 en caso contrario. 

            // 1. Abrir una conexion
            AbrirConexion();

            // 2. Crear una sentencia/instruccion SQL
            var sqlEjecutar = "UPDATE SET Poblacion=:nuevaPoblacion FROM Municipios WHERE Nombre=:nombre";

            // 3. Ejectuar la instruccion SQL
            var comando = cnx.CreateCommand();
            comando.CommandText = sqlEjecutar;


            var paramNuevaPoblacion = comando.CreateParameter();
            paramNuevaPoblacion.ParameterName = "nuevaPoblacion";
            paramNuevaPoblacion.Value = newpob;
            comando.Parameters.Add(paramNuevaPoblacion);

            var paramNombre = comando.CreateParameter();
            paramNombre.ParameterName = "nombre";
            paramNombre.Value = nombre;
            comando.Parameters.Add(paramNombre);

            comando.Prepare();

            // 4. Obtener los resultados
            var resultado = comando.ExecuteNonQuery();
            if (resultado > 0)
            {
                //hay por lo menos un registro afectado - si se hizo la actualizacion
                return 0;
            }

            return -1;
        }
    }
}
