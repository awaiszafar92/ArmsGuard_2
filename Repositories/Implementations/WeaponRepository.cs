using ARMSGUARD.Models;
using ARMSGUARD.Repositories.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;

namespace ARMSGUARD.Repositories.Implementations;

public sealed class WeaponRepository(IConfiguration configuration) : IWeaponRepository
{
    private const string SelectColumns = "WeaponId, Name, Category, Manufacturer, Description, ImagePath, CreatedDate";

    public async Task<IEnumerable<Weapon>> GetAllAsync()
    {
        const string sql = $"SELECT {SelectColumns} FROM dbo.Weapons ORDER BY Name;";
        await using var connection = CreateConnection();
        return await connection.QueryAsync<Weapon>(sql);
    }

    public async Task<Weapon?> GetByIdAsync(int weaponId)
    {
        var sql = $"SELECT {SelectColumns} FROM dbo.Weapons WHERE WeaponId = @WeaponId;";
        await using var connection = CreateConnection();
        return await connection.QuerySingleOrDefaultAsync<Weapon>(sql, new { WeaponId = weaponId });
    }

    public async Task<int> AddAsync(Weapon weapon)
    {
        const string sql = """
            INSERT INTO dbo.Weapons (Name, Category, Manufacturer, Description, ImagePath, CreatedDate)
            OUTPUT INSERTED.WeaponId
            VALUES (@Name, @Category, @Manufacturer, @Description, @ImagePath, @CreatedDate);
            """;
        await using var connection = CreateConnection();
        return await connection.ExecuteScalarAsync<int>(sql, weapon);
    }

    public async Task<bool> UpdateAsync(Weapon weapon)
    {
        const string sql = """
            UPDATE dbo.Weapons
            SET Name = @Name,
                Category = @Category,
                Manufacturer = @Manufacturer,
                Description = @Description,
                ImagePath = @ImagePath
            WHERE WeaponId = @WeaponId;
            """;
        await using var connection = CreateConnection();
        return await connection.ExecuteAsync(sql, weapon) == 1;
    }

    public async Task<bool> DeleteAsync(int weaponId)
    {
        const string sql = "DELETE FROM dbo.Weapons WHERE WeaponId = @WeaponId;";
        await using var connection = CreateConnection();
        return await connection.ExecuteAsync(sql, new { WeaponId = weaponId }) == 1;
    }

    private SqlConnection CreateConnection()
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new InvalidOperationException("Configure the DefaultConnection connection string before using the Weapon repository.");
        }

        return new SqlConnection(connectionString);
    }
}
