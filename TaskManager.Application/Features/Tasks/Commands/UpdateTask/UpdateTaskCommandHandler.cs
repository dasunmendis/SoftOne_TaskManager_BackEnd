using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.Application.Interfaces;
using TaskManager.Domain.Interfaces;

namespace TaskManager.Application.Features.Tasks.Commands.UpdateTask
{
    public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, Unit>
    {
        private readonly ITaskRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentUserService _currentUserService;

        public UpdateTaskCommandHandler(ITaskRepository repository, IUnitOfWork unitOfWork, ICurrentUserService currentUserService)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _currentUserService = currentUserService;
        }

        public async Task<Unit> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            var task = await _repository.GetByIdAsync(request.Id);
            if (task == null) throw new Exception("Task not found.");

            var currentUserId = int.Parse(_currentUserService.UserId!);

            // Authorization Check
            if (!_currentUserService.IsAdmin && task.UserId != currentUserId)
            {
                throw new UnauthorizedAccessException("You do not have permission to modify this task.");
            }

            // Update properties
            task.Title = request.Title;
            task.Description = request.Description;
            task.IsCompleted = request.IsCompleted;

            _repository.Update(task);
            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
