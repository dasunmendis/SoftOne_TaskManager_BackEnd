using MediatR;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Interfaces;

namespace TaskManager.Application.Features.Tasks.Commands.CreateTask
{
    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, int>
    {
        private readonly ITaskRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateTaskCommandHandler(ITaskRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var task = new TaskItem { Title = request.Title, Description = request.Description };
            await _repository.AddAsync(task);
            await _unitOfWork.SaveChangesAsync();
            return task.Id;
        }
    }
}
