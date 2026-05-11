using Microsoft.Data.Sqlite;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection.PortableExecutable;
using System.Text;

namespace BaseDeDatosConnection
{
    public class GestionDbEjercicio1

    {
        SqliteConnection conexion;
        public bool Conectar()
        {
            return false;
        }
        public void Desconectar()
        {

        }
        public DataTable BuscarPiso(int superficieMin, int habitacionesMin)
        {
            // 1. Abrir una conexion
            Conectar();

            // 2. Crear una sentencia/instruccion SQL
            string sql = "SELECT referencia, superficie, habitaciones, precio " +
                "FROM pisos " + // 40 m2 -> 50 m2
                "WHERE superficie >= :superMin AND habitaciones >= :habitMin " +
                "ORDER BY precio";

            // 3. Ejectuar la instruccion SQL

            var comando = conexion.CreateCommand();
            comando.CommandText = sql;

            var paramSuperficieMin = comando.CreateParameter();
            paramSuperficieMin.ParameterName = "superMin";
            paramSuperficieMin.Value = superficieMin;
            comando.Parameters.Add(paramSuperficieMin);

            var paramHabitacionesMin = comando.CreateParameter();
            paramHabitacionesMin.ParameterName = "habitMin";
            paramHabitacionesMin.Value = habitacionesMin;
            comando.Parameters.Add(paramHabitacionesMin);

            comando.Prepare();

            // 4. Obtener los resultados
            SqliteDataReader resultado = comando.ExecuteReader();

            // 5. Convertir resultados (opcional)
            var dataTable = new DataTable();
            dataTable.Columns.Add("referencia");
            dataTable.Columns.Add("superficie");
            dataTable.Columns.Add("habitaciones");
            dataTable.Columns.Add("precio");
            while (resultado.Read())
            {
                dataTable.Rows.Add(
                    resultado.GetString("referencia"),
                    resultado.GetInt32("superficie"),
                    resultado.GetInt32("habitaciones"),
                    resultado.GetInt32("precio")
                    );
            }
            return dataTable;
        }
        public void AltaPiso(string r, int s, int h, int p)
        {
            // 1. Abrir una conexion
            Conectar();

            // 2. Crear una sentencia/instruccion SQL
            string sql = "SELECT referencia, superficie, habitaciones, precio " +
                "FROM pisos " + // 40 m2 -> 50 m2
                "WHERE superficie >= :superMin AND habitaciones >= :habitMin " +
                "ORDER BY precio";

            // 3. Ejectuar la instruccion SQL

            var comando = conexion.CreateCommand();
            comando.CommandText = sql;


            comando.Prepare();

            // 4. Obtener los resultados
            SqliteDataReader resultado = comando.ExecuteReader();

            // 5. Convertir resultados (opcional)

        }

        public void main(string[] args)
        {
            //pedir al usuario -> 
            int superficieMinima = 10;
            int habitacionesMinima = 1;
            GestionDbEjercicio1 gestion = new GestionDbEjercicio1();
            var pisos = gestion.BuscarPiso(superficieMinima, habitacionesMinima);
        }

    }
}
