namespace WebApi.Repositories;

using Dapper;
using WebApi.Entities;
using WebApi.Helpers;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetAll();
    Task<User> GetById(int id);
    Task<User> GetByEmail(string email);
    Task Create(User user);
    Task Update(User user);
    Task Delete(int id);
}

public class UserRepository : IUserRepository
{
    private DataContext _context;

    public UserRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<User>> GetAll()
    {
        using var connection = _context.CreateConnection();
        var sql = """
            SELECT * FROM Users
        """;
        return await connection.QueryAsync<User>(sql);
    }

    public async Task<User> GetById(int id)
    {
        using var connection = _context.CreateConnection();
        var sql = """
            SELECT * FROM Users 
            WHERE Id = @id
        """;
        return await connection.QuerySingleOrDefaultAsync<User>(sql, new { id });
    }

    public async Task<User> GetByEmail(string email)
    {
        using var connection = _context.CreateConnection();
        var sql = """
            SELECT * FROM Users 
            WHERE Email = @email
        """;
        return await connection.QuerySingleOrDefaultAsync<User>(sql, new { email });
    }

    public async Task Create(User user)
    {
        using var connection = _context.CreateConnection();
        var sql = """
            INSERT INTO Users (FirstName, LastName, Email, CreatedDate, UpdatedDate)
            VALUES (@FirstName, @LastName, @Email, @CreatedDate, @UpdatedDate)
        """;
        await connection.ExecuteAsync(sql, user);
    }

    public async Task Update(User user)
    {
        var updatedDate= DateTime.UtcNow;
        var FirstName = user.FirstName;
        var LastName = user.LastName;
        var Email = user.Email;
        var Id = user.Id;
        using var connection = _context.CreateConnection();
        var sql = @"
        UPDATE Users 
        SET FirstName = @FirstName,
            LastName = @LastName, 
            Email = @Email, 
            UpdatedDate = @UpdatedDate
            WHERE Id = @Id;
    ";
        await connection.ExecuteAsync(sql, new
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            UpdatedDate = updatedDate,
            user.Id
        });
    }

    public async Task Delete(int id)
    {
        using var connection = _context.CreateConnection();
        var sql = """
            DELETE FROM Users 
            WHERE Id = @id
        """;
        await connection.ExecuteAsync(sql, new { id });
    }
}