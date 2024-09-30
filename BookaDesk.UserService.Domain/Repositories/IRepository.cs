using BookaDesk.UserService.Domain.Models;

namespace BookaDesk.UserService.Domain.Repositories;

public interface IRepository<T> where T : IDomainModel
{
    Task<T> GetByIdAsync(Guid id);
    Task<IEnumerable<T>> GetAllAsync();
    Task CreateAsync(T entity);
    Task UpdateAsync(Guid id, T entity);
    Task DeleteAsync(Guid id);
}