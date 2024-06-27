using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class TaskRepository : ITaskRepository
{
    private readonly DynamoDBContext _context;

    public TaskRepository(IAmazonDynamoDB dynamoDbClient)
    {
        _context = new DynamoDBContext(dynamoDbClient);
    }

    public async Task<IEnumerable<TaskItem>> GetTasksAsync()
    {
        var scanConditions = new List<ScanCondition>();
        return await _context.ScanAsync<TaskItem>(scanConditions).GetRemainingAsync();
    }

    public async Task<TaskItem> GetTaskAsync(string id)
    {
        return await _context.LoadAsync<TaskItem>(id);
    }

    public async Task AddTaskAsync(TaskItem task)
    {
        task.Id = Guid.NewGuid().ToString();
        await _context.SaveAsync(task);
    }

    public async Task UpdateTaskAsync(TaskItem task)
    {
        await _context.SaveAsync(task);
    }

    public async Task DeleteTaskAsync(string id)
    {
        await _context.DeleteAsync<TaskItem>(id);
    }
}