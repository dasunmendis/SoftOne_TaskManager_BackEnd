using AutoMapper;
using MediatR;
using TaskManager.Application.DTOs;
using TaskManager.Domain.Interfaces;

namespace TaskManager.Application.Features.Tasks.Queries.GetTasks
{
    public class GetTasksQueryHandler : IRequestHandler<GetTasksQuery, IEnumerable<TaskDto>>
    {
        private readonly ITaskRepository _repository;
        private readonly IMapper _mapper;

        public GetTasksQueryHandler(ITaskRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TaskDto>> Handle(GetTasksQuery request, CancellationToken cancellationToken)
        {
            var tasks = await _repository.GetAllAsync();

            // Map the Domain Entities to DTOs before sending to the API layer
            return _mapper.Map<IEnumerable<TaskDto>>(tasks);
        }
    }
}
