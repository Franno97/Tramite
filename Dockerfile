#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src

COPY ["src/Mre.Visas.Tramite.Api/Mre.Visas.Tramite.Api.csproj", "./Mre.Visas.Tramite.Api/"]
COPY ["src/Mre.Visas.Tramite.Application/Mre.Visas.Tramite.Application.csproj", "./Mre.Visas.Tramite.Application/"]
COPY ["src/Mre.Visas.Tramite.Application.Contracts/Mre.Visas.Tramite.Application.Contracts.csproj", "./Mre.Visas.Tramite.Application.Contracts/"]
COPY ["src/Mre.Visas.Tramite.Domain/Mre.Visas.Tramite.Domain.csproj", "./Mre.Visas.Tramite.Domain/"]
COPY ["src/Mre.Visas.Tramite.Infrastructure/Mre.Visas.Tramite.Infrastructure.csproj", "./Mre.Visas.Tramite.Infrastructure/"]
COPY ["src/Mre.Visas.Tramite.Api/Shared/Reports/*.*","src/Mre.Visas.Tramite.Api/Shared/Reports/"]
RUN dotnet restore "Mre.Visas.Tramite.Api/Mre.Visas.Tramite.Api.csproj"

COPY ["src/Mre.Visas.Tramite.Api", "./Mre.Visas.Tramite.Api/"]
COPY ["src/Mre.Visas.Tramite.Application", "./Mre.Visas.Tramite.Application/"]
COPY ["src/Mre.Visas.Tramite.Application.Contracts", "./Mre.Visas.Tramite.Application.Contracts/"]
COPY ["src/Mre.Visas.Tramite.Domain", "./Mre.Visas.Tramite.Domain/"]
COPY ["src/Mre.Visas.Tramite.Infrastructure", "./Mre.Visas.Tramite.Infrastructure/"]

RUN dotnet build "Mre.Visas.Tramite.Api/Mre.Visas.Tramite.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Mre.Visas.Tramite.Api/Mre.Visas.Tramite.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY ["src/Mre.Visas.Tramite.Api/Shared/Reports/*.*","/app/Shared/Reports/"]


ENTRYPOINT ["dotnet", "Mre.Visas.Tramite.Api.dll"]

