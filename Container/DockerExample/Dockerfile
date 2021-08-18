FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

ENV ASPNETCORE_URLS=http://+:80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["DockerExampleWithSQL.csproj", "./"]
RUN dotnet restore "DockerExampleWithSQL.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "DockerExampleWithSQL.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DockerExampleWithSQL.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DockerExampleWithSQL.dll"]
