namespace ConsoleApp.Abstractions.Interfaces;

public interface IReflexiveConnection<T>
{
    void CreateSelfConnection(T entity);
    void DestroySelfConnection(T entity);
    void EditSelfConnection(T entity);
}