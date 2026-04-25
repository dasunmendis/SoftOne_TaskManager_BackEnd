using MediatR;

namespace TaskManager.Application.Features.Tasks.Commands.DeleteTask
{
    // Command record carrying the ID of the task to delete
    public record DeleteTaskCommand(int Id) : IRequest<Unit>;
}
