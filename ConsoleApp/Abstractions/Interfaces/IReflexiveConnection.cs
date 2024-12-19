namespace ConsoleApp.Abstractions.Interfaces;

public interface IReflexiveConnection<T>
{
    void AddSelfConnection(T entity);
    void RemoveSelfConnection(T entity);
    void EditSelfConnection(T oldEntity, T newEntity);
}