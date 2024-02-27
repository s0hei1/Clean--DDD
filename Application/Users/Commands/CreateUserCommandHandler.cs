using Domain;
using Domain.Entities;
using Domain.Repository;

namespace Application.Users.Commands;


public class CreateUserCommandHandler
{
    private readonly IUserRepository _userRepository;
    private IUnitOfWork _unitOfWork;

    public CreateUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }


    public async Task<int> Handle(CreateUserCommand createUserCommand, CancellationToken cancellationToken)
    {
        var user = UserEntity.Create(createUserCommand.Username, createUserCommand.Password);

        _userRepository.Add(user);

        await _unitOfWork.Apply(cancellationToken);
        
        return 0;
    }
}