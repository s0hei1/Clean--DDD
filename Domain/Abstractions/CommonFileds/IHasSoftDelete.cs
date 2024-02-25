using System.ComponentModel;

namespace Domain.Abstractions.CommonFileds;

public interface IHasSoftDelete
{
    public bool IsDelete { get; set; }
}