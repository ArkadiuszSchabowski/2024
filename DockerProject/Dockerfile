# Używamy obrazu ASP.NET Core jako podstawy
FROM mcr.microsoft.com/dotnet/aspnet:8.0

# Ustawiamy katalog roboczy
WORKDIR /app

# Kopiujemy pliki aplikacji do obrazu
COPY . /app

# Ustawiamy domyślne polecenie uruchamiające aplikację
ENTRYPOINT ["dotnet", "YourApp.dll"]