using TaskManagementSystem.Application.Dto;

namespace TaskManagementSystem.Application.Interfaces.Service
{
    public interface ICommentService : IService<CommentDto, int>
    {
        Task<IEnumerable<CommentDto>> GetAllByTaskAsync(int taskId);
    }
}
