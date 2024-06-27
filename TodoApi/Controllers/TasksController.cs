using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private readonly ITaskService _taskService;
    private readonly ISqsService _sqsService;

    public TasksController(ITaskService taskService, ISqsService sqsService)
    {
        _taskService = taskService;
        _sqsService = sqsService;
    }

    [HttpGet]
    public async Task<IActionResult> GetTasks()
    {
        var tasks = await _taskService.GetTasksAsync();
        return Ok(tasks);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTask(string id)
    {
        var task = await _taskService.GetTaskAsync(id);
        if (task == null)
        {
            return NotFound();
        }
        return Ok(task);
    }

    [HttpPost]
    public async Task<IActionResult> AddTask(TaskItem task)
    {
        await _taskService.AddTaskAsync(task);
        await _sqsService.SendMessageAsync($"Task {task.Id} created"); // Enviando mensagem para SQS
        return CreatedAtAction(nameof(GetTask), new { id = task.Id }, task);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTask(string id, TaskItem task)
    {
        if (id != task.Id)
        {
            return BadRequest();
        }
        await _taskService.UpdateTaskAsync(task);
        await _sqsService.SendMessageAsync($"Task {task.Id} updated"); // Enviando mensagem para SQS
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTask(string id)
    {
        await _taskService.DeleteTaskAsync(id);
        await _sqsService.SendMessageAsync($"Task {id} deleted"); // Enviando mensagem para SQS
        return NoContent();
    }
}
