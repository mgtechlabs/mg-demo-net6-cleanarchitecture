namespace MG.Net6.API.CleanArchitecture.Domain.Contracts.Repositories;

public interface IToDoRepository
{
    Task<IEnumerable<ToDoEntity>> FetchAsync();
    Task<ToDoEntity> SaveAsync(ToDoEntity entityToDo);
    Task DeleteAsync(ToDoEntity entityToDo);
}
