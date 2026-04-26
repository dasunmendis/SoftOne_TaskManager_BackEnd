using AutoMapper;
using MediatR;
using TaskManager.Application.DTOs;
using TaskManager.Application.Interfaces;
using TaskManager.Domain.Interfaces;

namespace TaskManager.Application.Features.Tasks.Queries.GetTasks
{
    public class GetTasksQueryHandler : IRequestHandler<GetTasksQuery, IEnumerable<TaskDto>>
    {
        private readonly ITaskRepository _repository;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public GetTasksQueryHandler(ITaskRepository repository, IMapper mapper, ICurrentUserService currentUserService)
        {
            _repository = repository;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<IEnumerable<TaskDto>> Handle(GetTasksQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Domain.Entities.TaskItem> tasks;

            // Admin/Manager can see all tasks. Regular Users only see their own.
            if (_currentUserService.IsAdmin)
            {
                tasks = await _repository.GetAllAsync();
            }
            else
            {
                var userId = int.Parse(_currentUserService.UserId!);
                tasks = await _repository.GetByUserIdAsync(userId);
            }

            return _mapper.Map<IEnumerable<TaskDto>>(tasks);
        }
    }
}
