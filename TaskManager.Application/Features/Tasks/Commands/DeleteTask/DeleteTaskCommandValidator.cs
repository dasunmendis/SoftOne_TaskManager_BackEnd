using FluentValidation;

namespace TaskManager.Application.Features.Tasks.Commands.DeleteTask
{
    public class DeleteTaskCommandValidator : AbstractValidator<DeleteTaskCommand>
    {
        public DeleteTaskCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Valid Task ID is required to delete.");
        }
    }
}
