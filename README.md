# Battleships

## Description
Simple version of the game Battleships. Application allows a single human player to play a one-sided game of Battleships against ships placed by the computer.

## Requirements
[.NET 5 SDK](https://dotnet.microsoft.com/download/dotnet/5.0)

## Restore (Install dependencies)
```shell
dotnet restore
```

## Build
```shell
dotnet build
```

## Run
```shell
dotnet run --project Battleships
```

## Test
```shell
dotnet test
```

## Instruction

The player enters coordinates of the form “A5”, where “A” is the column and “5” is the row, to specify a field to hit. 
Hits result in hits, misses or sinks. The game ends when all ships are sunk.

## Config

Change configuration in config.json file.

## Debug mode

Game displays ships on board even if user doesn't hit them. Use it for testing.

## Game board Legend

o - field not hit

S - ship hit

x - hit miss

ONLY FOR DEBUG MODE: s - ship on field

