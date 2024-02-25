using Domain.Abstractions.Hash;

namespace Domain.Entities;

public record UserEntity(string UserName, string Password)
{
    public static UserEntity Create(string userName, string password)
    {
        return new UserEntity(
            UserName: userName,
            Password: password.Hash()
            );
    }
}