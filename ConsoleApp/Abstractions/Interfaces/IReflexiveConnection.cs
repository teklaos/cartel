namespace ConsoleApp.Abstractions.Interfaces;

public interface IReflexiveConnection<T>
{
    void CreateSelfConnection(T entity);
    void RemoveSelfConnection(T entity);
    void EditSelfConnection(T oldEntity, T newEntity);
}