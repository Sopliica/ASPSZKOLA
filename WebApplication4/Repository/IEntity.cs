namespace WebApplication4.Repository;

public interface IEntity<T>
{
    public T Id { get; set; }
}
