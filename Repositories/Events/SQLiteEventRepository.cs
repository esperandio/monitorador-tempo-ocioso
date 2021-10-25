using Microsoft.Data.Sqlite;
using MonitoramentoTempoOcioso.Interfaces.Events;
using System;

namespace MonitoramentoTempoOcioso.Repositories.Events
{
    class SQLiteEventRepository : IEventRepository
    {
        private readonly SqliteConnection _sqliteConnection;

        public SQLiteEventRepository()
        {
            string pathDataSourceFile = Environment.ExpandEnvironmentVariables(@"%appdata%\events.db");

            var connectionString = new SqliteConnectionStringBuilder()
            {
                DataSource = pathDataSourceFile,
                Mode = SqliteOpenMode.ReadWriteCreate
            }.ToString();

            _sqliteConnection = new SqliteConnection(connectionString);

            _sqliteConnection.Open();

            using var command = _sqliteConnection.CreateCommand();

            command.CommandText = @"
                 CREATE TABLE IF NOT EXISTS events (
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                    ds_event TEXT
                 );
            ";

            command.ExecuteNonQuery();
        }

        public void Add(IEvent @event)
        {
            using var command = _sqliteConnection.CreateCommand();

            command.CommandText = @"
                INSERT INTO events
                    (ds_event) 
                VALUES
                    (@ds_event);
            ";

            command.Parameters.AddWithValue("@ds_event", @event.SerializeObject());

            command.ExecuteNonQuery();
        }

        public int Count()
        {
            using var command = _sqliteConnection.CreateCommand();

            command.CommandText = @"
                SELECT 
                    COUNT(*) AS nr_count 
                FROM 
                    events;
            ";

            using var reader = command.ExecuteReader();

            reader.Read();
            return reader.GetInt32(0);
        }
    }
}
