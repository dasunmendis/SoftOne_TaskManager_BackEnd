using MediatR;
using TaskManager.Application.DTOs;

namespace TaskManager.Application.Features.Tasks.Queries.GetTasks
{
    public record GetTasksQuery() : IRequest<IEnumerable<TaskDto>>;
}
