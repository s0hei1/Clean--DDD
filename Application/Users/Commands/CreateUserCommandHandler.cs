using Domain;
using Domain.Entities;

namespace Application.Users.Commands;


public class CreateUserCommandHandler
{


    public async Task<int> Handle(CreateUserCommand createUserCommand, CancellationToken cancellationToken)
    {
        UserEntity userEntity;
        var user = new UserEntity(createUserCommand.UserName, createUserCommand.Password);

        return 0;
    }
}