using Domain.Entities;

namespace Domain.Repository;

public interface IUserRepository
{
    public UserEntity Add(UserEntity userEntity);
    
    
}