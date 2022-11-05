using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagementSystem.Application.Dto;
using TaskManagementSystem.Application.Interfaces.Repository;
using TaskManagementSystem.Application.Interfaces.Service;
using TaskManagementSystem.Domain.Entities;

namespace TaskManagementSystem.Infrastructure.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentReposityory _commentRepository;
        private readonly IMapper _mapper;

        public CommentService(ICommentReposityory commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }
        

        public async Task<int> CreateAsync(CommentDto dto)
        {
            return await _commentRepository.CreateAsync(_mapper.Map(dto, new Comment()));
        }

        public async Task<int> DeleteAsync(int id)
        {
           return await _commentRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<CommentDto>> GetAllAsync()
        {
            IEnumerable<Comment> commentList = await _commentRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<Comment>, IEnumerable<CommentDto>>(commentList);
        }

        public async Task<IEnumerable<CommentDto>> GetAllByTaskAsync(int taskId)
        {
            IEnumerable<Comment> commentList = await _commentRepository.GetAllByTaskAsync(taskId);

            return _mapper.Map<IEnumerable<Comment>, IEnumerable<CommentDto>>(commentList);
        }

        public async Task<CommentDto> GetAsync(int id)
        {
            Comment comment = await _commentRepository.GetAsync(id);

            return _mapper.Map<Comment, CommentDto>(comment);
        }

        public async Task<int> UpdateAsync(CommentDto dto)
        {
           return await _commentRepository.UpdateAsync(_mapper.Map(dto, new Comment()));
        }
    }
}
