namespace ConsoleApp.Abstractions.Interfaces;

public interface ICompositionConnection<T>
{
    void CreateCompositionConnection(T entity);
    void RemoveCompositionConnection(T entity);
    void EditCompositionConnection(T oldEntity, T newEntity);
}