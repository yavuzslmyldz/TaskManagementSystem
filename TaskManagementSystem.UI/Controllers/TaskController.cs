using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Application.Dto;
using TaskManagementSystem.Application.Interfaces.Service;

namespace TaskManagementSystem.WebUI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {

        private readonly ILogger<TaskController> _logger;
        private readonly ITaskService _taskService;

        public TaskController(ILogger<TaskController> logger, ITaskService taskService)
        {
            _logger = logger;
            _taskService = taskService;
        }

        [HttpGet]
        public async Task<TaskDto> GetAsync(int id)
        {
            return await _taskService.GetAsync(id);
        }

        [HttpGet]
        [Route("all")]
        public async Task<IEnumerable<TaskDto>> GetAllAsync()
        {
            return await _taskService.GetAllAsync();
        }

        [HttpPost]
        public async Task<int> CreateAsync([FromBody] TaskDto dto)
        {
            return await _taskService.CreateAsync(dto);
        }

        [HttpPut]
        public async Task<int> UpdateAsync([FromBody] TaskDto dto)
        {
            return await _taskService.UpdateAsync(dto);
        }

        [HttpDelete]
        public async Task<int> DeleteAsync(int id)
        {
            return await _taskService.DeleteAsync(id);
        }

    }
}
