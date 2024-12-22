namespace ConsoleApp.Abstractions.Interfaces;

public interface IReflexiveAssociation<T> {
    void AddSelfAssociation(T entity);
    void RemoveSelfAssociation(T entity);
    void EditSelfAssociation(T oldEntity, T newEntity);
}