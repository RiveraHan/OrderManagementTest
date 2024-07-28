# Utiliza una imagen base de ASP.NET Core runtime para la aplicación
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Utiliza una imagen base de .NET Core SDK para construir la aplicación
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia los archivos .csproj y restaura las dependencias
COPY ["UserService/UserService.csproj", "UserService/"]
RUN dotnet restore "UserService/UserService.csproj"

# Copia el resto de los archivos y construye la aplicación
COPY . .
WORKDIR "/src/UserService"
RUN dotnet build "UserService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UserService.csproj" -c Release -o /app/publish

# Configura la imagen final para ejecutar la aplicación
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
# Configura la aplicación para escuchar en HTTP
ENV ASPNETCORE_URLS=http://+:80
ENTRYPOINT ["dotnet", "UserService.dll"]