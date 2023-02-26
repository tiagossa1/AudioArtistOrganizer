FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["AudioArtistOrganizer/AudioArtistOrganizer.csproj", "AudioArtistOrganizer/"]
RUN dotnet restore "AudioArtistOrganizer/AudioArtistOrganizer.csproj"
COPY . .
WORKDIR "/src/AudioArtistOrganizer"
RUN dotnet build "AudioArtistOrganizer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AudioArtistOrganizer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AudioArtistOrganizer.dll"]
