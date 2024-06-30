# Usando a imagem oficial do ASP.NET Core runtime como base
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 9080 
# Expondo a porta 9080 para acesso externo

# Usando a imagem oficial do .NET SDK para construir o projeto
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .  
# Copiando todos os arquivos do diretório atual para o diretório de trabalho do contêiner
RUN dotnet restore 
# Restaurando as dependências do projeto
RUN dotnet build -c Release -o /app/build 
# Compilando o projeto em modo Release e output para /app/build

# Publicando a aplicação
FROM build AS publish
RUN dotnet publish -c Release -o /app/publish 

#Publicando a aplicação para /app/publish

# Usando a imagem base para o estágio final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish . 
# Copiando os arquivos publicados do estágio publish para o diretório de trabalho
ENTRYPOINT ["dotnet", "TodoApi.dll"] 
# Configurando o ponto de entrada da aplicação para executar o backend.dll
