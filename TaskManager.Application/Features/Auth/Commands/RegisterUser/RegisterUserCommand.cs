using MediatR;

namespace TaskManager.Application.Features.Auth.Commands.RegisterUser
{
    // Default RoleId to 3 (User) if not explicitly provided
    public record RegisterUserCommand(string FirstName, string LastName, string Username, string Password, int RoleId = 3) : IRequest<int>;
}
