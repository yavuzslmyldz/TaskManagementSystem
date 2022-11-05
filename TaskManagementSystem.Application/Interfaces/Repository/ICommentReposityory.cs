using TaskManagementSystem.Domain.Entities;

namespace TaskManagementSystem.Application.Interfaces.Repository
{
    public interface ICommentReposityory : IRepository<Comment, int>
    {
        Task<IEnumerable<Comment>> GetAllByTaskAsync(int taskId);
    }
}
