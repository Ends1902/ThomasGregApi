# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src

COPY . .

RUN dotnet restore ThomasGreg.sln
RUN dotnet publish src/ThomasGreg.API/ThomasGreg.API.csproj -c Release -o /app/publish

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS runtime
WORKDIR /app

# Copia a publicação da build
COPY --from=build /app/publish .

# Copia os scripts
COPY src/ThomasGreg.API/ScriptsIniciais /app/ScriptsIniciais

# Executa a API
ENTRYPOINT ["dotnet", "ThomasGreg.API.dll"]