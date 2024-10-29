namespace Desafio_FSBR.Data.Interfaces;

public interface IBaseRepository<T> where T : class
{
    Task<T> GetByIdAsync(int id);
    Task<(IEnumerable<T> Items, int TotalCount)> GetAllAsync(int page, int pageSize);
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(int id);
    Task<bool> VerifyExist(int id);
}
