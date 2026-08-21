using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ProteinTracker.Database
{
    public class DatabaseService
    {
        private readonly string connectionString =
            "Data Source=ProteinTracker.db";

        public void DatenbankErstellen()
        {
            using var connection = new SqliteConnection(connectionString);
            connection.Open();

            var command = connection.CreateCommand();

            command.CommandText =
            @"
            CREATE TABLE IF NOT EXISTS Benutzer (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Name TEXT NOT NULL UNIQUE,
                ProteinZiel REAL
            );
            ";

            command.ExecuteNonQuery();
        }

        public void ProteinZielSpeichern(string name, double proteinZiel)
        {
            using var connection = new SqliteConnection(connectionString);
            connection.Open();

            var command = connection.CreateCommand();

            command.CommandText =
            @"
            INSERT INTO Benutzer (Name, ProteinZiel)
            VALUES ($name, $proteinZiel)

            ON CONFLICT(Name)
            DO UPDATE SET ProteinZiel = $proteinZiel;
            ";

            command.Parameters.AddWithValue("$name", name);
            command.Parameters.AddWithValue("$proteinZiel", proteinZiel);

            command.ExecuteNonQuery();
        }
    }
}