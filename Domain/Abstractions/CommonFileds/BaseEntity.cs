namespace Domain.Abstractions.CommonFileds;

public abstract class BaseEntity : IHasId
{
    public int Id { get; set; }
}