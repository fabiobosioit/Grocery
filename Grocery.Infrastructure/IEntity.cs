namespace Grocery.Infrastructure;

public interface IEntity<TKey>
{
    TKey Id { get; set; }
}