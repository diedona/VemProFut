#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Api/VemProFut.Api/VemProFut.Api.csproj", "src/Api/VemProFut.Api/"]
COPY ["src/Domain/VemProFut.Domain/VemProFut.Domain.csproj", "src/Domain/VemProFut.Domain/"]
COPY ["src/Infra/VemProFut.Infra/VemProFut.Infra.csproj", "src/Infra/VemProFut.Infra/"]
RUN dotnet restore "./src/Api/VemProFut.Api/./VemProFut.Api.csproj"
COPY . .
WORKDIR "/src/src/Api/VemProFut.Api"
RUN dotnet build "./VemProFut.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./VemProFut.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VemProFut.Api.dll"]