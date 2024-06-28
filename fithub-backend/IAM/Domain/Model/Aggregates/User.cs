using System.Text.Json.Serialization;

namespace fithub_backend.IAM.Domain.Model.Aggregates;

public class User(string username, string email, string birthdate, string objective, string passwordHash)
{
    public User() : this(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty)
    {
    }

    public int Id { get; }
    public string Username { get; private set; } = username;
    public string Email { get; private set; } = email;
    public string Birthdate { get; private set; } = birthdate;
    public string Objective { get; private set; } = objective;

    [JsonIgnore] public string PasswordHash { get; private set; } = passwordHash;
    
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