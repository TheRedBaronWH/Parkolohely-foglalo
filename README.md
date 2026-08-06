# Parkolóhely-foglaló
Ebben a repositoryban egy lokálisan futó, adatbázist használó, parkolóhely foglaló található  
Készítette: Bencze János István

## Repó szerkezete:
Minden doksi (Felhasználói kézikönyv, API Leírás, Rendszerterv, Döntési napló, Gemini extract és eredeti feladat kiadvány) a [/Docs](/Docs/) mappában

Az alkalmazás Solution-je a gyökér mappa. A model rész a [/Parkolóhely-foglaló.Core](/Parkolóhely-foglaló.Core/) mappában, míg a UI rész a [/Parkolóhely-foglaló.MAUI](/Parkolóhely-foglaló.MAUI/) mappában található.

## Alkalmazás használata:

### Előfeltétel:
Az alkalmazás .NET 10-el, és .NET MAUI-val készült, így futtatás elött meg kell győződni, hogy mindkettő le van töltve a gazdagépre.  

A .NET 10-est a saját weboldaláról lehet letölteni ([https://dotnet.microsoft.com/en-us/download/dotnet/10.0](https://dotnet.microsoft.com/en-us/download/dotnet/10.0)) - én a 10.302-es verziót használom, ezt is tudom ajánlani, hogy minden jól működjön.  

A .NET MAUI-t pedig a .NET 10 letöltése után, a következő paranccsal lehet letöletni: 

    dotnet workload install maui

### Futtatás
Ha az előfeltétel teljesül, az alkalmazás elindításához egyetlen parancsot kell lefuttatni, Windows 10, 2004-es verzión vagy újabban (Windows 11 is működik), a [Parkolóhely-foglaló.MAUI](/Parkolóhely-foglaló.MAUI/)
mappában:  

    dotnet run

Ha netán nem működne, akkor specifikálni kell a framework verziót is, ezt pedig a következő paranccsal lehet megtenni:

    dotnet run --framework net10.0-windows10.0.19041.0

## Tech stack:  

    Backend: .NET 10 C#, Entity Framework Core + SQLite
    Frontend: .NET MAUI Blazor Hybrid

## Unit tesztek:
A project elő van készítve UnitTestek írására, a "testingBranch" nevű branchen 4 darab unittest meg is van írva, viszont sajnos 6 óra próbálkozás után se tudtam rávenni az adatbázist, hogy viselkedjen, és működjön a tesztekkel. Tényleges alkalmazásban működik jól, testekben nem, őszintén ötletem sincs mi lehet a baja...
