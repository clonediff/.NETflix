using ClickHouse.Client.ADO;
using ClickHouse.Client.Utility;

namespace DotNetflix.Analytics.Repositories;

public class FilmVisitsRepository : IFilmVisitsRepository
{
    private const string TableName = "FilmVisits";
    private readonly ClickHouseConnection _connection;

    public FilmVisitsRepository(ClickHouseConnection connection)
    {
        _connection = connection;
    }

    public Task CreateTableAsync()
    {
        return _connection.ExecuteStatementAsync($$"""
            CREATE TABLE IF NOT EXISTS {{TableName}}
            (
                Id UUID NOT NULL,
                FilmId UInt32 NOT NULL,
                Visits UInt32 NOT NULL
            )
            Engine = MergeTree()
            PRIMARY KEY Id
        """);
    }

    public async Task AddOrUpdateVisitAsync(int filmId)
    {
        await using var command = _connection.CreateCommand();

        command.CommandText = $$"""
            SELECT EXISTS
            (
                SELECT 1 FROM {{TableName}}
                WHERE FilmId = {FilmId:UInt32}
            )
        """;

        command.AddParameter("FilmId", filmId);

        var reader = await command.ExecuteReaderAsync();
        await reader.ReadAsync();
        var resultColumnName = reader.GetColumnNames()[0];

        if ((byte) reader[resultColumnName] == 1)
        {
            await UpdateAsync(filmId);
        }
        else
        {
            await AddAsync(filmId);
        }
    }

    public async Task<int> GetFilmVisitsAsync(int filmId)
    {
        await using var command = _connection.CreateCommand();

        command.CommandText = $$"""
            SELECT Visits FROM {{TableName}}
            WHERE FilmId = {FilmId:UInt32}
        """;

        command.AddParameter("FilmId", filmId);

        var reader = await command.ExecuteReaderAsync();
        await reader.ReadAsync();

        if (reader["Visits"] is null)
        {
            return -1;
        }

        return (int) (uint) reader["Visits"];
    }

    private async Task AddAsync(int filmId)
    {
        await using var command = _connection.CreateCommand();

        command.CommandText = $$"""
            INSERT INTO {{TableName}} VALUES
            (generateUUIDv4(), {FilmId:UInt32}, 1)
        """;

        command.AddParameter("FilmId", filmId);

        await command.ExecuteNonQueryAsync();
    }

    private async Task UpdateAsync(int filmId)
    {
        await using var command = _connection.CreateCommand();

        command.CommandText = $$"""
            ALTER TABLE {{TableName}}
            UPDATE Visits = Visits + 1
            WHERE FilmId = {FilmId:UInt32}
        """;

        command.AddParameter("FilmId", filmId);

        await command.ExecuteNonQueryAsync();
    }
}