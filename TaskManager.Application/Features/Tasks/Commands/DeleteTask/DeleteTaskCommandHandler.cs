using MediatR;
using TaskManager.Application.Interfaces;
using TaskManager.Domain.Interfaces;

namespace TaskManager.Application.Features.Tasks.Commands.DeleteTask
{
    public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand, Unit>
    {
        private readonly ITaskRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentUserService _currentUserService;

        public DeleteTaskCommandHandler(ITaskRepository repository, IUnitOfWork unitOfWork, ICurrentUserService currentUserService)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _currentUserService = currentUserService;
        }

        public async Task<Unit> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            var task = await _repository.GetByIdAsync(request.Id);
            if (task == null) throw new Exception("Task not found."); ;

            var currentUserId = int.Parse(_currentUserService.UserId!);

            // Authorization Check
            if (!_currentUserService.IsAdmin && task.UserId != currentUserId)
            {
                throw new UnauthorizedAccessException("You do not have permission to delete this task.");
            }

            _repository.Delete(task);
            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
