FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["./webProjects/Application/Application.csproj","webProjects/Application/"]
COPY ["./webProjects/Domain/Domain.csproj","webProjects/Domain/"]
COPY ["./webProjects/Persistence/Persistence.csproj","webProjects/Persistence/"]
COPY ["./webProjects/Insfrastructure/Insfrastructure.csproj","webProjects/Insfrastructure/"]
COPY ["./webProjects/WebAPI/WebAPI.csproj","webProjects/WebAPI/"]

COPY ["./corePackages/Core.CrossCutting/Core.CrossCuttingConcerns.csproj","webProjects/Core.CrossCutting/"]

RUN dotnet restore "webProjects/WebAPI/WebAPI.csproj"

COPY . .


WORKDIR "/src/webProjects/WebAPI/"
RUN dotnet build -c Release -o /app/build

ENV ASPNETCORE_ENVIRONMENT=Production

FROM build as publish
RUN dotnet publish -c Release -o /app/publish

FROM base AS runtime
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS=http://+:5190

ENTRYPOINT [ "dotnet", "WebAPI.dll" ]

