using MediatR;
using TaskManager.Domain.Interfaces;

namespace TaskManager.Application.Features.Tasks.Commands.DeleteTask
{
    public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand, Unit>
    {
        private readonly ITaskRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTaskCommandHandler(ITaskRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            var task = await _repository.GetByIdAsync(request.Id);

            if (task == null)
            {
                throw new Exception($"Task with ID {request.Id} not found.");
            }

            _repository.Delete(task);
            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
