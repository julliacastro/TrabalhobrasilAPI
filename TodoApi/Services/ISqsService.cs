using System.Threading.Tasks;

public interface ISqsService
{
    Task SendMessageAsync(string message);
}
