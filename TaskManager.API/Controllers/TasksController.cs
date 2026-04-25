using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Features.Tasks.Commands.CreateTask;
using TaskManager.Application.Features.Tasks.Commands.DeleteTask;
using TaskManager.Application.Features.Tasks.Commands.UpdateTask;
using TaskManager.Application.Features.Tasks.Queries.GetTasks;

namespace TaskManager.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TasksController(IMediator mediator) => _mediator = mediator;

        // GET: api/tasks
        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _mediator.Send(new GetTasksQuery()));

        // POST: api/tasks
        [HttpPost]
        public async Task<IActionResult> Create(CreateTaskCommand command) => Ok(await _mediator.Send(command));

        // PUT: api/tasks/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateTaskCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest("The Task ID in the URL does not match the ID in the request body.");
            }

            await _mediator.Send(command);

            // 204 No Content is standard for a successful PUT request
            return NoContent();
        }

        // DELETE: api/tasks/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteTaskCommand(id));

            // 204 No Content is standard for a successful DELETE request
            return NoContent();
        }
    }
}
