FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MusicLibraryOrganizer/MusicLibraryOrganizer.csproj", "MusicLibraryOrganizer/"]
RUN dotnet restore "MusicLibraryOrganizer/MusicLibraryOrganizer.csproj"
COPY . .
WORKDIR "/src/MusicLibraryOrganizer"
RUN dotnet build "MusicLibraryOrganizer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MusicLibraryOrganizer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MusicLibraryOrganizer.dll"]
