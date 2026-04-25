using MediatR;
using TaskManager.Domain.Interfaces;

namespace TaskManager.Application.Features.Auth.Queries.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, bool>
    {
        private readonly IUserRepository _userRepository;

        public LoginQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByUsernameAsync(request.Username);

            if (user == null) return false;

            // Verify the password against the stored hash
            return BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);
        }
    }
}
