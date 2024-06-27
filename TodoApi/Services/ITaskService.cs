using System.Collections.Generic; // Importando namespace para listas genéricas
using System.Threading.Tasks; // Importando namespace para tarefas assíncronas

// Definição da interface ITaskService
public interface ITaskService
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

/*
 * Porque escolhi o uso de interfaces e serviços:
 * 
 * Interfaces:
 * A utilização de interfaces, como a ITaskService, nos permite definir um contrato que as classes concretas devem seguir.
 * Isso promove uma arquitetura desacoplada, facilitando a substituição de implementações e permitindo a criação de 
 * testes unitários mais eficazes. Com interfaces, podemos facilmente trocar a implementação do serviço sem alterar o 
 * código que o consome, promovendo a flexibilidade e extensibilidade da aplicação.
 * 
 * Serviços:
 * O uso de serviços, como o TaskService que implementa a ITaskService, permite encapsular a lógica de negócios da aplicação.
 * Ao separar a lógica de negócios (serviços) da lógica de acesso a dados (repositórios), obtemos um código mais modular e 
 * fácil de manter. Isso também promove a reutilização de código e facilita a implementação de testes unitários, uma vez 
 * que podemos mockar os serviços e testar a lógica de negócios de forma isolada.
 * 
 * Em resumo, a combinação de interfaces e serviços melhora a estrutura e a qualidade do código, promovendo boas práticas 
 * de programação e facilitando a manutenção e a escalabilidade da aplicação.
 */
