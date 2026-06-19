# CryptoMarketApi

CryptoMarketApi is a small ASP.NET Core Web API created for backend challenges and practice projects.

## Status

This project is in its initial setup. The current API exposes a single test endpoint.

## Tech Stack

- C#
- ASP.NET Core Minimal API
- .NET 10

## Requirements

- .NET SDK 10.0 or newer

## Getting Started

Restore dependencies:

```bash
dotnet restore
```

Run the application:

```bash
dotnet run
```

By default, the development profiles use:

- `http://localhost:5200`
- `https://localhost:7040`

## Endpoints

| Method | Route | Description |
| ------ | ----- | ----------- |
| GET | `/` | Returns `Hello World!` |

## Project Structure

```text
CryptoMarketApi/
|-- Program.cs
|-- CryptoMarketApi.csproj
|-- appsettings.json
|-- appsettings.Development.json
`-- Properties/
    `-- launchSettings.json
```

## Goal

The goal of this repository is to evolve into a crypto market API while improving backend development skills.



## Query in Database

To viwew all values recorded over time

SELEC c.CoinName, c.CoinSymbol, p.Value, p.RecordedAt
FROM Coins c
INNER JOIN Prices p ON p.CoinId = c.Id
ORDER BY p.RecordedAt DESC;


To view only the current valuew

SELECT c.CoinName, c.CoinSymbol, p.Value, p.RecordedAt
FROM Coins c
INNER JOIN Prices p ON p.CoinId = c.Id
WHERE p.RecordedAt = (
    SELECT MAX(p2.RecordedAt) 
    FROM Prices p2 
    WHERE p2.CoinId = c.Id
)
ORDER BY c.Id;
