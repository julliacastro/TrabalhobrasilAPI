using System.Collections.Generic; // Importando namespace para listas genéricas
using System.Threading.Tasks; // Importando namespace para tarefas assíncronas

// Implementação do serviço de tarefas, que lida com a lógica de negócios
public class TaskService : ITaskService
{
    // Dependência do repositório de tarefas, injetada via construtor
    private readonly ITaskRepository _taskRepository;

    // Construtor que recebe uma instância do repositório de tarefas
    public TaskService(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    // Método para obter a lista de tarefas de forma assíncrona
    public async Task<IEnumerable<TaskItem>> GetTasksAsync()
    {
        // Chama o método GetTasksAsync do repositório e retorna a lista de tarefas
        return await _taskRepository.GetTasksAsync();
    }

    // Método para obter uma tarefa específica pelo ID de forma assíncrona
    public async Task<TaskItem> GetTaskAsync(string id)
    {
        // Chama o método GetTaskAsync do repositório e retorna a tarefa correspondente ao ID
        return await _taskRepository.GetTaskAsync(id);
    }

    // Método para adicionar uma nova tarefa de forma assíncrona
    public async Task AddTaskAsync(TaskItem task)
    {
        // Chama o método AddTaskAsync do repositório para adicionar a nova tarefa
        await _taskRepository.AddTaskAsync(task);
    }

    // Método para atualizar uma tarefa existente de forma assíncrona
    public async Task UpdateTaskAsync(TaskItem task)
    {
        // Chama o método UpdateTaskAsync do repositório para atualizar a tarefa
        await _taskRepository.UpdateTaskAsync(task);
    }

    // Método para deletar uma tarefa pelo ID de forma assíncrona
    public async Task DeleteTaskAsync(string id)
    {
        // Chama o método DeleteTaskAsync do repositório para deletar a tarefa correspondente ao ID
        await _taskRepository.DeleteTaskAsync(id);
    }
}
