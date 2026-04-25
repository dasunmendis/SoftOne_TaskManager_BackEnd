using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.Domain.Interfaces;

namespace TaskManager.Application.Features.Tasks.Commands.UpdateTask
{
    public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, Unit>
    {
        private readonly ITaskRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateTaskCommandHandler(ITaskRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            var task = await _repository.GetByIdAsync(request.Id);

            if (task == null)
            {
                // In a real-world scenario, you might throw a custom NotFoundException here 
                // which would be caught by a global exception handling middleware.
                throw new Exception($"Task with ID {request.Id} not found.");
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
