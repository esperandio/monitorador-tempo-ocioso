using Microsoft.Data.Sqlite;

namespace MonitoramentoTempoOcioso
{
    class SQLiteEventRepository : IEventRepository
    {
        private readonly SqliteConnection _sqliteConnection;

        public SQLiteEventRepository()
        {
            var connectionString = new SqliteConnectionStringBuilder()
            {
                DataSource = @"C:\Temp\events.db",
                Mode = SqliteOpenMode.ReadWriteCreate
            }.ToString();

            _sqliteConnection = new SqliteConnection(connectionString);

            _sqliteConnection.Open();

            using var command = _sqliteConnection.CreateCommand();

            command.CommandText = @"
                CREATE TABLE IF NOT EXISTS events (
	                id INTEGER PRIMARY KEY AUTOINCREMENT,
	                dt_event DATETIME,
                    nr_milliseconds_idle INTEGER
                );
            ";

            command.ExecuteNonQuery();
        }

        public void Add(IdleTimeEvent idleEvent)
        {
            using var command = _sqliteConnection.CreateCommand();

            command.CommandText = @"
                INSERT INTO events
                    (dt_event, nr_milliseconds_idle) 
                VALUES
                    (@dt_event, @nr_milliseconds_idle);
            ";

            command.Parameters.AddWithValue("@dt_event", idleEvent.DateTime.ToString("yyyy-MM-dd HH:mm:ss"));
            command.Parameters.AddWithValue("@nr_milliseconds_idle", idleEvent.MillisecondsIdle);

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
