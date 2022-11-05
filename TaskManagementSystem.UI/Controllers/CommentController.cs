using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Application.Dto;
using TaskManagementSystem.Application.Interfaces.Service;

namespace TaskManagementSystem.WebUI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentController : ControllerBase
    {

        private readonly ILogger<CommentController> _logger;
        private readonly ICommentService _commentService;

        public CommentController(ILogger<CommentController> logger, ICommentService commentService)
        {
            _logger = logger;
            _commentService = commentService;
        }

        [HttpGet]
        public async Task<CommentDto> GetAsync(int id)
        {
            return await _commentService.GetAsync(id);
        }

        [HttpGet]
        [Route("all")]
        public async Task<IEnumerable<CommentDto>> GetAllAsync(int taskId)
        {
            return await _commentService.GetAllByTaskAsync(taskId);
        }

        [HttpPost]
        public async Task<int> CreateAsync([FromBody] CommentDto dto)
        {
            return await _commentService.CreateAsync(dto);
        }

        [HttpPut]
        public async Task<int> UpdateAsync([FromBody] CommentDto dto)
        {
            return await _commentService.UpdateAsync(dto);
        }

        [HttpDelete]
        public async Task<int> DeleteAsync(int id)
        {
            return await _commentService.DeleteAsync(id);           
        }

    }
}
