using Amazon.DynamoDBv2;
using Amazon.Extensions.NETCore.Setup;
using Amazon.SQS;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Adicionando serviços ao contêiner de dependência
builder.Services.AddControllers();

// Configurando opções padrão da AWS usando appsettings.json
builder.Services.AddDefaultAWSOptions(builder.Configuration.GetAWSOptions());
builder.Services.AddAWSService<IAmazonDynamoDB>(); // Adiciona suporte ao serviço DynamoDB da AWS
builder.Services.AddAWSService<IAmazonSQS>(); // Adiciona suporte ao serviço SQS da AWS

// Registrando nossos repositórios e serviços para injeção de dependência
builder.Services.AddSingleton<ITaskRepository, TaskRepository>(); // Repositório para gerenciar tarefas
builder.Services.AddSingleton<ITaskService, TaskService>(); // Serviço para lógica de negócios de tarefas
builder.Services.AddSingleton<ISqsService, SqsService>(); // Serviço para enviar mensagens para SQS

// Configurando o Swagger para gerar documentação da API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Todo API", Version = "v1" }); // Configura o Swagger com título e versão da API
});

// Configurando CORS para permitir qualquer origem, método e cabeçalho
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.AllowAnyOrigin() // Permite requisições de qualquer origem
                   .AllowAnyMethod() // Permite qualquer método HTTP (GET, POST, PUT, DELETE)
                   .AllowAnyHeader(); // Permite qualquer cabeçalho
        });
});

var app = builder.Build();

// Configurando o pipeline de requisição HTTP
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // Mostra página de exceção detalhada em ambiente de desenvolvimento
}

// Configurando o Swagger para gerar a interface de documentação da API
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Todo API V1"); // Configura o endpoint do Swagger
});

app.UseHttpsRedirection(); // Redireciona requisições HTTP para HTTPS

app.UseAuthorization(); // Adiciona middleware de autorização

// Habilitando o CORS
app.UseCors();

app.MapControllers(); // Mapeia os controladores para os endpoints

app.Run("http://*:9080"); // Configura a aplicação para escutar na porta 9080