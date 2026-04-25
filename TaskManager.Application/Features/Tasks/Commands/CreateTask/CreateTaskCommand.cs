using MediatR;

namespace TaskManager.Application.Features.Tasks.Commands.CreateTask
{
    public record CreateTaskCommand(string Title, string Description) : IRequest<int>;
}
