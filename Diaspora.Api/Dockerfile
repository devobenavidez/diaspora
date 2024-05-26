# Base ASP.NET Core image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

# SDK image for building the code
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj files and restore
COPY ["Diaspora.Api/Diaspora.Api.csproj", "Diaspora.Api/"]
COPY ["Diaspora.Application/Diaspora.Application.csproj", "Diaspora.Application/"]
COPY ["Diaspora.Domain/Diaspora.Domain.csproj", "Diaspora.Domain/"]
COPY ["Diaspora.Infrastructure/Diaspora.Infrastructure.csproj", "Diaspora.Infrastructure/"]
RUN dotnet restore "Diaspora.Api/Diaspora.Api.csproj"

# Copy all the code to build
COPY ["Diaspora.Api/", "Diaspora.Api/"]
COPY ["Diaspora.Application/", "Diaspora.Application/"]
COPY ["Diaspora.Domain/", "Diaspora.Domain/"]
COPY ["Diaspora.Infrastructure/", "Diaspora.Infrastructure/"]

# Set working directory and build
WORKDIR "/src/Diaspora.Api"
RUN dotnet build "Diaspora.Api.csproj" -c Release -o /app/build

# Publish
FROM build AS publish
RUN dotnet publish "Diaspora.Api.csproj" -c Release -o /app/publish

# Final image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Diaspora.Api.dll"]
