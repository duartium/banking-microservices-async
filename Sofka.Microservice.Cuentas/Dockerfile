# Imagen base para la compilación
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar el archivo de proyecto y restaurar las dependencias
COPY Sofka.Microservice.Cuentas.csproj ./
RUN dotnet restore Sofka.Microservice.Cuentas.csproj

# Copiar el resto del código fuente y compilar la aplicación
COPY ./ ./
RUN dotnet build -c Release -o /app/build

# Publicar la aplicación (compilarla y dejarla lista para ejecución)
RUN dotnet publish -c Release -o /app/publish

# Imagen base para la ejecución
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
RUN ls -la /app  # Listar el contenido de /app para verificar los archivos después del COPY

# Definir el punto de entrada del contenedor
ENTRYPOINT ["dotnet", "Sofka.Microservice.Cuentas.dll"]
