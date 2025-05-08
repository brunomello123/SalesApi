# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8090

# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /app

# Copiar os arquivos .csproj de todas as camadas

COPY ["SalesApi/SalesApi.csproj", "SalesApi/"]
COPY ["SalesApi.Domain/SalesApi.Domain.csproj", "SalesApi.Domain/"]
COPY ["SalesApi.Infrastructure/SalesApi.Infrastructure.csproj", "SalesApi.Infrastructure/"]
COPY ["SalesApi.Application/SalesApi.Application.csproj", "SalesApi.Application/"]
COPY ["SalesApi.Application.Contracts/SalesApi.Application.Contracts.csproj", "SalesApi.Application.Contracts/"]

# Restaurar os pacotes NuGet
RUN dotnet restore "SalesApi/SalesApi.csproj"

# Copiar os arquivos de código-fonte
COPY . .

# Definir o diretório de trabalho e compilar o projeto
WORKDIR "/app/SalesApi"
RUN dotnet build "SalesApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "SalesApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app

# Copiar a publicação para o contêiner final
COPY --from=publish /app/publish .

# Definir a variável de ambiente para a URL de escuta
ENV ASPNETCORE_URLS=http://+:8090

# Definir o ponto de entrada do contêiner
ENTRYPOINT ["dotnet", "SalesApi.dll"]