# Imagem base do runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5000

# Imagem para build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia o csproj e restaura pacotes
COPY ["TesteRefeito.csproj", "./"]
RUN dotnet restore "TesteRefeito.csproj"

# Copia todo o restante do projeto
COPY . .
RUN dotnet build "TesteRefeito.csproj" -c Release -o /app/build
RUN dotnet publish "TesteRefeito.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Imagem final
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "TesteRefeito.dll"]