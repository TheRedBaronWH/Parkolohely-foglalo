# Parkolóhely-foglaló
Ebben a repositoryban egy lokálisan futó, adatbázist használó, parkolóhely foglaló található

## Futtatás
Futtatáshoz a következő parancsot kell lefuttatni Windows 10, 2004es verzión vagy újabban (Windows 11 is működik), a Parkolóhely-foglaló.MAUI project mappában:  

    dotnet run

Ha netán nem működne, akkor specifikálni kell a framework verziót is, ezt pedig a következő paranccsal:

    dotnet run --framework net10.0-windows10.0.19041.0

## Tech stack:  

    Backend: .NET 10 C#, Entity Framework Core + SQLite
    Frontend: .NET MAUI Blazor Hybrid