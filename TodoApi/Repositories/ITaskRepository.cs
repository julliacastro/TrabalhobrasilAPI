// Definição da interface ITaskRepository
public interface ITaskRepository
{
    // Método para obter todas as tarefas de forma assíncrona
    Task<IEnumerable<TaskItem>> GetTasksAsync();

    // Método para obter uma tarefa específica pelo ID de forma assíncrona
    Task<TaskItem> GetTaskAsync(string id);

    // Método para adicionar uma nova tarefa de forma assíncrona
    Task AddTaskAsync(TaskItem task);

    // Método para atualizar uma tarefa existente de forma assíncrona
    Task UpdateTaskAsync(TaskItem task);

    // Método para deletar uma tarefa pelo ID de forma assíncrona
    Task DeleteTaskAsync(string id);
}
