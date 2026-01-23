# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0-bookworm-slim AS build
WORKDIR /src

# Copy solution and restore dependencies
COPY FCG_CATALOGAPI.sln .
COPY FCG_CATALOGAPI/*.csproj ./FCG_CATALOGAPI/
RUN dotnet restore

# Copy everything else and build
COPY . .
WORKDIR /src/FCG_CATALOGAPI
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0-bookworm-slim AS runtime
WORKDIR /app

ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "FCG_CATALOGAPI.dll"]
