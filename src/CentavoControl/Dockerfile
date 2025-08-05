FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["CentavoControl/CentavoControl.csproj", "CentavoControl/"]
COPY ["CentavoControl.Application/CentavoControl.Application.csproj", "CentavoControl.Application/"]
COPY ["CentavoControl.Domain/CentavoControl.Domain.csproj", "CentavoControl.Domain/"]
COPY ["CentavoControl.Infrastructure/CentavoControl.Infrastructure.csproj", "CentavoControl.Infrastructure/"]
RUN dotnet restore "CentavoControl/CentavoControl.csproj"
COPY . .
WORKDIR "/src/CentavoControl"
RUN dotnet build "./CentavoControl.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./CentavoControl.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CentavoControl.dll"]
