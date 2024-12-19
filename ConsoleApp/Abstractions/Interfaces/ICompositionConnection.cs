namespace ConsoleApp.Abstractions.Interfaces;

public interface ICompositionConnection<T>
{
    void AddCompositionConnection(T entity);
    void RemoveCompositionConnection(T entity);
    void EditCompositionConnection(T oldEntity, T newEntity);
}