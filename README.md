# Parkolóhely-foglaló
Ebben a repositoryban egy lokálisan futó, adatbázist használó, parkolóhely foglaló található

## Alkalmazás használata

### Előfeltétel:
Az alkalmazás .NET 10-el, és .NET MAUI-val készült, így futtatás elött meg kell győződni, hogy mindkettő le van töltve a gazdagépre.  

A .NET 10-est a saját weboldaláról lehet letölteni ([https://dotnet.microsoft.com/en-us/download/dotnet/10.0](https://dotnet.microsoft.com/en-us/download/dotnet/10.0)) - én a 10.302-es verziót használom, ezt tudom ajánlani, hogy minden jól működjön.  

A .NET MAUI-t a .NET 10 letöltése után a következő paranccsal lehet letöletni: 

    dotnet workload install maui

### Futtatás
Ha az előfeltétel teljesül, az alkalmazás elindításához egyetlen parancsot kell lefuttatni, Windows 10, 2004-es verzión vagy újabban (Windows 11 is működik), a Parkolóhely-foglaló.MAUI project mappában:  

    dotnet run

Ha netán nem működne, akkor specifikálni kell a framework verziót is, ezt pedig a következő paranccsal lehet megtenni:

    dotnet run --framework net10.0-windows10.0.19041.0

## Tech stack:  

    Backend: .NET 10 C#, Entity Framework Core + SQLite
    Frontend: .NET MAUI Blazor Hybrid