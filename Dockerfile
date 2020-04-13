#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM node:10.15-alpine AS client 
ARG skip_client_build=false 
WORKDIR /app 
COPY MgrAngularWithDockers/ClientApp . 
RUN [[ ${skip_client_build} = true ]] && echo "Skipping npm install" || npm install 
RUN [[ ${skip_client_build} = true ]] && mkdir dist || npm run-script build

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["MgrAngularWithDockers/MgrAngularWithDockers.csproj", "MgrAngularWithDockers/"]
COPY ["MgrAngularWithDockers.Core/MgrAngularWithDockers.Core.csproj", "MgrAngularWithDockers.Core/"]
COPY ["Tests.Core/Tests.Core.csproj", "Tests.Core/"]
RUN dotnet restore "MgrAngularWithDockers/MgrAngularWithDockers.csproj"

COPY . ./
WORKDIR "/src/MgrAngularWithDockers"
RUN dotnet build "MgrAngularWithDockers.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MgrAngularWithDockers.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY --from=client /app/dist /app/dist
ENTRYPOINT ["dotnet", "MgrAngularWithDockers.dll"]