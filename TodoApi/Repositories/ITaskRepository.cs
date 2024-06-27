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

/*
 * Porque escolhi o uso de interfaces e repositórios:
 * 
 * Interfaces:
 * Utilizamos interfaces, como a ITaskRepository, para definir um contrato que as classes concretas devem seguir.
 * Isso promove uma arquitetura desacoplada, facilitando a substituição de implementações e permitindo a criação de 
 * testes unitários mais eficazes. Com interfaces, podemos facilmente trocar a implementação do repositório sem 
 * alterar o código que o consome, promovendo a flexibilidade e extensibilidade da aplicação.
 * 
 * Repositórios:
 * Utilizamos repositórios para encapsular a lógica de acesso a dados. Isso nos permite isolar a camada de persistência
 * da aplicação, facilitando a manutenção e a troca de implementações de armazenamento sem afetar outras partes do sistema.
 * O repositório lida com operações CRUD (Create, Read, Update, Delete) nos dados, fornecendo uma interface limpa e 
 * consistente para manipulação dos dados.
 * 
 * Em resumo, a combinação de interfaces e repositórios melhora a estrutura e a qualidade do código, promovendo boas práticas 
 * de programação e facilitando a manutenção e a escalabilidade da aplicação.
 */
