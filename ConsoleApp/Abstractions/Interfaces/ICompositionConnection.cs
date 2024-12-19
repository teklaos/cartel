namespace ConsoleApp.Abstractions.Interfaces;

public interface ICompositionConnection<T>
{
    void CreateCompositionConnection(T entity);
    void DestroyCompositionConnection(T entity);
    void ModifyCompositionConnection(T entity);
}