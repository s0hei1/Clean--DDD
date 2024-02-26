using Domain;
using Domain.Entities;

namespace Application.Users.Commands;


public class CreateUserCommandHandler
{


    public async Task<int> Handle(CreateUserCommand createUserCommand, CancellationToken cancellationToken)
    {
        var user = UserEntity.Create(createUserCommand.Username, createUserCommand.Password);

        return 0;
    }
}