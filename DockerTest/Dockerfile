# U�yj obrazu SDK do budowania aplikacji
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
COPY . .
RUN dotnet restore
RUN dotnet build

# U�yj oficjalnego obrazu Microsoftu dla �rodowiska uruchomieniowego
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app .

# Otw�rz port 80 (poniewa� aplikacja nas�uchuje na porcie 80)
EXPOSE 80

# Uruchomienie aplikacji
ENTRYPOINT ["dotnet", "DockerTest.dll"]