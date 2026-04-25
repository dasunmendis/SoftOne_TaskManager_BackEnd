using MediatR;

namespace TaskManager.Application.Features.Tasks.Commands.UpdateTask
{
    // Command record carrying the updated data
    public record UpdateTaskCommand(int Id, string Title, string Description, bool IsCompleted) : IRequest<Unit>;
}
