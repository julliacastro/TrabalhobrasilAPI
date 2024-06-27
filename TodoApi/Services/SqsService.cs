using Amazon.SQS;
using Amazon.SQS.Model;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

public class SqsService : ISqsService
{
    private readonly IAmazonSQS _sqsClient;
    private readonly string _queueUrl;

    public SqsService(IAmazonSQS sqsClient, IConfiguration configuration)
    {
        _sqsClient = sqsClient;
        _queueUrl = configuration["SQS:QueueUrl"];
    }

    public async Task SendMessageAsync(string message)
    {
        var sendMessageRequest = new SendMessageRequest
        {
            QueueUrl = _queueUrl,
            MessageBody = message
        };

        await _sqsClient.SendMessageAsync(sendMessageRequest);
    }
}
