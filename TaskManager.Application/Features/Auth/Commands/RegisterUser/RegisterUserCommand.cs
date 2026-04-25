using MediatR;

namespace TaskManager.Application.Features.Auth.Commands.RegisterUser
{
    public record RegisterUserCommand(string Username, string Password) : IRequest<int>;
}
