FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Frank.TorrentClient.Host/Frank.TorrentClient.Host.csproj", "Frank.TorrentClient.Host/"]
RUN dotnet restore "Frank.TorrentClient.Host/Frank.TorrentClient.Host.csproj"
COPY . .
WORKDIR "/src/Frank.TorrentClient.Host"
RUN dotnet build "Frank.TorrentClient.Host.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Frank.TorrentClient.Host.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Frank.TorrentClient.Host.dll"]
