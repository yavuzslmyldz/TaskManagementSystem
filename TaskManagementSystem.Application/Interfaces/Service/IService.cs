using TaskManagementSystem.Application.Dto;

namespace TaskManagementSystem.Application.Interfaces.Service
{
    public interface IService<T, I> where T : class
    {
        Task<int> CreateAsync(T dto);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(I id);
        Task<int> UpdateAsync(T dto);
        Task<int> DeleteAsync(I id);
    }
}
