# Imagen base para la compilación
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar el archivo de proyecto y restaurar las dependencias
COPY Sofka.Microservice.Clientes.csproj ./
RUN dotnet restore Sofka.Microservice.Clientes.csproj

# Copiar el resto del código fuente y compilar la aplicación
COPY ./ ./
WORKDIR /app/
RUN dotnet build -c Release -o /app/build

# Publicar la aplicación (compilarla y dejarla lista para ejecución)
RUN dotnet publish -c Release -o /app/publish

# Imagen base para la ejecución
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# Definir el punto de entrada del contenedor
ENTRYPOINT ["dotnet", "Sofka.Microservice.Clientes.dll"]
