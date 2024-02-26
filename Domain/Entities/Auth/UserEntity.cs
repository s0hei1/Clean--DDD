using Domain.Abstractions.Hash;

namespace Domain.Entities;

public record UserEntity
{
    public string Username { get; set; }
    public string Password { get; private set; }
    
    private UserEntity(string username, string password)
    {
        Username = username;
        Password = password;
    }
    
    public static UserEntity Create(string username, string password)
    {
        return new UserEntity(
            username: username,
            password: password.Hash()
            );
    }
    
}