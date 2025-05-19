# Étape 1 : build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /

# Copier le reste du code source
COPY . .

RUN dotnet restore
RUN dotnet publish FusionAPI/*.csproj -c release -o /app/publish --no-restore

# Étape 2 : runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copier les fichiers publiés depuis l'étape précédente
COPY --from=build /app/publish .

# Exposer le port (ajuste selon ton appsettings ou ce que Kestrel utilise)
EXPOSE 8080

# Démarrer l'application
ENTRYPOINT ["dotnet", "FusionAPI.dll"]
