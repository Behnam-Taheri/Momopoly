#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Monopoly/src/Tactical.Monopoly.EndPoint.Api/Tactical.Monopoly.EndPoint.Api.csproj", "Monopoly/src/Tactical.Monopoly.EndPoint.Api/"]
COPY ["Monopoly/src/Tactical.Monopoly.Application.Contract/Tactical.Monopoly.Application.Contract.csproj", "Monopoly/src/Tactical.Monopoly.Application.Contract/"]
COPY ["Monopoly/src/Tactical.Framework.Application/Tactical.Framework.Application.csproj", "Monopoly/src/Tactical.Framework.Application/"]
COPY ["Monopoly/src/Tactical.Framework.Core/Tactical.Framework.Core.csproj", "Monopoly/src/Tactical.Framework.Core/"]
COPY ["Monopoly/src/Tactical.Monopoly.Application/Tactical.Monopoly.Application.csproj", "Monopoly/src/Tactical.Monopoly.Application/"]
COPY ["Monopoly/src/Tactical.Monopoly.Domain/Tactical.Monopoly.Domain.csproj", "Monopoly/src/Tactical.Monopoly.Domain/"]
COPY ["Monopoly/src/Tactical.Framework.Domain/Tactical.Framework.Domain.csproj", "Monopoly/src/Tactical.Framework.Domain/"]
COPY ["Monopoly/src/Tactical.Monopoly.Persistence.EF/Tactical.Monopoly.Persistence.EF.csproj", "Monopoly/src/Tactical.Monopoly.Persistence.EF/"]
COPY ["Monopoly/src/Tactical.Framework.Persistence.EF/Tactical.Framework.Persistence.EF.csproj", "Monopoly/src/Tactical.Framework.Persistence.EF/"]
COPY ["Monopoly/src/Tactical.Monopoly.Queries.Contracts/Tactical.Monopoly.Queries.Contracts.csproj", "Monopoly/src/Tactical.Monopoly.Queries.Contracts/"]
COPY ["Monopoly/src/Tactical.Monopoly.Queries.EF/Tactical.Monopoly.Queries.EF.csproj", "Monopoly/src/Tactical.Monopoly.Queries.EF/"]
COPY ["Monopoly/src/Tactical.Monopoly.Queries.Retrival.EF/Tactical.Monopoly.Queries.Retrieval.EF.csproj", "Monopoly/src/Tactical.Monopoly.Queries.Retrival.EF/"]
RUN dotnet restore "./Monopoly/src/Tactical.Monopoly.EndPoint.Api/Tactical.Monopoly.EndPoint.Api.csproj"
COPY . .
WORKDIR "/src/Monopoly/src/Tactical.Monopoly.EndPoint.Api"
RUN dotnet build "./Tactical.Monopoly.EndPoint.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Tactical.Monopoly.EndPoint.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Tactical.Monopoly.EndPoint.Api.dll"]