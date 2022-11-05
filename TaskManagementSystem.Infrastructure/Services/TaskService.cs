using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagementSystem.Application.Dto;
using TaskManagementSystem.Application.Interfaces.Repository;
using TaskManagementSystem.Application.Interfaces.Service;
using TaskManagementSystem.Domain.Entities;

namespace TaskManagementSystem.Infrastructure.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public TaskService(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<int> CreateAsync(TaskDto dto)
        {
          return  await _taskRepository.CreateAsync(_mapper.Map<TaskDto, Duty>(dto));
        }

        public async Task<IEnumerable<TaskDto>> GetAllAsync()
        {
            IEnumerable<Duty> dutyList = await _taskRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<Duty>, IEnumerable<TaskDto>>(dutyList);
        }

        public async Task<TaskDto> GetAsync(int id)
        {
            Duty duty = await _taskRepository.GetAsync(id);

            return _mapper.Map<Duty, TaskDto>(duty);
        }

        public async Task<int> UpdateAsync(TaskDto dto)
        {
           return await _taskRepository.UpdateAsync(_mapper.Map<TaskDto, Duty>(dto));
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _taskRepository.DeleteAsync(id);
        }

    }
}
