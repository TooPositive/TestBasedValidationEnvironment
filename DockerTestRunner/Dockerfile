#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["DockerTestRunner/DockerTestRunner.csproj", "DockerTestRunner/"]
COPY ["Tests.Core/Tests.Core.csproj", "Tests.Core/"]
RUN dotnet restore "DockerTestRunner/DockerTestRunner.csproj"
COPY . .
WORKDIR "/src/DockerTestRunner"
RUN dotnet build "DockerTestRunner.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DockerTestRunner.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DockerTestRunner.dll"]