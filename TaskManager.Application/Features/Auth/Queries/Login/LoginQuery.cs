using MediatR;

namespace TaskManager.Application.Features.Auth.Queries.Login
{
    public record LoginQuery(string Username, string Password) : IRequest<bool>;
}
