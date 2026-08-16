# MinProfil

> ⚠️ **Varning:** Den här applikationen innehåller medvetna säkerhetsbrister och är enbart avsedd som övningsmaterial. Den ska aldrig köras i produktion eller exponeras mot internet.

En liten ASP.NET Core-applikation med inloggning och profilsida, byggd i Blazor. Användare loggar in, skriver en fritextpresentation om sig själva och kan läsa andra medlemmars presentationer.

Applikationen används i en övning i kursen IT-säkerhet för utvecklare. Den innehåller ett antal medvetna säkerhetsbrister, och din uppgift är att hitta dem, visa att de går att utnyttja och sedan åtgärda dem i koden. Se övningsinstruktionen i Learnpoint för detaljerna.

## Kom igång

Du behöver [.NET 10 SDK](https://dotnet.microsoft.com/download) och en kodeditor, exempelvis Visual Studio eller VS Code.

```shell
cd minprofil
dotnet watch run
```

Appen startar på `http://localhost:5150` och skapar en SQLite-databas `minprofil.db` med några testkonton första gången den körs.

## Testkonton

| Användarnamn | Lösenord |
|--------------|----------|
| `anna`  | `sommar2025` |
| `erik`  | `hunter2` |
| `sara`  | `qwerty` |

## Struktur

- `Program.cs` startar appen och innehåller endpoints för inloggning, utloggning och att spara profiltext.
- `Data/` innehåller datalagret mot SQLite, sessionshanteringen och användarmodellen.
- `Components/Pages/` innehåller sidorna: startsida, inloggning, profil och medlemslista.

## Arbetssätt i övningen

Skapa en egen branch och gör en tydlig commit per åtgärdad brist, med ett commit-meddelande som beskriver vad du rättade. För varje brist: verifiera först att den går att utnyttja, åtgärda i kod och verifiera sedan att attacken inte längre fungerar.

## Om den här kopian

Det här är min inlämning på övningen. Originalrepot ligger på [QuBaR/minprofil](https://github.com/QuBaR/minprofil).

Åtgärderna görs i branchen `feature/sakerhetsfixar-ovning-2-2`, med en commit per åtgärdad brist.
