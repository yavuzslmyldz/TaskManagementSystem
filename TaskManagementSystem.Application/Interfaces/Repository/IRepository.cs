namespace TaskManagementSystem.Application.Interfaces.Repository
{
    public interface IRepository<T, I> where T : class
    {
        Task<int> CreateAsync(T entity);
        Task<T> GetAsync(I id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<int> DeleteAsync(I id);
        Task<int> UpdateAsync(T entity);
    }
}
