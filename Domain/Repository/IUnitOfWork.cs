namespace Domain.Repository;

public interface IUnitOfWork
{
    public Task Apply(CancellationToken cancellationToken);
}