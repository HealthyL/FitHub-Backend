using System.Text.Json.Serialization;

namespace fithub_backend.IAM.Domain.Model.Aggregates;

public class User
{
    public User() : this(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty)
    {
    }

    public User(string username, string email, string birthdate, string objective, string passwordHash)
    {
        Username = username;
        Email = email;
        Birthdate = birthdate;
        Objective = objective;
        PasswordHash = passwordHash;
    }

    // Nuevo constructor
    public User(string username, string passwordHash)
    {
        Username = username;
        PasswordHash = passwordHash;
    }

    public int Id { get; }
    public string Username { get; private set; }
    public string Email { get; private set; }
    public string Birthdate { get; private set; }
    public string Objective { get; private set; }

    [JsonIgnore] public string PasswordHash { get; private set; }

    public User UpdateUsername(string username)
    {
        Username = username;
        return this;
    }

    public User UpdatePasswordHash(string passwordHash)
    {
        PasswordHash = passwordHash;
        return this;
    }
}