namespace ConsoleApp.Abstractions.Interfaces;

public interface ICompositionAssociation<T> {
    void AddCompositionAssociation(T entity);
    void RemoveCompositionAssociation(T entity);
    void EditCompositionAssociation(T oldEntity, T newEntity);
}